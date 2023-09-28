using AutoMapper;
using FluentValidation;
using HrProject.Business.Abstract;
using HrProject.DTOs.DetailsDto;
using HrProject.DTOs.DTOs;
using HrProject.DTOs.UpdateDTO;
using HrProject.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace HrProject.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IGenericService<AppUser> _service;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateManagerDTO> _validator;
        public ManagerController(IGenericService<AppUser> service, IMapper mapper, IValidator<UpdateManagerDTO> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailManagerDTO>> GetDetailManager(int id)
        {
            if (id <= 0)
                return BadRequest("Gelen id değeri 1 den küçük.");
            var manager = _service.GetById(id);
            var managerDetailDto = _mapper.Map<DetailManagerDTO>(manager);
            return Ok(managerDetailDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<ManagerListEmployeeDTO>>> ListEmployee()
        {
            Expression<Func<AppUser, object>>[] includes = { e => e.Job, e => e.Company, e => e.Department };
            IQueryable<AppUser> result = await _service.GetAll(includes);
           var listEmployee = result.ToList();
            var listEmployeeDto = _mapper.Map<List<ManagerListEmployeeDTO>>(listEmployee);
            return Ok(listEmployeeDto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateManagerDTO>> UpdateManager(int id, UpdateManagerDTO managerUpdate)
        {
            var result = _validator.Validate(managerUpdate);
            if (result.IsValid)
            {
                var manager = _service.GetById(id);
                manager.PhoneNumber = managerUpdate.PhoneNumber;
                manager.Address = managerUpdate.Address;
                manager.EmployeeImage = managerUpdate.ManagerImage;
                if (_service.Update(manager))
                {
                    return Ok(manager);
                }
                return BadRequest("Update işlemi gerçekleştirilemedi!");

            }
            return BadRequest(result.Errors);
        }

    }
}
