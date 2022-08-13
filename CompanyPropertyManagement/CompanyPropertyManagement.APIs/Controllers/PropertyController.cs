using AutoMapper;
using CompanyPropertyManagement.DataAccessLayer.Infrastructures;
using CompanyPropertyManagement.DTOs.Property;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyPropertyManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PropertyReadDto>> GetProperties()
        {
            try
            {
                var properties = _unitOfWork.PropertyRepository.FindAll();
                if (properties is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<IEnumerable<PropertyReadDto>>(properties));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{buId}")]
        public ActionResult<IEnumerable<PropertyReadDto>> GetPropertiesBy(Guid buId)
        {
            try
            {
                var properties = _unitOfWork.PropertyRepository.FindAllByCondition(p => p.SeatCode.BuId.Equals(buId));
                if (properties is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<IEnumerable<PropertyReadDto>>(properties));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
