using HrProject.Enums;
using HrProject.UI.Areas.Admin.Models;
using HrProject.UI.Areas.Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mail;
using X.PagedList;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace HrProject.UI.Areas.Admin.Controllers
{
    
    public class AdminController : Controller
    {
        private string baseUrl = "https://hrprojectapi20230602002601.azurewebsites.net/api/";
        private readonly IHostingEnvironment _env;

        public AdminController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CompanyCreate()
        {
            CreateCompanyModel createCompany = new();
            return View(createCompany);
        }
        [HttpGet]
        public async Task<IActionResult> CompanyList(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            HttpClient client = new HttpClient();
            List<CompanyDTO> companyList = new List<CompanyDTO>();
            var response = await client.GetAsync(baseUrl + "Admin/CompanyList");
            var json = await response.Content.ReadAsStringAsync();
            companyList = JsonConvert.DeserializeObject<List<CompanyDTO>>(json);
            IPagedList<CompanyDTO> pagedCompany = companyList.ToPagedList(pageNumber, pageSize);
            return View(pagedCompany);
        }
        [HttpGet]
        public IActionResult CreateCompanyManager()
        {
            var genderEnumValues =Enum.GetValues(typeof(Gender)).Cast<Gender>();
            TempData["genderEnumTypes"] = genderEnumValues;
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateCompanyManager(CreateCompanyModel companyModel)
        //{
        //    if (companyModel.ImageFile == null)
        //    {
        //        return View(companyModel);
        //    }
        //    string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
        //    string ImagePath = Guid.NewGuid().ToString() + "_" + companyModel.ImageFile.FileName;
        //    string filePath = Path.Combine(uploadsFolder, ImagePath);
        //    using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //    {
        //        await companyModel.ImageFile.CopyToAsync(fs);
        //    }

        //    companyModel.LogoImage = "/images/" + ImagePath;

        //    using (var client = new HttpClient())
        //    {
        //        var putTask = client.PutAsJsonAsync<CreateCompanyModel>(baseUrl + $"Company/CreateCompany", companyModel);
        //        putTask.Wait();
        //        var response = putTask.Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return View(companyModel);
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> CreateCompanyManager(CompanyManagerModel companyManagerModel)
        {
            Guid guid = Guid.NewGuid();
            companyManagerModel.Password = guid.ToString().Substring(0, 8);
            companyManagerModel.CompanyID = 1;
            companyManagerModel.JobID = 1;
            companyManagerModel.DepartmentID = 1;
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.PostAsJsonAsync<CompanyManagerModel>("Admin/CreateCompanyManager", companyManagerModel);
                    response.Wait();
                    var result = response.Result;
                    //SendMail(companyManagerModel);
                    if (result.IsSuccessStatusCode)
                    {
                        SendMail(companyManagerModel);
                        return RedirectToAction("CompanyList", "Admin", new { area = "Admin" });
                    }
                    else
                    {
                        return View();
                    }
                }

            }
            else
            {
                ModelState.AddModelError("", "Geçersiz e-mail adresi.");
            }
            return View();
        }
        private void SendMail(CompanyManagerModel companyManagerModel)
        {
            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("ucsilahsorlerburger@gmail.com");
            mesaj.To.Add($"{companyManagerModel.Email}");
            mesaj.Subject = "Hesabınız Oluşturuldu";
            mesaj.Body = $"Hesabınız oluşturuldu.\nGirriş Bilgileriniz.\nMail Adresiniz={companyManagerModel.Email}\nŞifreniz={companyManagerModel.Password}";

            SmtpClient a = new SmtpClient();
            a.Credentials = new System.Net.NetworkCredential("ucsilahsorlerburger@gmail.com", "yklotyvbjbspykrg");
            a.Port = 587;
            a.Host = "smtp.gmail.com";
            a.EnableSsl = true;
            //object userState = mesaj;
            a.Send(mesaj);
            //a.SendAsync(mesaj, userState);
        }

    }
}
