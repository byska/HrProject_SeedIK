using AutoMapper;
using HrProject.DTOs.CreateDTO;
using HrProject.DTOs.DetailsDto;
using HrProject.DTOs.DTOs;
using HrProject.DTOs.UpdateDTO;
using HrProject.Entities.Entities;

namespace HrProject.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AppUser, EmployeeDTO>().ReverseMap();
            CreateMap<AppUser, ManagerListEmployeeDTO>().ReverseMap();
            CreateMap<AppUser, DetailEmployeeDTO>().ReverseMap();
            CreateMap<AppUser, UpdateEmployeeDTO>().ReverseMap();
            CreateMap<AppUser, CreateCompanyManagerDTO>().ReverseMap();
            CreateMap<Permission, CreatePermissionDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
            CreateMap<PermissionType, PermissionTypeDTO>().ReverseMap();
            CreateMap<Job,JobDTO>().ReverseMap();
            CreateMap<Department,DepartmentDTO>().ReverseMap();
            CreateMap<Company,CompanyDTO>().ReverseMap();     
            CreateMap<AdvancePayment,AdvancePaymentDTO>().ReverseMap();     
            CreateMap<ExpenseDTO,Expense>().ReverseMap();     
            CreateMap<CreateExpenseDTO,Expense>().ReverseMap();     
            
        }

    }
}
