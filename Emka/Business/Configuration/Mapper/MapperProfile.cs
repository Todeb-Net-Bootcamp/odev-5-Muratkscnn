using AutoMapper;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<PersonelUpdateRequest, Personel>();
            CreateMap<AddRoleRequest, AppRole>();
        }
    }
}
