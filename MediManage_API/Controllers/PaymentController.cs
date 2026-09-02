using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsPaymentDTO>> GetAllPayments()
        {
            List<clsPaymentDTO> list = clsPayment.GetAllPayments();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Payments Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPaymentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPaymentDTO> GetPaymentById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsPayment payment = clsPayment.Find(id);

            if (payment == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            return Ok(payment.DTO);
        }

        [HttpPost(Name = "AddPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPaymentDTO> AddPayment(clsPaymentDTO newDTO)
        {
            if (newDTO == null || !newDTO.Bill_ID.HasValue || !newDTO.Amount.HasValue)
            {
                return BadRequest("Invalid payment data.");
            }

            clsPayment payment = new clsPayment(newDTO, clsPayment.enMode.AddNew);

            if (payment.Save())
            {
                newDTO.PaymentID = payment.PaymentID;
                return CreatedAtRoute("GetPaymentById", new { id = newDTO.PaymentID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Payment.");
            }
        }

        [HttpPut("{id}", Name = "UpdatePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPaymentDTO> UpdatePayment(int id, clsPaymentDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.Bill_ID.HasValue || !updatedDTO.Amount.HasValue)
            {
                return BadRequest("Invalid payment data.");
            }

            clsPayment payment = clsPayment.Find(id);

            if (payment == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            payment.Bill_ID = updatedDTO.Bill_ID;
            payment.PaymentDate = updatedDTO.PaymentDate;
            payment.CreatedByUserID = updatedDTO.CreatedByUserID;
            payment.Amount = updatedDTO.Amount;

            if (payment.Save())
            {
                return Ok(payment.DTO);
            }
            else
            {
                return BadRequest("Failed to update Payment.");
            }
        }

        [HttpDelete("{id}", Name = "DeletePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePayment(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPayment.DeletePayment(id))
            {
                return Ok($"Payment with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Payment with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsPaymentExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPaymentExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPayment.IsExist(id))
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