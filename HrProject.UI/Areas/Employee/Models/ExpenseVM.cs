using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrProject.UI.Areas.Employee.Models
{
    public class ExpenseVM
    {
        public ExpenseVM()
        {
            Expenses = new List<Expense>();
            ExpenseType = new List<SelectListItem>();
        }
        public string Expense { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<SelectListItem> ExpenseType { get; set; }   
    }
}
