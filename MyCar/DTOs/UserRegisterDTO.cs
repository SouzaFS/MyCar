using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.DTOs
{
    public class UserRegisterDTO
    {
        public string CPF { get; set; }
        public int UserId { get; set; }
        public string FacePhoto { get; set; }
        public string DocumentPhoto { get; set; }
    }
}
