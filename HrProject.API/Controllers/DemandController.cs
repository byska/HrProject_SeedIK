using AutoMapper;
using FluentValidation;
using HrProject.Business.Abstract;
using HrProject.Business.Concrete;
using HrProject.DataAccess.UnitOfWork;
using HrProject.DTOs.CreateDTO;
using HrProject.DTOs.DTOs;
using HrProject.Entities.Entities;
using HrProject.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        private readonly IGenericService<PermissionType> _permissionTypeService;
        private readonly IDemandService _service;
        //private readonly IValidator<CreatePermissionDTO> _validator;
        private readonly IMapper _mapper;


        public DemandController(IDemandService service, IMapper mapper, IGenericService<PermissionType> permissionTypeService)
        {
            _service = service;
            //_validator = validator;
            _mapper = mapper;
            _permissionTypeService = permissionTypeService;
        }
        [HttpGet("{permissionType}")]
        public async Task<bool> GetPermissionTypeBool(string permissionType)
        {
            if (permissionType != null)
            {
               PermissionType PermissionTypeBool =await _permissionTypeService.GetByDefault(x => x.PermissionName == permissionType);
                
                return PermissionTypeBool.IsActive;
            }
            else
                return false;

        }

        [HttpGet]
        public async Task<ActionResult<List<PermissionTypeDTO>>> GetPermissionType()
        {
            List<PermissionType> GetType = await _permissionTypeService.GetAll();
            var permissionTypeDto = _mapper.Map<List<PermissionTypeDTO>>(GetType);
            return Ok(permissionTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePermissionDTO>> CreatePermission(CreatePermissionDTO createPermissionDTO)
        {

            //var result = _validator.Validate(createPermissionDTO);
            if (ModelState.IsValid)
            {
                try
                {
                    if (createPermissionDTO.EndDate > createPermissionDTO.StartDate.AddDays(_permissionTypeService.GetById(createPermissionDTO.TypeId).PermissionDay))
                    {
                        return BadRequest($"En fazla {createPermissionDTO.StartDate.AddDays(_permissionTypeService.GetById(createPermissionDTO.TypeId).PermissionDay)} tarihine kadar izin alabilirsiniz.");
                    }
                    var createPermission = _mapper.Map<Permission>(createPermissionDTO);
                    bool AddResult = await _service.AddPermission(createPermission);
                    if (AddResult)
                    {
                        return Ok(createPermissionDTO);
                    }
                    else return BadRequest("Ekleme işlemi gerçekleştirilemedi.");
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            else return BadRequest("Lütfen girdiğiniz bilgileri tekrar gözden geçiriniz.");
        }

        [HttpGet]
        public async Task<ActionResult<List<PermissionDTO>>> GetPermissionsByStatus(Status status)
        {
            if (status != null)
            {
                var listPermission =await _service.GetAll(x => x.Status.Equals(status));
                List<Permission> permissionList = listPermission.ToList();
                var listPermissionDto = _mapper.Map<List<PermissionDTO>>(permissionList);
                return Ok(listPermissionDto);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<PermissionDTO>>> GetPermissionsByConfirmedStatus(Status status)
        {
            if (status != null)
            {
                var listPermission = await _service.GetAll(x => x.Status.Equals(status == Status.Confirm));
                List<Permission> permissionList = listPermission.ToList();
                var listPermissionDto = _mapper.Map<List<PermissionDTO>>(permissionList);
                return Ok(listPermissionDto);
            }
            return BadRequest();
        }

    }
}
