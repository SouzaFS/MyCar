using Humanizer;
using Microsoft.EntityFrameworkCore;
using MyCar.DTOs;
using MyCar.Mappers;
using MyCar.Models;
using MyCar.Repositories;
using MyCar.Repositories.Interfaces;
using MyCar.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MyCar.Services
{
    public class EmailService : IEmailService
    {
        private IBaseRepository<EmailModel> _baseRepository = null;

        public EmailService()
        {
            _baseRepository = new BaseRepository<EmailModel>();
        }

        public async Task CreateEmail(EmailModel emailModel)
        {
            await _baseRepository.CreateAsync(emailModel);
        }

        public async Task<List<EmailModel>> GetEmails()
        {
            return await _baseRepository.GetAll().ToListAsync();
        }

        public async Task<EmailModel> GetEmailById(int id)
        {
            var emailModel = await _baseRepository.GetByWhere(a => a.Id == id).FirstOrDefaultAsync();
            return emailModel != null ? emailModel : null;
        }

        public async Task UpdateEmail(int id, EmailDTO emailDTO)
        {
            var emailModel = EmailMapper.FromDTOToModel(emailDTO);
            emailModel.Id = id;
            await _baseRepository.UpdateAsync(emailModel);
        }

        public async Task RemoveEmailById(int id)
        {
            var emailModel = await GetEmailById(id);
            if (emailModel != null)
            {
                await _baseRepository.DeleteAsync(emailModel);
            }
        }

        public EmailDTO CreateEmailBody(string topicName, UserModel userModel, int codeValidation)
        {
            if (topicName != null)
            {
                if (topicName == "CodeValidation")
                {
                    EmailDTO email = new EmailDTO()
                    {
                        Subject = "Password Recovering",
                        Body = $@"
                        <!DOCTYPE html>
                        <html lang=""pt"">
                        <head>
                            <meta charset=""UTF-8"">
                            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                            <title>Password Recovering</title>
                        </head>
                        <body style=""font-family: Arial, sans-serif;"">

                            <h2>Password Recovering</h2>
                            <p>Dear {userModel.Name},</p>

                            <p>We're sorry to know you're having trouble accessing your account. To retrieve your access fully, please enter the following verification code:</p>

                            <div style=""padding: 10px; background-color: #f2f2f2; border-radius: 5px; font-size: 18px; font-weight: bold; text-align: center;"">
                                {codeValidation}
                            </div>  

                            <p>This code is valid for a limited time. Please do not share it with anyone for security reasons.</p>

                            <p>If you did not attempt to retrieve your password, please contact us as soon as possible to verify the circumstances of a possible breach.</p>

                            <p>Best Regards, <br>Só Carrinhos</p>

                        </body>
                        </html>
                        "
                    };
                    return email;
                }
                else if (topicName == "Registration")
                {
                    EmailDTO email = new EmailDTO()
                    {
                        Body = "Body",
                        Subject = "Subject"
                    };
                    return email;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }


    }
}
