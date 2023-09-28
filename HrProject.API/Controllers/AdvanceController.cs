using AutoMapper;
using HrProject.Business.Abstract;
using HrProject.DTOs.DTOs;
using HrProject.Enums;
using HrProject.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace HrProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        private readonly IGenericService<AdvancePayment> _service;
        private readonly IGenericService<AppUser> _appuserservice;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvancePaymentDTO> _validator;

        public AdvanceController(IGenericService<AdvancePayment> service, IMapper mapper, IGenericService<AppUser> appuserservice)
        {
            _service = service;
            _mapper = mapper;
            _appuserservice = appuserservice;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<AdvancePaymentDTO>>> GetAdvance(string advancedPaymentType)
        //{
        //    try
        //    {
        //        var advancedPaymentList = await _service.GetAll(x => x.Type.Equals(advancedPaymentType));
        //        var advancedPaymentListDto = _mapper.Map<AdvancePaymentDTO>(advancedPaymentList);
        //        return Ok(advancedPaymentListDto);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
        [HttpGet]
        public async Task<ActionResult<List<AdvancePaymentDTO>>> AdvancePaymentPersonalList(Status? status, int id)
        {
            if (status != null)
            {
                var AdvanceList = await _service.GetAll(x => x.Status.Equals(status) && x.Type.Equals(AdvancePaymentType.Personal) && x.AppUserID==id);
                var AdvancePaymentOrder = AdvanceList.OrderBy(x => x.RequestDate);
                List<AdvancePayment> AdvancePaymentList = await AdvancePaymentOrder.ToListAsync();
                var AdvanceListDto = _mapper.Map<List<AdvancePaymentDTO>>(AdvancePaymentList);
                return Ok(AdvanceListDto);
            }
            else
            {
                var AdvanceList = await _service.GetAll(x => x.Type.Equals(AdvancePaymentType.Personal) && x.AppUserID == id);
                var AdvancePaymentOrder = AdvanceList.OrderBy(x => x.RequestDate);
                List<AdvancePayment> AdvancePaymentList = await AdvancePaymentOrder.ToListAsync();
                var AdvanceListDto = _mapper.Map<List<AdvancePaymentDTO>>(AdvancePaymentList);
                return Ok(AdvanceListDto);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<AdvancePaymentDTO>>> AdvancePaymentCorporativeFilter(Status? status, int id)
        {
            if (status != null)
            {
                var AdvanceList = await _service.GetAll(x => x.Status.Equals(status) && x.Type.Equals(AdvancePaymentType.Corporative) && x.AppUserID == id);
                var AdvancePaymentOrder = AdvanceList.OrderBy(x => x.RequestDate);
                List<AdvancePayment> AdvancePaymentList = await AdvancePaymentOrder.ToListAsync();
                var AdvanceListDto = _mapper.Map<List<AdvancePaymentDTO>>(AdvancePaymentList);
                return Ok(AdvanceListDto);
            }
            else
            {
                var AdvanceList = await _service.GetAll(x => x.Type.Equals(AdvancePaymentType.Corporative) && x.AppUserID == id);
                var AdvancePaymentOrder = AdvanceList.OrderBy(x => x.RequestDate);
                List<AdvancePayment> AdvancePaymentList = await AdvancePaymentOrder.ToListAsync();
                var AdvanceListDto = _mapper.Map<List<AdvancePaymentDTO>>(AdvancePaymentList);
                return Ok(AdvanceListDto);
            }
        }
        [HttpPost]
        public async Task<ActionResult<AdvancePaymentDTO>> CreateAdvancePayment(AdvancePaymentDTO advancePaymentDto)
        {
            //var result = _validator.Validate(advancePaymentDto);
            if (ModelState.IsValid)
            {
                try
                {
                    var advances = await _service.GetAll();
                    var totalAdvaceLastYear = advances.Where(x => x.AppUserID == advancePaymentDto.AppUserID && x.RequestDate > DateTime.Now.AddYears(-1) && x.Status == Status.Confirm && x.Type == AdvancePaymentType.Personal).Sum(x => x.Amount);
                    var advanceLimit = _appuserservice.GetById(advancePaymentDto.AppUserID).Salary * 3;

                    if ((totalAdvaceLastYear + advancePaymentDto.Amount) > advanceLimit)
                    {
                        return BadRequest($"En fazla {advanceLimit - totalAdvaceLastYear} TL avans alabilirsiniz.");
                    }

                    var createAdvancePaymentDto = _mapper.Map<AdvancePayment>(advancePaymentDto);
                    bool AddResult = await _service.Add(createAdvancePaymentDto);
                    if (AddResult)
                    {
                        return Ok(advancePaymentDto);
                    }
                    else return BadRequest("Avans ekleme işlemi gerçekleştirilemedi.");
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            else return BadRequest("Lütfen girdiğiniz bilgileri tekrar gözden geçiriniz.");
        }

        //[HttpPut]
        //public async Task<ActionResult<bool>> RelationAdvanceUser(EmployeeDTO employeeDTO/*direkt employee id de gönderilebilir*/,AdvancePaymentDTO advancePaymentDTO)
        //{
        //    return true;
        //}
    }
}
