using AutoMapper;
using DTO;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private RoleManager<AppRole> _roleManager;

        public RoleController(IMapper mapper, RoleManager<AppRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleRequest entity)
        {

            var mappedEntity = _mapper.Map<AppRole>(entity);
            var value=await _roleManager.CreateAsync(mappedEntity);
            if (!value.Succeeded)
            {
                return BadRequest("Rol Ekleme Tamamlanamadı.");
            }
            return Ok($"{entity.Name} Rol olarak Eklendi");
        }
        [HttpGet]
        public async Task<IActionResult> GetRoleList()
        {
            return Ok(_roleManager.Roles.ToList());
        }
    }
}
