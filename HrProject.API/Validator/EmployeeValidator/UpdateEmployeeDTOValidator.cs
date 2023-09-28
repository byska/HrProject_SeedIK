using FluentValidation;
using HrProject.DTOs.UpdateDTO;

namespace HrProject.API.Validator.EmployeeValidator
{
    public class UpdateEmployeeDTOValidator : AbstractValidator<UpdateEmployeeDTO>
    {
        public UpdateEmployeeDTOValidator() 
        { 
            RuleFor(x=>x.Address).NotEmpty().MaximumLength(100);
            RuleFor(x=>x.PhoneNumber).NotEmpty().Length(11);
            RuleFor(x => x.EmployeeImage).Must(ContainJpegOrPng).WithMessage("Sadece Jpeg ve Png formatlı fotoğraflar kabul ediyoruz.");

        }

        private bool ContainJpegOrPng(string value)
        {
            return value.Contains(".jpeg") || value.Contains(".png");
        }
    }
}
