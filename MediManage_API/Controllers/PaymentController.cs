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
    public class PaymentController : ControllerBase
    {
        private readonly IValidator<clsPaymentDTO> _validator;

        public PaymentController(IValidator<clsPaymentDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All/{billId?}", Name = "GetAllPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsPaymentListDTO>> GetAllPayments(int? billId = null)
        {
            List<clsPaymentListDTO> list = clsPayment.GetAllPayments(billId);
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
            if (id <= 0)
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
        public ActionResult<clsPaymentDTO> AddPayment([FromBody] clsPaymentDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsPayment payment = new clsPayment(newDTO, clsPayment.enMode.AddNew);

            if (payment.Save())
            {
                newDTO.PaymentID = payment.PaymentID;
                return CreatedAtRoute("GetPaymentById", new { id = newDTO.PaymentID }, newDTO);
            }

            return BadRequest("Failed to create new Payment.");
        }

        [HttpPut("{id}", Name = "UpdatePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPaymentDTO> UpdatePayment(int id, [FromBody] clsPaymentDTO updatedDTO)
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

            clsPayment payment = clsPayment.Find(id);

            if (payment == null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            payment.Bill_ID = updatedDTO.Bill_ID;
            payment.PaymentDate = updatedDTO.PaymentDate;
            payment.CreatedByUserID = updatedDTO.CreatedByUserID;
            payment.Amount = updatedDTO.Amount;
            payment.PaymentMethodID = updatedDTO.PaymentMethodID;

            if (payment.Save())
            {
                return Ok(payment.DTO);
            }

            return BadRequest("Failed to update Payment.");
        }

        [HttpDelete("{id}", Name = "DeletePayment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePayment(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsPayment.IsExist(id))
            {
                return NotFound($"Payment with ID {id} not found.");
            }

            if (clsPayment.DeletePayment(id))
            {
                return Ok($"Payment with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Payment.");
        }

        [HttpGet("Exists/{id}", Name = "IsPaymentExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPaymentExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPayment.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }

        [HttpGet("TodayCount", Name = "GetTotalTodayPayments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> GetTotalTodayPayments()
        {
            int? count = clsPayment.GetTotalTodayPayments();
            if (!count.HasValue)
            {
                return NotFound("Could not retrieve today's payments count.");
            }

            return Ok(count.Value);
        }
    }
}