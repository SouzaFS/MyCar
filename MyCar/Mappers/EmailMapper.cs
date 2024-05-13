using MyCar.DTOs;
using MyCar.Models;
using System.Collections.Generic;

namespace MyCar.Mappers
{
    public class EmailMapper
    {
        public static EmailDTO FromModelToDTO(EmailModel emailModel)
        {
            return new EmailDTO()
            {
                Subject = emailModel.Subject,
                Body = emailModel.Body,
                Receiver = emailModel.Receiver,
                CodeValidation = emailModel.CodeValidation
            };
        }

        public static EmailModel FromDTOToModel(EmailDTO emailDTO)
        {
            return new EmailModel()
            {
                Subject = emailDTO.Subject,
                Body = emailDTO.Body,
                Receiver = emailDTO.Receiver,
                CodeValidation = emailDTO.CodeValidation
            };
        }

        public static List<EmailDTO> FromModelToDTOList(List<EmailModel> emailModelList)
        {
            var emailDTOList = new List<EmailDTO>();

            foreach (var item in emailModelList)
                emailDTOList.Add(FromModelToDTO(item));

            return emailDTOList;
        }
    }
}
