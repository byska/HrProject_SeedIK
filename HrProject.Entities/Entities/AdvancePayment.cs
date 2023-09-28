using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Entities.Entities
{
    public class AdvancePayment: BaseEntity
    {
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public AdvancePaymentType Type { get; set; } = AdvancePaymentType.Personal;
        public Status Status { get; set; } = Status.Pending;
        public DateTime? ReplyDate { get; set; } = null;
        public double Amount { get; set; }
        public Currency Currency { get; set; } = Currency.TurkLirasi;
        public string Description { get; set; } = string.Empty;
        public AppUser AppUser { get; set; }
        public int AppUserID { get; set; }
    }
}
