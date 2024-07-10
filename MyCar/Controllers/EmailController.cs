using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.AspNetCore.Mvc;
using MyCar.ConvertData.Interface;
using MyCar.DTOs;
using MyCar.Mappers;
using MyCar.Models;
using MyCar.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ISerialization<EmailDTO> _serialization;
        private readonly IUserService _userService;
        public EmailController(IEmailService emailService, ISerialization<EmailDTO> serialization, IUserService userService) 
        { 
            _emailService = emailService;
            _serialization = serialization;
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> SendEmail(string email)
        {
            try
            {
                var userModel = await _userService.GetUserByEmail(email);
                if (userModel != null)
                {
                    var producerConfig = new ProducerConfig()
                    {
                        BootstrapServers = "kafka-0:9092"
                    };

                    string topicName = "CodeValidation";
                    using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = "kafka-0:9092" }).Build())
                    {
                        bool topicExist = adminClient.GetMetadata(TimeSpan.FromSeconds(1)).Topics.Any(a => a.Topic == topicName);
                        if (!topicExist)
                        {
                            await adminClient.CreateTopicsAsync(new TopicSpecification[]
                            {
                                new TopicSpecification
                                {
                                    Name = topicName,
                                    ReplicationFactor = 1,
                                    NumPartitions = 1
                                }
                            });
                        }
                    }
                    int code = new Random().Next(10000, 99999);
                    
                    EmailDTO emailDTO = _emailService.CreateEmailBody(topicName, userModel, code);
                    emailDTO.Receiver = userModel.Email;
                    emailDTO.CodeValidation = code;
                    EmailModel emailModel = EmailMapper.FromDTOToModel(emailDTO);
                    string emailString = _serialization.ObjSerialize(emailDTO);

                    using (var producerBuilder = new ProducerBuilder<Null, string>(producerConfig).Build())
                    {
                        var topic = new TopicPartition(topicName, new Partition(0));
                        var kafkaMessage = new Message<Null, string>{ Value = emailString};

                        var messageSent = await producerBuilder.ProduceAsync(topic, kafkaMessage);
                    }

                    await _emailService.CreateEmail(emailModel);

                    return Ok(new
                    {
                        success = true,
                        data = emailModel
                    });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                var errorMessage = e.Message;
                return Problem(null, null, 500, errorMessage);
            }
        }
    }
}
