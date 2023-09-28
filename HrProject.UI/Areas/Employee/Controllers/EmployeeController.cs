using Firebase.Auth;
using Firebase.Storage;
using HrProject.UI.Areas.Employee.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace HrProject.UI.Areas.Employee.Controllers
{
    [Authorize(Roles = "Çalışan")]
    public class EmployeeController : Controller
    {
        private readonly IHostingEnvironment _env;
        private string baseUrl = "https://hrprojectapi20230602002601.azurewebsites.net/api/";
        private static string apiKey = "AIzaSyBvPaiBRRjQWd1QALDrjZ9k9LblahTCijM";
        private static string Bucket = "hrproject-f84f0.appspot.com";
        private static string AuthEmail = "ucsilahsorlerburger@gmail.com";
        private static string AuthPassword = "123Qwe**";
        private int id;
        public EmployeeController(IHostingEnvironment env)
        {
            _env = env;
            
        }

        public async Task<IActionResult> Index()
        {
            id = getEmployeeId();
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(baseUrl + $"Personel/GetEmployee/{id}");

            var json = await response.Content.ReadAsStringAsync();

            EmployeeListModel employee =
                JsonConvert.DeserializeObject<EmployeeListModel>(json);
            #region Get Employee's Job-Department-Company Name
            var responseJob = await client.GetAsync(baseUrl + $"Job/GetJob/{employee.JobID}");

            var jsonJob = await responseJob.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel jobName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonJob);

            var responseDepartment = await client.GetAsync(baseUrl + $"Department/GetDepartment/{employee.DepartmentID}");

            var jsonDepartment = await responseDepartment.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel departmentName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonDepartment);

            var responseCompany = await client.GetAsync(baseUrl + $"Company/GetCompany/{employee.CompanyID}");

            var jsonCompany = await responseCompany.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel totalName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonCompany);

            totalName.jobName = jobName.jobName;
            totalName.departmentName = departmentName.departmentName;
            TempData["myObject"] = totalName;
            #endregion
            return View(employee);
        }
        public async Task<IActionResult> Details()
        {
            id = getEmployeeId();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(baseUrl + $"Personel/GetDetailEmployee/{id}");

            var json = await response.Content.ReadAsStringAsync();

            EmployeeListModel employee =
                JsonConvert.DeserializeObject<EmployeeListModel>(json);
            #region Get Employee's Job-Department-Company Name
            var responseJob = await client.GetAsync(baseUrl + $"Job/GetJob/{employee.JobID}");

            var jsonJob = await responseJob.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel jobName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonJob);

            var responseDepartment = await client.GetAsync(baseUrl + $"Department/GetDepartment/{employee.DepartmentID}");

            var jsonDepartment = await responseDepartment.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel departmentName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonDepartment);

            var responseCompany = await client.GetAsync(baseUrl + $"Company/GetCompany/{employee.CompanyID}");

            var jsonCompany = await responseCompany.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel totalName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonCompany);

            totalName.jobName = jobName.jobName;
            totalName.departmentName = departmentName.departmentName;
            TempData["myObject"] = totalName;
            #endregion
            return View(employee);
        }
        public async Task<IActionResult> Edit()
        {
            id = getEmployeeId();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(baseUrl + $"Personel/GetEmployee/{id}");

            var json = await response.Content.ReadAsStringAsync();

            EmployeeUpdateModel employee =
                JsonConvert.DeserializeObject<EmployeeUpdateModel>(json);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeUpdateModel employee)
        {

            if (employee.ImageFile == null)
            {
                return View(employee);
            }
            string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
            string ImagePath = Guid.NewGuid().ToString() + "_" + employee.ImageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, ImagePath);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                await employee.ImageFile.CopyToAsync(fs);
            }


            employee.EmployeeImage = "/images/"+ImagePath;
            using (var client = new HttpClient())
            {
                var putTask = client.PutAsJsonAsync<EmployeeUpdateModel>(baseUrl + $"Personel/UpdateEmployee/{employee.ID}", employee);
                putTask.Wait();
                var response = putTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(employee);
            }


        }
        private int getEmployeeId()
        {
            var identites = User.Identities.First();
            var claims = identites.Claims;
            int id = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Equals("ID")).Value);
            return id;
        }
        //private async Task<string> UploadFile(EmployeeUpdateModel employeeUpdateModel)
        //{
        //    var fileupload = employeeUpdateModel.ImageFile;
        //    string uploadsFolder = null;
        //    string ImagePath = null;
        //    string filePath = null;
        //    FileStream fs = null;

        //    if (fileupload.Length > 0)
        //    {
        //        uploadsFolder = Path.Combine(_env.WebRootPath, "images");
        //        ImagePath = Guid.NewGuid().ToString() + "_" + employeeUpdateModel.ImageFile.FileName;
        //        filePath = Path.Combine(uploadsFolder, ImagePath);

        //        fs = new FileStream(filePath, FileMode.Create);
        //        await employeeUpdateModel.ImageFile.CopyToAsync(fs);


        //        //firebase uploading stuffs
        //        var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
        //        var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

        //        //Cancellation token
        //        var cancellation = new CancellationTokenSource();
        //        var task = new FirebaseStorage(
        //            Bucket,
        //            new FirebaseStorageOptions
        //            {
        //                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
        //                ThrowOnCancel = true

        //            }).Child("recipts").Child($"{fileupload.FileName}.{Path.GetExtension(fileupload.FileName).Substring(1)}")
        //            .PutAsync(fs, cancellation.Token);
        //        var link = await task;
        //        return link;
        //    }
        //    string bad = string.Empty;
        //    return bad;

        //}
    }
}
