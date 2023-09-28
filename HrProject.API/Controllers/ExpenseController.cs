using AutoMapper;
using FluentValidation;
using HrProject.Business.Abstract;
using HrProject.DTOs.CreateDTO;
using HrProject.DTOs.DTOs;
using HrProject.Entities.Entities;
using HrProject.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HrProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IGenericService<Expense> _service;
        private readonly IMapper _mapper;
        private readonly IValidator<ExpenseDTO> _validator;

        public ExpenseController(IGenericService<Expense> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<ExpenseDTO>>> ExpenseListByFilter(string status)
        {
            if (status != null)
            {
                var listExpense = await _service.GetAll(x => x.Status.Equals(status));
                List<Expense> ExpenseList = await listExpense.ToListAsync();
                var listExpenseDto = _mapper.Map<List<ExpenseDTO>>(ExpenseList);
                return Ok(listExpenseDto);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<List<ExpenseDTO>>> ExpenseList()
        {
            var expenseList = await _service.GetAll();
            var listExpenseDto = _mapper.Map<List<ExpenseDTO>>(expenseList);
            return Ok(listExpenseDto);
        }
        [HttpGet]
        public async Task<ActionResult<List<ExpenseDTO>>> ExpenseListByType(ExpenseType expenseType)
        {
            if (expenseType != null)
            {
                var listExpense = await _service.GetAll(x => x.Type.Equals(expenseType));
                List<Expense> ExpenseList = await listExpense.ToListAsync();
                var listExpenseDto = _mapper.Map<List<ExpenseDTO>>(ExpenseList);
                return Ok(listExpenseDto);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<List<ExpenseDTO>>> ExpenseAccomodationList(Status? status,int id)
        {
            if(status != null)
            {
                var ExpenseList = await _service.GetAll(x=>x.Status.Equals(status) && x.Type==ExpenseType.Accommodation && x.AppUserID==id);
                var ExpenseListOrder = ExpenseList.OrderBy(x => x.RequestDate).ToList();
                var ExpenseListDto = _mapper.Map<List<ExpenseDTO>>(ExpenseListOrder);
                return Ok(ExpenseListDto);
            }
            else
            {
                var ExpenseList = await _service.GetAll(x =>x.Type == ExpenseType.Accommodation && x.AppUserID == id);
                var ExpenseListOrder = ExpenseList.OrderBy(x => x.RequestDate).ToList();
                var ExpenseListDto = _mapper.Map<List<ExpenseDTO>>(ExpenseListOrder);
                return Ok(ExpenseListDto);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ExpenseDTO>>> ExpenseTripList(Status? status, int id)
        {
            if (status != null)
            {
                var ExpenseList = await _service.GetAll(x => x.Status.Equals(status) && x.Type == ExpenseType.Trip && x.AppUserID == id);
                var ExpenseListOrder = ExpenseList.OrderBy(x => x.RequestDate).ToList();
                var ExpenseListDto = _mapper.Map<List<ExpenseDTO>>(ExpenseListOrder);
                return Ok(ExpenseListDto);
            }
            else
            {
                var ExpenseList = await _service.GetAll(x => x.Type == ExpenseType.Trip && x.AppUserID == id);
                var ExpenseListOrder = ExpenseList.OrderBy(x => x.RequestDate).ToList();
                var ExpenseListDto = _mapper.Map<List<ExpenseDTO>>(ExpenseListOrder);
                return Ok(ExpenseListDto);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ExpenseDTO>>> ExpenseFoodAndBeverageList(Status? status, int id)
        {
            if (status != null)
            {
                var ExpenseList = await _service.GetAll(x => x.Status.Equals(status) && x.Type == ExpenseType.FoodAndBeverage && x.AppUserID == id);
                var ExpenseListOrder = ExpenseList.OrderBy(x => x.RequestDate).ToList();
                var ExpenseListDto = _mapper.Map<List<ExpenseDTO>>(ExpenseListOrder);
                return Ok(ExpenseListDto);
            }
            else
            {
                var ExpenseList = await _service.GetAll(x => x.Type == ExpenseType.FoodAndBeverage && x.AppUserID == id);
                var ExpenseListOrder = ExpenseList.OrderBy(x => x.RequestDate).ToList();
                var ExpenseListDto = _mapper.Map<List<ExpenseDTO>>(ExpenseListOrder);
                return Ok(ExpenseListDto);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateExpenseDTO>> CreateExpense(CreateExpenseDTO createExpenseDTO)
        {
            //var result = _validator.Validate(createExpenseDTO);
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var createExpense = _mapper.Map<Expense>(createExpenseDTO);
                    bool AddResult = await _service.Add(createExpense); //?
                    if (AddResult)
                    {
                        return Ok(createExpenseDTO);
                    }
                    else return BadRequest("Harcama ekleme işlemi gerçekleştirilemedi.");
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            else return BadRequest("Lütfen girdiğiniz bilgileri tekrar gözden geçiriniz.");
        }
        [HttpPost("{itemId}")]
        public IActionResult ChangeStatus(ChangeStatusDTO changeStatusDTO)
        {
            var expense=_service.GetById(changeStatusDTO.itemId);
            if (changeStatusDTO.newStatus == "Confirm")
                expense.Status = Status.Confirm;
            else if(changeStatusDTO.newStatus == "Denied")
                expense.Status = Status.Denied;
            _service.Update(expense);
            return Ok(expense);

        }



    }
}
