using HrProject.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrProject.UI.Areas.Employee.Models
{
    public class AdvancePaymentModel
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public AdvancePaymentType Type { get; set; } = AdvancePaymentType.Personal;
        public Status Status { get; set; } = Status.Pending;
        public DateTime? ReplyDate { get; set; } = null;
        public double Amount { get; set; }
        public Currency Currency { get; set; } = Currency.TurkLirasi;
        public string Description { get; set; } = string.Empty;
    }
}
