using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Entities.Entities
{
    public class Expense : BaseEntity
    {
        private const double MinimumAmount = 0;
        private const double MaximumAmount = 100000;
        public AppUser AppUser { get; set; }
        public int AppUserID { get; set; }
        public ExpenseType Type { get; set; } = ExpenseType.Accommodation;
        public Currency Currency { get; set; } = Currency.TurkLirasi;
        public Status Status { get; set; } = Status.Pending;

        private double amount;
        public double Amount
        {
            get { return amount; }
            set
            {
                if (value < MinimumAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(Amount), $"Amount cannot be less than {MinimumAmount}.");
                }

                if (value > MaximumAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(Amount), $"Amount cannot exceed {MaximumAmount}.");
                }

                amount = value;
            }
        }

        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime? ReplyDate { get; set; } = null;
        public string ExpenseImage { get; set; }
    }
}
