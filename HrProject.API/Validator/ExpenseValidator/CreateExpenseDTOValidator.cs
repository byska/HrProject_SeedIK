using FluentValidation;
using HrProject.DTOs.CreateDTO;

namespace HrProject.API.Validator.ExpenseValidator
{
    public class CreateExpenseDTOValidator : AbstractValidator<CreateExpenseDTO>
    {
        public CreateExpenseDTOValidator()
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
