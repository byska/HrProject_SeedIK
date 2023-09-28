using AutoMapper;
using FluentValidation;
using HrProject.Business.Abstract;
using HrProject.DTOs.CreateDTO;
using HrProject.DTOs.DTOs;
using HrProject.DTOs.UpdateDTO;
using HrProject.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IGenericService<Company> _service;
        private readonly IMapper _mapper;

        public CompanyController(IGenericService<Company> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyCreateDTO companyCreateDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createCompany = _mapper.Map<Company>(companyCreateDTO);
                    bool AddResult = await _service.Add(createCompany);
                    if (AddResult)
                    {
                        return Ok(companyCreateDTO);
                    }
                    else return BadRequest("Şirket oluşturma işlemi gerçekleştirilemedi.");
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else return BadRequest("Lütfen girdiğiniz bilgileri tekrar gözden geçiriniz.");
        }
        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {
            if (id == 0)
                return BadRequest("Gelen id değeri 1 den küçük.");
            var company = _service.GetById(id);
            var companyDto = _mapper.Map<CompanyDTO>(company);
            return Ok(companyDto);
        }
    }
}
