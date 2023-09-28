using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrProject.UI.Areas.Employee.Models
{
    public class AdvancePaymentVM
    {
        public List<AdvancePaymentModel> advancePayments { get; set; }
        public string advancePayment { get; set; }
        public List<SelectListItem> advancePaymentType { get; set; }
        public AdvancePaymentVM()
        {
            advancePayments = new List<AdvancePaymentModel>();
            advancePaymentType = new List<SelectListItem>();
        }
    }
}
