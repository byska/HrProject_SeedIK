using Firebase.Auth;
using Firebase.Storage;
using HrProject.Enums;
using HrProject.UI.Areas.Manager.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http.Json;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using X.PagedList;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace HrProject.UI.Areas.Manager.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IHostingEnvironment _env;
        private string baseUrl = "https://hrprojectapi20230602002601.azurewebsites.net/api/";
        private static string apiKey = "AIzaSyBvPaiBRRjQWd1QALDrjZ9k9LblahTCijM";
        private static string Bucket = "hrproject-f84f0.appspot.com";
        private static string AuthEmail = "ucsilahsorlerburger@gmail.com";
        private static string AuthPassword = "123Qwe**";
        private int id;

        public ManagerController(IHostingEnvironment env)
        {
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            id = getManagerId();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(baseUrl + $"Manager/GetDetailManager/{id}");

            var json = await response.Content.ReadAsStringAsync();

            ManagerModel manager =
                JsonConvert.DeserializeObject<ManagerModel>(json);
            #region Get Employee's Job-Department-Company Name
            var responseJob = await client.GetAsync(baseUrl + $"Job/GetJob/{manager.JobID}");

            var jsonJob = await responseJob.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel jobName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonJob);

            var responseDepartment = await client.GetAsync(baseUrl + $"Department/GetDepartment/{manager.DepartmentID}");

            var jsonDepartment = await responseDepartment.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel departmentName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonDepartment);

            var responseCompany = await client.GetAsync(baseUrl + $"Company/GetCompany/{manager.CompanyID}");

            var jsonCompany = await responseCompany.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel totalName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonCompany);
            #endregion
            totalName.jobName = jobName.jobName;
            totalName.departmentName = departmentName.departmentName;
            TempData["myObject"] = totalName;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using (var client = new HttpClient())
            {
                
                ManagerModel manager = new ManagerModel();
                var genderEnumValues = Enum.GetValues(typeof(Gender)).Cast<Gender>();
                var genders = genderEnumValues.Select(g => new SelectListItem
                {
                    Value = g.ToString(),
                    Text = g.ToString()
                });
                ViewData["Genders"] = genders;
                return View(manager);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,SecondFirstName,LastName,SecondLastName,BirthDate,BirthPlace,TC,StartDate,DismissalDate,JobID,DepartmentID,CompanyID,Email,Address,Salary,IsActive,Gender")] ManagerModel manager)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = await client.PostAsJsonAsync("Manager/CreateManager", manager);
                    var result =response;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(manager);
                    }
                }
            }
            else
            {
                return View(manager);
            }
        }
        public async Task<IActionResult> ManagerDetails()
        {
            id = getManagerId();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(baseUrl + $"Manager/GetDetailManager/{id}");

            var json = await response.Content.ReadAsStringAsync();

            ManagerModel manager =
                JsonConvert.DeserializeObject<ManagerModel>(json);
            #region Get Employee's Job-Department-Company Name
            var responseJob = await client.GetAsync(baseUrl + $"Job/GetJob/{manager.JobID}");

            var jsonJob = await responseJob.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel jobName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonJob);

            var responseDepartment = await client.GetAsync(baseUrl + $"Department/GetDepartment/{manager.DepartmentID}");

            var jsonDepartment = await responseDepartment.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel departmentName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonDepartment);

            var responseCompany = await client.GetAsync(baseUrl + $"Company/GetCompany/{manager.CompanyID}");

            var jsonCompany = await responseCompany.Content.ReadAsStringAsync();

            Job_Department_Company_NameModel totalName =
                JsonConvert.DeserializeObject<Job_Department_Company_NameModel>(jsonCompany);

            totalName.jobName = jobName.jobName;
            totalName.departmentName = departmentName.departmentName;
            TempData["myObject"] = totalName;
            #endregion
            return View(manager);
        }

        public async Task<IActionResult> PermissionCheckList(string permissionStatus, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            List<ManagerPermissionModel> permissions;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl + "Demand/GetPermissionsByStatus");
                var json = await response.Content.ReadAsStringAsync();
                permissions = JsonConvert.DeserializeObject<List<ManagerPermissionModel>>(json);
                permissions = permissions.Where(x => x.Status.ToString() == permissionStatus).OrderBy(x => x.RequestDate).ToList();
                IPagedList<ManagerPermissionModel> pagedPermissions = permissions.ToPagedList(pageNumber, pageSize);
                var statusEnumValues = Enum.GetValues(typeof(Status)).Cast<Status>();
                TempData["statusTypes"] = statusEnumValues;
                return View(pagedPermissions);
            }
        }
        public async Task<IActionResult>ExpenseList(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            HttpClient client = new HttpClient();
            List<ExpenseModel> expenseList = new List<ExpenseModel>();
            var response = await client.GetAsync(baseUrl + "Expense/ExpenseList");
            var json = await response.Content.ReadAsStringAsync();
            expenseList = JsonConvert.DeserializeObject<List<ExpenseModel>>(json);
            IPagedList<ExpenseModel> pagedExpense = expenseList.ToPagedList(pageNumber, pageSize);
            var statusEnumValues = Enum.GetValues(typeof(Status)).Cast<Status>();
            TempData["statusTypes"] = statusEnumValues;
            return View(pagedExpense);
        }
        public async Task<IActionResult> AdvancePaymentCheckList(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            HttpClient client = new HttpClient();
            List<ManagerAdvancePaymentModel> advancePaymentList = new List<ManagerAdvancePaymentModel>();
            var response = await client.GetAsync(baseUrl + "Advance/AdvancePaymentPersonalList");
            var json = await response.Content.ReadAsStringAsync();
            advancePaymentList = JsonConvert.DeserializeObject<List<ManagerAdvancePaymentModel>>(json);
            IPagedList<ManagerAdvancePaymentModel> pagedAdvancePayment = advancePaymentList.ToPagedList(pageNumber, pageSize);
            var statusEnumValues = Enum.GetValues(typeof(Status)).Cast<Status>();
            TempData["statusTypes"] = statusEnumValues;
            return View(pagedAdvancePayment);
        }
        public async Task<IActionResult> ManagerEdit()
        {
            id = getManagerId();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(baseUrl + $"Manager/GetDetailManager/{id}");

            var json = await response.Content.ReadAsStringAsync();

            ManagerUpdateModel manager =
                JsonConvert.DeserializeObject<ManagerUpdateModel>(json);
            return View(manager);
        }

        [HttpPost]
        public async Task<IActionResult> ManagerEdit(ManagerUpdateModel manager)
        {

            if (manager.ImageFile == null)
            {
                return View(manager);
            }
            string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
            string ImagePath = Guid.NewGuid().ToString() + "_" + manager.ImageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, ImagePath);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                await manager.ImageFile.CopyToAsync(fs);
            }


            manager.ManagerImage = "/images/" + ImagePath;
            using (var client = new HttpClient())
            {
                var putTask = client.PutAsJsonAsync<ManagerUpdateModel>(baseUrl + $"Manager/UpdateManager/{manager.ID}", manager);
                putTask.Wait();
                var response = putTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(manager);
            }


        }


        private int getManagerId()
        {
            var identites = User.Identities.First();
            var claims = identites.Claims;
            int id = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Equals("ID")).Value);
            return id;
        }

        public async Task<IActionResult> EmployeeList(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            IEnumerable<ManagerListEmployeeDTO> employeeList =new List<ManagerListEmployeeDTO>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(baseUrl + "Manager/ListEmployee");
            var json= await response.Content.ReadAsStringAsync();
           employeeList=JsonConvert.DeserializeObject<List<ManagerListEmployeeDTO>>(json);
            IPagedList<ManagerListEmployeeDTO> pagedCompany = employeeList.ToPagedList(pageNumber, pageSize);
            return View(employeeList);

        }

    }
}
