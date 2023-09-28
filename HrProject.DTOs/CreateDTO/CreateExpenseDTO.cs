using HrProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.DTOs.CreateDTO
{
    public class CreateExpenseDTO
    {
        private const double MinimumAmount = 0;
        private const double MaximumAmount = 100000;

        public int AppUserID { get; set; }
        public ExpenseType Type { get; set; } = ExpenseType.Accommodation;
        public Currency Currency { get; set; } = Currency.TurkLirasi;
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
        public string ExpenseImage { get; set; }

    }
}
