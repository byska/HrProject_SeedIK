using FluentValidation;
using HrProject.DTOs.DTOs;

namespace HrProject.API.Validator.ExpenseValidator
{
    public class ExpenseValidator : AbstractValidator<ExpenseDTO>
    {
        public ExpenseValidator()
        {
            RuleFor(x => x.Amount).InclusiveBetween(0, 10000);
            //RuleFor(x => x.ExpenseImage).NotEmpty().Must(ContainJpegOrPng);

        }
        private bool ContainJpegOrPng(string value)
        {
            return value.Contains(".jpeg") || value.Contains(".png");
        }
    }
}
