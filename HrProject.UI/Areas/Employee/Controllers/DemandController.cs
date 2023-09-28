using HrProject.Enums;
using HrProject.UI.Areas.Employee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using X.PagedList;
using System.Security.Claims;
using System.Collections.Generic;

namespace HrProject.UI.Areas.Employee.Controllers
{
    [Authorize(Roles = "Çalışan")]
    public class DemandController : Controller
    {
        private string baseUrl = "https://hrprojectapi20230602002601.azurewebsites.net/api/";
        private readonly IHostingEnvironment _env;
        public DemandController(IHostingEnvironment env)
        {
            _env= env;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PermissionList(string permissionStatus, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            List<PermissionModel> permissions;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(baseUrl + "Demand/GetPermissionsByStatus");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var done = result.Content.ReadFromJsonAsync<List<PermissionModel>>();
                    done.Wait();
                    permissions = done.Result;
                    if (!string.IsNullOrEmpty(permissionStatus))
                    {
                        permissions = permissions.Where(x => x.Status.ToString() == permissionStatus).OrderBy(x => x.RequestDate).ToList();
                    }
                    IPagedList<PermissionModel> pagedPermissions = permissions.ToPagedList(pageNumber, pageSize);
                    return View(pagedPermissions);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        public async Task<IActionResult> ConfirmedPermissionList(string permissionStatus, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            List<PermissionModel> permissions;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl + $"Demand/GetPermissionsByStatus");
                if (response.IsSuccessStatusCode)
                {
                    var done = await response.Content.ReadFromJsonAsync<List<PermissionModel>>();
                    permissions = done;
                    permissions = permissions.Where(x => x.Status == Status.Confirm).OrderBy(x => x.RequestDate).ToList();
                    //if (!string.IsNullOrEmpty(permissionStatus) && permissionStatus == Status.Confirm.ToString())
                    //{
                    //    permissions = permissions.Where(x => x.Status == Status.Confirm).OrderBy(x => x.RequestDate).ToList();
                    //}
                    //else
                    //{
                    //    return BadRequest();
                    //}

                    IPagedList<PermissionModel> pagedPermissions = permissions.ToPagedList(pageNumber, pageSize);
                    return View(pagedPermissions);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        //public async Task<IActionResult> ConfirmedPermissionList(string permissionStatus, int? page)
        //{
        //    int pageNumber = page ?? 1;
        //    int pageSize = 5;
        //    List<PermissionModel> permissions;
        //    using (var client = new HttpClient())
        //    {
        //        var response = client.GetAsync(baseUrl + "Demand/GetPermissionsByStatus");
        //        response.Wait();
        //        var result = response.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var done = result.Content.ReadFromJsonAsync<List<PermissionModel>>();
        //            done.Wait();
        //            permissions = done.Result;
        //            if (permissionStatus != null)
        //            {
        //                if (permissionStatus == Status.Confirm.ToString())
        //                {
        //                    permissions = permissions.Where(x => x.Status == Status.Confirm).OrderBy(x => x.RequestDate).ToList();
        //                }

        //                else return BadRequest();
        //            }
        //            IPagedList<PermissionModel> pagedPermissions = permissions.ToPagedList(pageNumber, pageSize);
        //            return View(pagedPermissions);
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //}
        public async Task<IActionResult> PendingPermissionList(string permissionStatus, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            List<PermissionModel> permissions;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(baseUrl + "Demand/GetPermissionsByStatus");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var done = result.Content.ReadFromJsonAsync<List<PermissionModel>>();
                    done.Wait();
                    permissions = done.Result;
                    permissions = permissions.Where(x => x.Status == Status.Pending).OrderBy(x => x.RequestDate).ToList();
                    if (permissionStatus != null)
                    {
                        if (permissionStatus == Status.Pending.ToString())
                        {
                            permissions = permissions.Where(x => x.Status == Status.Pending).OrderBy(x => x.RequestDate).ToList();
                        }

                        else return BadRequest();
                    }
                    IPagedList<PermissionModel> pagedPermissions = permissions.ToPagedList(pageNumber, pageSize);
                    return View(pagedPermissions);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        public async Task<IActionResult> DeniedPermissionList(string permissionStatus, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 5;
            List<PermissionModel> permissions;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(baseUrl + "Demand/GetPermissionsByStatus");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var done = result.Content.ReadFromJsonAsync<List<PermissionModel>>();
                    done.Wait();
                    permissions = done.Result;
                    permissions = permissions.Where(x => x.Status == Status.Denied).OrderBy(x => x.RequestDate).ToList();
                    if (permissionStatus != null)
                    {
                        if (permissionStatus == Status.Denied.ToString())
                        {
                            permissions = permissions.Where(x => x.Status == Status.Denied).OrderBy(x => x.RequestDate).ToList();
                        }

                        else return BadRequest();
                    }
                    IPagedList<PermissionModel> pagedPermissions = permissions.ToPagedList(pageNumber, pageSize);
                    return View(pagedPermissions);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        public async Task<ActionResult> IsRequired(string PermissionType)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"Demand/GetPermissionTypeBool/{PermissionType}");
            var json = await response.Content.ReadAsStringAsync();
            bool IsFileRequired = JsonConvert.DeserializeObject<bool>(json);
            return Json(IsFileRequired);

        }
        public async Task<IActionResult> CreatePermission()
        {
            PermissionVM permissionVM = new PermissionVM();
            using (var client = new HttpClient())
            {
                var gender = getGenderType();
                int workyear = 1;/*getWorkingYear();*/
                var response = await client.GetAsync(baseUrl + "Demand/GetPermissionType");
                var json = await response.Content.ReadAsStringAsync();
                List<PermissionType> permissionTypeList = JsonConvert.DeserializeObject<List<PermissionType>>(json);
                DateTime dateTime = DateTime.Now;
                ViewBag.DateTime = dateTime.ToString("yyyy-MM-dd");
                List<PermissionType> permissionTypeListByGender;
              
                if (gender == "Female")
                {
                    permissionTypeListByGender = permissionTypeList.Where(x => x.Gender.Equals(Gender.All) || x.Gender.Equals(Gender.Female)).ToList();
                }
                else
                {
                    permissionTypeListByGender = permissionTypeList.Where(x => x.Gender.Equals(Gender.All) || x.Gender.Equals(Gender.Male)).ToList();
                }

                if (workyear < 1)
                {
                    permissionTypeListByGender.RemoveAt(0);
                    permissionTypeListByGender.RemoveAt(0);
                    permissionTypeListByGender.RemoveAt(0);
                }
                else if (workyear >= 1 && workyear <= 5)
                {
                    permissionTypeListByGender.RemoveAt(0);
                    permissionTypeListByGender.RemoveAt(1);
                }
                else
                {
                    permissionTypeListByGender.RemoveAt(0);
                    permissionTypeListByGender.RemoveAt(0);
                }
                foreach (var item in permissionTypeListByGender)
                {
                    SelectListItem selectListItem = new SelectListItem
                    {
                        Text = item.PermissionName,
                        Value = item.ID.ToString()
                    };
                    permissionVM.PermissionTypeDropDown.Add(selectListItem);
                }
            }
            return View(permissionVM);
        }
        [HttpPost]
        public IActionResult CreatePermission(PermissionVM model)
        {
            if (model.Permission.SelectFile == null)
            {
                return View(model);
            }            
            string uploadsFolder = Path.Combine(_env.WebRootPath, "Files");
            string fileName = Guid.NewGuid().ToString() + "_" + model.Permission.SelectFile.FileName;
            string filePath = Path.Combine(uploadsFolder, fileName);
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                var response = model.Permission.SelectFile.CopyToAsync(fs);
                response.Wait();
            }
            model.Permission.AppUserID = getEmployeeId();    
            model.Permission.TypeID= 2;
            model.Permission.File = "/Files/" + fileName;
            if (model.Permission.File!=null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.PostAsJsonAsync<PermissionModel>("Demand/CreatePermission", model.Permission);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("PermissionList", "Demand", new { area = "Employee" });
                    }
                    else
                    {
                        return View(model);
                    }

                }

            }
            else
            {
                return View(model);
            }
        }
        private int getEmployeeId()
        {
            var identites = User.Identities.First();
            var claims = identites.Claims;
            int id = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Equals("ID")).Value);
            return id;
        }
        private string getGenderType()
        {
            var identites = User.Identities.First();
            var claims = identites.Claims;
            string gender = claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Gender)).Value;
            return gender;
        }
        private int getWorkingYear()
        {
            var identites = User.Identities.First();
            var claims = identites.Claims;
            int workYear = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Equals("WorkingYear")).Value);
            return workYear;
        }
    }
}
