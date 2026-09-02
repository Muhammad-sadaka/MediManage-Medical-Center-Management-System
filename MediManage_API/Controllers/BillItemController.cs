using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillItemController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllBillItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsBillItemDTO>> GetAllBillItems()
        {
            List<clsBillItemDTO> list = clsBillItem.GetAllBillItems();
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
            if (id < 1)
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
        public ActionResult<clsBillItemDTO> AddBillItem(clsBillItemDTO newDTO)
        {
            if (newDTO == null || !newDTO.Bill_ID.HasValue || !newDTO.Price.HasValue)
            {
                return BadRequest("Invalid bill item data.");
            }

            clsBillItem billItem = new clsBillItem(newDTO, clsBillItem.enMode.AddNew);

            if (billItem.Save())
            {
                newDTO.BillItemID = billItem.BillItemID;
                return CreatedAtRoute("GetBillItemById", new { id = newDTO.BillItemID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Bill Item.");
            }
        }

        [HttpPut("{id}", Name = "UpdateBillItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsBillItemDTO> UpdateBillItem(int id, clsBillItemDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.Bill_ID.HasValue || !updatedDTO.Price.HasValue)
            {
                return BadRequest("Invalid bill item data.");
            }

            clsBillItem billItem = clsBillItem.Find(id);

            if (billItem == null)
            {
                return NotFound($"Bill Item with ID {id} not found.");
            }

            billItem.Bill_ID = updatedDTO.Bill_ID;
            billItem.ServiceTypeID = updatedDTO.ServiceTypeID;
            billItem.Description = updatedDTO.Description;
            billItem.Price = updatedDTO.Price;
            billItem.Amount = updatedDTO.Amount;
            billItem.Total = updatedDTO.Total;

            if (billItem.Save())
            {
                return Ok(billItem.BillItemDTO);
            }
            else
            {
                return BadRequest("Failed to update Bill Item.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteBillItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteBillItem(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsBillItem.DeleteBillItem(id))
            {
                return Ok($"Bill Item with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Bill Item with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsBillItemExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsBillItemExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsBillItem.IsExist(id))
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }
    }
}