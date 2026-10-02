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
    public class BillController : ControllerBase
    {
        private readonly IValidator<clsBillDTO> _validator;

        public BillController(IValidator<clsBillDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllBills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsBillListDTO>> GetAllBills()
        {
            List<clsBillListDTO> list = clsBill.GetAllBills();
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
            if (id <= 0)
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
        public ActionResult<clsBillDTO> AddBill([FromBody] clsBillDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsBill bill = new clsBill(newDTO, clsBill.enMode.AddNew);

            if (bill.Save())
            {
                newDTO.Bill_ID = bill.Bill_ID;
                return CreatedAtRoute("GetBillById", new { id = newDTO.Bill_ID }, newDTO);
            }

            return BadRequest("Failed to create new Bill.");
        }

        [HttpPut("{id}", Name = "UpdateBill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsBillDTO> UpdateBill(int id, [FromBody] clsBillDTO updatedDTO)
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

            if (bill.Save())
            {
                return Ok(bill.BillDTO);
            }

            return BadRequest("Failed to update Bill.");
        }

        [HttpDelete("{id}", Name = "DeleteBill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteBill(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsBill.IsExist(id))
            {
                return NotFound($"Bill with ID {id} not found.");
            }

            if (clsBill.DeleteBill(id))
            {
                return Ok($"Bill with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Bill.");
        }

        [HttpGet("Exists/{id}", Name = "IsBillExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsBillExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsBill.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}