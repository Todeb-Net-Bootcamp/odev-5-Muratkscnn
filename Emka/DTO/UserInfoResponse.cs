using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    
        public class UserInfoResponse
        {
            public int PersonelId { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }
            public string Gender { get; set; }
            public string AvatarUrl { get; set; }
            public DateTime CreatedTime { get; set; }
            public string Department { get; set; }
            public string Pozition { get; set; }
            public string Lisans { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
        }
}
