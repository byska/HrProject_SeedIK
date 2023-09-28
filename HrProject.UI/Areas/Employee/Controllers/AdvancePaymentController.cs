using HrProject.Enums;
using HrProject.UI.Areas.Employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;



namespace HrProject.UI.Areas.Employee.Controllers
{
    public class AdvancePaymentController : Controller
    {
        private string baseUrl = "https://hrprojectapi20230517153723.azurewebsites.net/api/";

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdvancePaymentList()
        {
            
            AdvancePaymentVM advancePaymentVM = new AdvancePaymentVM();
            HttpClient client = new HttpClient();
            string[] types = Enum.GetNames(typeof(AdvancePaymentType));
            foreach (var item in types)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = item,
                    Value = item
                };
                advancePaymentVM.advancePaymentType.Add(selectListItem);
            }
            return View(advancePaymentVM);
        }
        [HttpPost]
        public async Task<IActionResult> AdvancePaymentList(string type, string? status)
        {
            AdvancePaymentVM advancePaymentVM = new AdvancePaymentVM();
            HttpClient client = new HttpClient();
            int id = getEmployeeId();
            string[] types = Enum.GetNames(typeof(AdvancePaymentType));
            foreach (var item in types)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = item,
                    Value = item
                };
                advancePaymentVM.advancePaymentType.Add(selectListItem);
            }
            string uri = null;
            if (type == AdvancePaymentType.Personal.ToString())
            {
                
                if (status == "null")
                {
                    uri = baseUrl + $"Advance/AdvancePaymentPersonalList?Id={id}";
                }
                else
                {
                    uri = baseUrl + $"Advance/AdvancePaymentPersonalList?Status={status}&Id={id}";
                }
                
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                advancePaymentVM.advancePayments = JsonConvert.DeserializeObject<List<AdvancePaymentModel>>(json);
                return View(advancePaymentVM);



            }
            else
            {
                if (status == "null")
                {
                    uri = baseUrl + $"Advance/AdvancePaymentCorporativeFilter?Id={id}";

                }
                else
                {
                    uri = baseUrl + $"Advance/AdvancePaymentCorporativeFilter?Status={status}&Id={id}";
                }
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                advancePaymentVM.advancePayments = JsonConvert.DeserializeObject<List<AdvancePaymentModel>>(json);
                return View(advancePaymentVM);
            }
            
            
        }
        public async Task<IActionResult> CreateAdvancePayment()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseUrl + "Advance/CreateAdvancePayment");
                var json = await response.Content.ReadAsStringAsync();
                AdvancePaymentModel advancePaymentModel = JsonConvert.DeserializeObject<AdvancePaymentModel>(json);
                var advancePaymentEnumValues = Enum.GetValues(typeof(AdvancePaymentType)).Cast<AdvancePaymentType>();
                var currencyEnumValues = Enum.GetValues(typeof(Currency)).Cast<Currency>();



                TempData["advacePaymentTypes"] = advancePaymentEnumValues;
                TempData["currencyTypes"] = currencyEnumValues;
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateAdvancePayment(AdvancePaymentModel advancePaymentModel)
        {
            advancePaymentModel.AppUserID = getEmployeeId();
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.PostAsJsonAsync<AdvancePaymentModel>("Advance/CreateAdvancePayment", advancePaymentModel);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("AdvancePaymentList", "AdvancePayment", new { area = "Employee" });
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }
        private int getEmployeeId()
        {
            var identites = User.Identities.First();
            var claims = identites.Claims;
            int id = Convert.ToInt32(claims.FirstOrDefault(x => x.Type.Equals("ID")).Value);
            return id;
        }
    }
}