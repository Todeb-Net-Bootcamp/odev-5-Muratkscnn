using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RegisterRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }
        public string AvatarUrl { get; set; }
        public string Department { get; set; }
        public string Pozition { get; set; }
        public string Lisans { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
    }
}
