using AutoMapper;
using HrProject.Business.Abstract;
using HrProject.DTOs.CreateDTO;
using HrProject.DTOs.DTOs;
using HrProject.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IGenericService<AppUser> _service;
        private readonly IMapper _mapper;
        private readonly IGenericService<Company> _companyService;
        //private readonly IValidator<UserCreateDTO> _validator;
        public AdminController(IGenericService<AppUser> service, IMapper mapper,IGenericService<Company> companyService)
        {
            _service = service;
            _mapper = mapper;
            _companyService = companyService;
        }


        [HttpPost]
        public async Task<ActionResult<AdvancePaymentDTO>> CreateCompanyManager(CreateCompanyManagerDTO createCompanyManagerDto)
        {
            //var result = _validator.Validate(userCreateDto);
            if (ModelState.IsValid)
            {
                try
                {
                    var createAppUser = _mapper.Map<AppUser>(createCompanyManagerDto);
                    bool AddResult = await _service.Add(createAppUser);
                    if (AddResult)
                    {
                        return Ok(createCompanyManagerDto);
                    }
                    else return BadRequest("Yönetici oluşturma işlemi gerçekleştirilemedi.");
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            else return BadRequest("Lütfen girdiğiniz bilgileri tekrar gözden geçiriniz.");
        }
        [HttpGet]
        public async Task<ActionResult<List<CompanyDTO>>> CompanyList()
        {
            var CompanyList= await _companyService.GetAll();
            var Company = CompanyList.OrderBy(x=>x.CompanyName).ToList();
            var CompanyListDto = _mapper.Map<List<CompanyDTO>>(Company);
            return Ok(CompanyListDto);
        }
    }
}
