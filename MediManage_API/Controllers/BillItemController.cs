using FluentValidation;
using MediManage_Business;
using MediManage_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillItemController : ControllerBase
    {
        private readonly IValidator<clsBillItemDTO> _validator;

        public BillItemController(IValidator<clsBillItemDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All/{id}", Name = "GetAllBillItemsByBillID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsBillItemListDTO>> GetAllBillItems(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid Bill ID {id}");
            }

            List<clsBillItemListDTO> list = clsBillItem.GetAllBillItems(id);
            if (list == null || list.Count == 0)
            {
                return NotFound("No Bill Items Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetBillItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsBillItemDTO> GetBillItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsBillItem billItem = clsBillItem.Find(id);

            if (billItem == null)
            {
                return NotFound($"Bill Item with ID {id} not found.");
            }

            return Ok(billItem.BillItemDTO);
        }

        [HttpPost(Name = "AddBillItem")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsBillItemDTO> AddBillItem([FromBody] clsBillItemDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsBillItem billItem = new clsBillItem(newDTO, clsBillItem.enMode.AddNew);

            if (billItem.Save())
            {
                newDTO.BillItemID = billItem.BillItemID;
                return CreatedAtRoute("GetBillItemById", new { id = newDTO.BillItemID }, newDTO);
            }

            return BadRequest("Failed to create new Bill Item.");
        }

        [HttpPut("{id}", Name = "UpdateBillItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsBillItemDTO> UpdateBillItem(int id, [FromBody] clsBillItemDTO updatedDTO)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            var validationResult = _validator.Validate(updatedDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsBillItem billItem = clsBillItem.Find(id);

            if (billItem == null)
            {
                return NotFound($"Bill Item with ID {id} not found.");
            }

            billItem.Bill_ID = updatedDTO.Bill_ID;
            billItem.ServiceTypeID = updatedDTO.ServiceTypeID;
            billItem.Description = updatedDTO.Description;
            billItem.Amount = updatedDTO.Amount;
            billItem.Total = updatedDTO.Total;

            if (billItem.Save())
            {
                return Ok(billItem.BillItemDTO);
            }

            return BadRequest("Failed to update Bill Item.");
        }

        [HttpDelete("{id}", Name = "DeleteBillItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteBillItem(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsBillItem.IsExist(id))
            {
                return NotFound($"Bill Item with ID {id} not found.");
            }

            if (clsBillItem.DeleteBillItem(id))
            {
                return Ok($"Bill Item with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Bill Item.");
        }

        [HttpGet("Exists/{id}", Name = "IsBillItemExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsBillItemExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsBillItem.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("Total", Name = "CalculateTotal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<decimal> CalculateTotal(decimal price, int quantity)
        {
            if (price < 0 || quantity <= 0)
            {
                return BadRequest("Invalid Quantity or Price.");
            }

            return Ok(clsBillItem.CalculateTotal(price, quantity));
        }
    }
}