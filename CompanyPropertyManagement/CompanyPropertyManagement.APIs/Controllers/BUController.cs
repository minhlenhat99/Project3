using AutoMapper;
using CompanyPropertyManagement.DataAccessLayer.Infrastructures;
using CompanyPropertyManagement.DTOs.BU;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyPropertyManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BUController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BUController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BUReadDto>> GetBus()
        {
            try
            {
                var Bus = _unitOfWork.BuRepository.FindAll();
                if (Bus is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<IEnumerable<BUReadDto>>(Bus));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
