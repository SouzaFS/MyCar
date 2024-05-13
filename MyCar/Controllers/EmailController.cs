using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCar.DTOs;
using MyCar.Services;
using MyCar.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Collections.Generic;
using Newtonsoft.Json;
using MyCar.ConvertData.Interface;
using Microsoft.AspNetCore.Mvc.Routing;
using MyCar.Models;
using MyCar.Mappers;

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
                        BootstrapServers = "localhost:9092"
                    };

                    string emailType = "CodeValidation";
                    int code = new Random().Next(10000, 99999);
                    EmailDTO emailDTO = _emailService.CreateEmailTopics(emailType, userModel, code);
                    emailDTO.Receiver = userModel.Email;
                    emailDTO.CodeValidation = code;
                    EmailModel emailModel = EmailMapper.FromDTOToModel(emailDTO);

                    string emailString = _serialization.ObjSerialize(emailDTO);
                    EmailDTO deserializedEmail = _serialization.ObjDeserialize(emailString);

                    using (var producer = new ProducerBuilder<Null, string>(producerConfig).Build())
                    {
                        var topic = new TopicPartition("CodeValidationEmail", new Partition(0));
                        var kafkaMessage = new Message<Null, string>{ Value = emailString};

                        var messageSent = await producer.ProduceAsync(topic, kafkaMessage);
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
                var errorMessage = e;
                return Problem(null, null, 500);
            }
        }
    }
}
