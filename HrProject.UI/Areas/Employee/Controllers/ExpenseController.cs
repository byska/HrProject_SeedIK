using HrProject.Enums;
using HrProject.UI.Areas.Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Reflection;

namespace HrProject.UI.Areas.Employee.Controllers
{
    public class ExpenseController : Controller
    {
        private string baseUrl = "https://hrprojectapi20230602002601.azurewebsites.net/api/";
        // GET: ExpenseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExpenseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ExpenseList()
        {
            ExpenseVM expenseVM = new ExpenseVM();
            HttpClient client = new HttpClient();
            string[] types =Enum.GetNames(typeof(ExpenseType));
            foreach (var item in types)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = item,
                    Value = item
                };
                expenseVM.ExpenseType.Add(selectListItem);
            }
            return View(expenseVM);
        }
        [HttpPost]
        public async Task<IActionResult> ExpenseList(string type,string? status)
        {
            ExpenseVM expenseVM =new ExpenseVM();
            HttpClient client = new HttpClient();
            int id = getEmployeeId();
            string[] types = Enum.GetNames(typeof(ExpenseType));
            foreach (var item in types)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = item,
                    Value = item
                };
                expenseVM.ExpenseType.Add(selectListItem);
            }
            string uri = null;
            if(type == ExpenseType.Trip.ToString())
            {
                if (status=="null")
                {
                    uri = baseUrl + $"Expense/ExpenseTripList?Id={id}";
                }
                else
                {
                    uri = baseUrl + $"Expense/ExpenseTripList?Status={status}&Id={id}";
                }
                var response = await client.GetAsync(uri);
                var json=await response.Content.ReadAsStringAsync();
                expenseVM.Expenses = JsonConvert.DeserializeObject<List<Expense>>(json);
                return View(expenseVM);
            }
            else if(type==ExpenseType.Accommodation.ToString())
            {
                if (status == "null")
                {
                    uri = baseUrl + $"Expense/ExpenseAccomodationList?Id={id}";
                }
                else
                {
                    uri = baseUrl + $"Expense/ExpenseAccomodationList?Status={status}&Id={id}";
                }
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                expenseVM.Expenses = JsonConvert.DeserializeObject<List<Expense>>(json);
                return View(expenseVM);
            }
            else
            {
                if (status == "null")
                {
                    uri = baseUrl + $"Expense/ExpenseFoodAndBeverageList?Id={id}";
                }
                else
                {
                    uri = baseUrl + $"Expense/ExpenseFoodAndBeverageList?Status={status}&Id={id}";
                }
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                expenseVM.Expenses = JsonConvert.DeserializeObject<List<Expense>>(json);
                return View(expenseVM);
            }
        }
        // GET: ExpenseController/Create
        public async Task<IActionResult> CreateExpense()
        {
            using (var client = new HttpClient())
            {              
                Expense expense = new Expense();
                var expenseEnumValues = Enum.GetValues(typeof(ExpenseType)).Cast<ExpenseType>();
                var expenseTypes = expenseEnumValues.Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                });
                var currencyEnumValues = Enum.GetValues(typeof(Currency)).Cast<Currency>();
                return View(expense);
            }
        }

        // POST: ExpenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    var response = client.PostAsJsonAsync("Expense/CreateExpense", expense);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(expense);
                    }
                }
            }
            else
            {
                return View(expense);
            }
        }

        // GET: ExpenseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpenseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpenseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExpenseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
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
