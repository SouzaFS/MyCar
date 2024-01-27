using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCar.Models
{
    public class UserRegisterModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CPF { get; set; }
        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public virtual UserModel UserModel { get; set; }
        public string FacePhoto { get; set; }
        public string DocumentPhoto { get; set; }
    }
}
