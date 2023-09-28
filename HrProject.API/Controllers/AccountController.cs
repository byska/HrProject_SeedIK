using HrProject.API.JwtTools;
using HrProject.Business.Abstract;
using HrProject.DTOs;
using HrProject.DTOs.CreateDTO;
using HrProject.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections;

namespace HrProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IGenericService<AppUser> _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(IGenericService<AppUser> userService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInDTO userSignInDTO)
        {
            AppUser user = await _userService.GetByDefault(x => x.Email.Equals(userSignInDTO.Email));
            userSignInDTO.Gender = user.Gender;
            userSignInDTO.ID = user.Id;
            TimeSpan workDate = DateTime.Now - user.StartDate;
            int workYear = Convert.ToInt32(workDate.TotalDays / 365);
            userSignInDTO.WorkingYear = workYear;
            var roleList= await _userManager.GetRolesAsync(user);

            var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, userSignInDTO.Password, userSignInDTO.RememberMe, false);
            if (signInResult.Succeeded)
            {
                var token = JwtTokenGenerator.GenerateToken(userSignInDTO, roleList);
                return Ok(token);
            }
            return BadRequest(userSignInDTO);

        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO createUser)
        {
            AppUser user = new AppUser()
            {
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email,
                UserName = createUser.Username,
                Gender = createUser.Gender,
                Address = "Ümraniye",
                BirthPlace = "Bursa",
                TC= "23290516402",
                BirthDate = DateTime.Now,
                JobID = 1,
                DepartmentID= 1,
                CompanyID= 1,
                Salary = 20000,
                IsActive = true,
                EmployeeImage = "asdas"

            };
            var identityResult = await _userManager.CreateAsync(user, createUser.Password);
            if (identityResult.Succeeded)
            {
                return Ok();
            }
            return BadRequest(identityResult);
            
        }
    }
}
