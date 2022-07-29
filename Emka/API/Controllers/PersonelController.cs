using AutoMapper;
using Business.Abstract;
using DTO;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService _personelService;
        private readonly IMapper _mapper;

        public PersonelController(IPersonelService personelService, IMapper mapper)
        {
            _personelService = personelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonelList()
        {
            var values = await _personelService.GetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonel(int id)
        {
            var value = await _personelService.GetById(id);
            return Ok(value);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonelDetail(int id, PersonelUpdateRequest model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var mappedEntity = _mapper.Map<Personel>(model);
            mappedEntity.PersonelId = id;
            await _personelService.Update(mappedEntity);
            return Ok(mappedEntity);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonel(int id)
        {
            var value = await _personelService.GetById(id);
            await _personelService.Delete(value);
            return Ok("Silme İşlemi başarı ile tamamlandı");
        }
    }
}
