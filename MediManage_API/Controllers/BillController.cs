using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllBills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsBillDTO>> GetAllBills()
        {
            List<clsBillDTO> list = clsBill.GetAllBills();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Bills Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetBillById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsBillDTO> GetBillById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsBill bill = clsBill.Find(id);

            if (bill == null)
            {
                return NotFound($"Bill with ID {id} not found.");
            }

            return Ok(bill.BillDTO);
        }

        [HttpPost(Name = "AddBill")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsBillDTO> AddBill(clsBillDTO newDTO)
        {
            if (newDTO == null || !newDTO.PatientID.HasValue || !newDTO.TotalAmount.HasValue)
            {
                return BadRequest("Invalid bill data.");
            }

            clsBill bill = new clsBill(newDTO, clsBill.enMode.AddNew);

            if (bill.Save())
            {
                newDTO.Bill_ID = bill.Bill_ID;
                return CreatedAtRoute("GetBillById", new { id = newDTO.Bill_ID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Bill.");
            }
        }

        [HttpPut("{id}", Name = "UpdateBill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsBillDTO> UpdateBill(int id, clsBillDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.PatientID.HasValue || !updatedDTO.TotalAmount.HasValue)
            {
                return BadRequest("Invalid bill data.");
            }

            clsBill bill = clsBill.Find(id);

            if (bill == null)
            {
                return NotFound($"Bill with ID {id} not found.");
            }

            bill.PatientID = updatedDTO.PatientID;
            bill.CreatedByUserID = updatedDTO.CreatedByUserID;
            bill.BillDate = updatedDTO.BillDate;
            bill.AmountOfPaid = updatedDTO.AmountOfPaid;
            bill.AmountOfRemaining = updatedDTO.AmountOfRemaining;
            bill.TotalAmount = updatedDTO.TotalAmount;
            bill.PaymentStatusID = updatedDTO.PaymentStatusID;
            bill.PaymentMethodID = updatedDTO.PaymentMethodID;

            if (bill.Save())
            {
                return Ok(bill.BillDTO);
            }
            else
            {
                return BadRequest("Failed to update Bill.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteBill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteBill(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsBill.DeleteBill(id))
            {
                return Ok($"Bill with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Bill with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsBillExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsBillExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsBill.IsExist(id))
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