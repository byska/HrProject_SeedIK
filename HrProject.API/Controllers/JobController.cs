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
    public class JobController : ControllerBase
    {
        private readonly IGenericService<Job> _service;
        private readonly IMapper _mapper;

        public JobController(IGenericService<Job> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            if (id == 0)
                return BadRequest("Gelen id değeri 1 den küçük.");
            var job = _service.GetById(id);
            var jobDto = _mapper.Map<JobDTO>(job);
            return Ok(jobDto);
        }
    }
}
