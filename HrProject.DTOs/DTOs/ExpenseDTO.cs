using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DTOs.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public ExpenseType Type { get; set; } = ExpenseType.Accommodation;
        public Currency Currency { get; set; } = Currency.TurkLirasi;
        public Status Status { get; set; } = Status.Pending;
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? ReplyDate { get; set; } = null;
        public string ExpenseImage { get; set; }
        public int AppUserID { get; set; }
    }
}
