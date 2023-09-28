using FluentValidation;
using HrProject.DTOs.CreateDTO;

namespace HrProject.API.Validator.EmployeeValidator
{
    public class CreatePermissionDTOValidator:AbstractValidator<CreatePermissionDTO>
    {
        public CreatePermissionDTOValidator()
        {
            RuleFor(x => x.File).Must(ContainPdf).WithMessage("Sadece Pdf formatında belge yükleyebilirsiniz.");
            RuleFor(x=>x.StartDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
        }

        private bool ContainPdf(string arg)
        {
            return arg.Contains(".pdf");
        }
    }
}
