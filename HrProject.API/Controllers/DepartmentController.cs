using AutoMapper;
using FluentValidation;
using HrProject.Business.Abstract;
using HrProject.DTOs.DTOs;
using HrProject.DTOs.UpdateDTO;
using HrProject.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IGenericService<Department> _service;
        private readonly IMapper _mapper;

        public DepartmentController(IGenericService<Department> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            if (id == 0)
                return BadRequest("Gelen id değeri 1 den küçük.");
            var department = _service.GetById(id);
            var departmentDto = _mapper.Map<Department>(department);
            return Ok(departmentDto);
        }
    }
}
