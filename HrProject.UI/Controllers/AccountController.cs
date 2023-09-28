using HrProject.UI.Areas.Employee.Models;
using HrProject.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HrProject.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private string baseUrl = "https://hrprojectapi20230602002601.azurewebsites.net/api/";

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            UserSignInModel userSignInModel = new UserSignInModel();
            return View(userSignInModel);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInModel userSignInModel)
        {
            
            if (ModelState.IsValid)
            {
                using HttpClient client = new HttpClient();
                {
                    var myContent = JsonConvert.SerializeObject(userSignInModel);
                    var stringContent = new StringContent(myContent, UnicodeEncoding.UTF8, "application/json");
                    var response = await client.PostAsync(baseUrl + "Account/SignIn", stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var jwt = await response.Content.ReadAsStringAsync();
                        if (jwt != null)
                        {
                            JwtSecurityTokenHandler handler = new();

                            var token = handler.ReadJwtToken(jwt);

                            var claimsIdentity = new ClaimsIdentity(token.Claims, JwtBearerDefaults.AuthenticationScheme);

                            var authProps = new AuthenticationProperties
                            {
                                IsPersistent = true,
                            };
                            await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                            return RedirectToAction("Index", "Employee", new { area = "Employee" });
                        }


                        
                    }



                }
            }
            return View(userSignInModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Account/SignIn");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}