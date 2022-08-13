using AutoMapper;
using CompanyPropertyManagement.Data.Domain;
using CompanyPropertyManagement.DataAccessLayer.Infrastructures;
using CompanyPropertyManagement.DTOs.Inventory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyPropertyManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InventoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetInventoryById/{inventoryId}")]
        public ActionResult<InventoryReadDto> GetInventoryById(Guid inventoryId)
        {
            try
            {
                var inventory = _unitOfWork.InventoryRepository.FindById(inventoryId);
                if (inventory is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<InventoryReadDto>(inventory));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("GetInventoriesByUserId/{userId}")]
        public ActionResult<IEnumerable<InventoryReadDto>> GetInventoriesByUserId(Guid userId)
        {
            try
            {
                var inventories = _unitOfWork.InventoryRepository.FindAllByCondition(i => i.UserId.Equals(userId));
                if (inventories is null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<IEnumerable<InventoryReadDto>>(inventories));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateInventory([FromBody] InventoryCreateDto inventoryCreateDto)
        {
            if (inventoryCreateDto == null)
            {
                return BadRequest("InventoryCreateDto object is null");
            }
            var inventory = _mapper.Map<Inventory>(inventoryCreateDto);
            _unitOfWork.InventoryRepository.Create(inventory);
            _unitOfWork.SaveChanges();
            var inventoryReturn = _mapper.Map<InventoryReadDto>(inventory);
            return CreatedAtAction("GetInventoryById", new { inventoryId = inventoryReturn.Id }, inventoryReturn);
        }

    }
}
