using AutoMapper;
using FluentValidation;
using HrProject.Business.Abstract;
using HrProject.DTOs.DetailsDto;
using HrProject.DTOs.DTOs;
using HrProject.DTOs.UpdateDTO;
using HrProject.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IGenericService<AppUser> _service;
        private readonly IValidator<UpdateEmployeeDTO> _validator;
        private readonly IMapper _mapper;

        public PersonelController(IGenericService<AppUser> service, IValidator<UpdateEmployeeDTO> validator, IMapper mapper)
        {
            _service = service;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public  IActionResult GetEmployee(int id)
        {
            if (id == 0)
                return BadRequest("Gelen id değeri 1 den küçük.");
            var employee =  _service.GetById(id);
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailEmployeeDTO>> GetDetailEmployee(int id)
        {
            if (id <= 0)
                return BadRequest("Gelen id değeri 1 den küçük.");
            var employee = _service.GetById(id);
            var employeeDetailDto = _mapper.Map<DetailEmployeeDTO>(employee);
            return Ok(employeeDetailDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateEmployeeDTO>> UpdateEmployee(int id,UpdateEmployeeDTO employeeUpdateDto) 
        {
            var result =  _validator.Validate(employeeUpdateDto);
            if (result.IsValid)
            {
                var employee =_service.GetById(id);
                employee.PhoneNumber = employeeUpdateDto.PhoneNumber;
                employee.Address = employeeUpdateDto.Address;
                employee.EmployeeImage = employeeUpdateDto.EmployeeImage;
                if (_service.Update(employee))
                {
                    return Ok(employee);
                }
                return BadRequest("Update gerçekleştirilemedi!");

            }
            return BadRequest(result.Errors);
        }
    }
}
