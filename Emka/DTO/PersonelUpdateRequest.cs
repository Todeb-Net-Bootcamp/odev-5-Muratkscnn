using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PersonelUpdateRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }
        public string AvatarUrl { get; set; }
        public string Department { get; set; }
        public string Pozition { get; set; }
        public string Lisans { get; set; }

    }
}
