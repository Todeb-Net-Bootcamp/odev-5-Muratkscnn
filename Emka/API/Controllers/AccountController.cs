using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Validator.FluentValidation;
using DTO;
using Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace News.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IJwtAuthenticationService _jWT;
        private IPersonelService _personelService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtAuthenticationService jWT, IPersonelService personelService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jWT = jWT;
            _personelService = personelService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            var validator = new LoginRequestValidator();
            validator.Validate(model).ThrowIfException();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
                var userToken = _jWT.Authenticate(user.Id.ToString());
                return Ok(new { token=userToken});
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            var validator = new RegisterRequestValidator();
            validator.Validate(model).ThrowIfException();
            var appUser = new AppUser()
            {
                Personel = new Personel()
                {
                    Name = model.Name,
                    Code = model.Code,
                    Adress = model.Adress,
                    Gender = model.Gender,
                    AvatarUrl = model.AvatarUrl,
                    CreatedTime=DateTime.Now,
                    Department=model.Department,
                    Pozition=model.Pozition,
                    Lisans=model.Lisans
                },
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                return Ok("Kayıt Başarılı");
            }
            return BadRequest();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            var userid = User.Claims.FirstOrDefault(x => x.Type == "id").Value;
            var user = await _userManager.FindByIdAsync(userid);
            var personel = await _personelService.GetById(user.PersonelId);
            var result = new UserInfoResponse
            {
                PersonelId = user.PersonelId,
                Code = personel.Code,
                Name = personel.Name,
                Username = user.UserName,
                Email = user.Email,
                Adress = personel.Adress,
                Gender = personel.Gender,
                AvatarUrl = personel.AvatarUrl,
                CreatedTime = personel.CreatedTime,
                Department = personel.Department,
                Pozition = personel.Pozition,
                Lisans = personel.Lisans,
                PhoneNumber = user.PhoneNumber
            };
            return Ok(result);

        }

       
    }
}
