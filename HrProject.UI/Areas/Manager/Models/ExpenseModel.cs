using HrProject.Enums;

namespace HrProject.UI.Areas.Manager.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public ExpenseType Type { get; set; } = ExpenseType.Accommodation;
        public Currency Currency { get; set; } = Currency.TurkLirasi;
        public Status Status { get; set; } = Status.Pending;
        public double Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string ExpenseImage { get; set; }
        public int AppUserID { get; set; }
        public string? EmployeeName { get; set; }
    }
}
