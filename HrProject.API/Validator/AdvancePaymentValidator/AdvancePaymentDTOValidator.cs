using FluentValidation;
using HrProject.DTOs.CreateDTO;
using HrProject.DTOs.DTOs;

namespace HrProject.API.Validator.AdvancePaymentValidator
{
    public class AdvancePaymentDTOValidator : AbstractValidator<AdvancePaymentDTO>
    {
        public AdvancePaymentDTOValidator() 
        {
            RuleFor(x=>x.Type).NotEmpty();
            RuleFor(x=>x.Amount).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}
