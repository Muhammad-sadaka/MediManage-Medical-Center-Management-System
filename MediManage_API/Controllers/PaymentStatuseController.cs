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
    public class PaymentStatusController : ControllerBase
    {
        private readonly IValidator<clsPaymentStatusDTO> _validator;

        public PaymentStatusController(IValidator<clsPaymentStatusDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllPaymentStatuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsPaymentStatusDTO>> GetAllPaymentStatuses()
        {
            List<clsPaymentStatusDTO> list = clsPaymentStatus.GetAllPaymentStatuses();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Payment Statuses Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPaymentStatusById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPaymentStatusDTO> GetPaymentStatusById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsPaymentStatus paymentStatus = clsPaymentStatus.Find(id);

            if (paymentStatus == null)
            {
                return NotFound($"Payment Status with ID {id} not found.");
            }

            return Ok(paymentStatus.DTO);
        }

        [HttpPost(Name = "AddPaymentStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPaymentStatusDTO> AddPaymentStatus([FromBody] clsPaymentStatusDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsPaymentStatus paymentStatus = new clsPaymentStatus(newDTO, clsPaymentStatus.enMode.AddNew);

            if (paymentStatus.Save())
            {
                newDTO.PaymentStatusID = paymentStatus.PaymentStatusID;
                return CreatedAtRoute("GetPaymentStatusById", new { id = newDTO.PaymentStatusID }, newDTO);
            }

            return BadRequest("Failed to create new Payment Status.");
        }

        [HttpPut("{id}", Name = "UpdatePaymentStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPaymentStatusDTO> UpdatePaymentStatus(int id, [FromBody] clsPaymentStatusDTO updatedDTO)
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

            clsPaymentStatus paymentStatus = clsPaymentStatus.Find(id);

            if (paymentStatus == null)
            {
                return NotFound($"Payment Status with ID {id} not found.");
            }

            paymentStatus.PaymentStatusName = updatedDTO.PaymentStatusName;

            if (paymentStatus.Save())
            {
                return Ok(paymentStatus.DTO);
            }

            return BadRequest("Failed to update Payment Status.");
        }

        [HttpDelete("{id}", Name = "DeletePaymentStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePaymentStatus(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsPaymentStatus.IsExist(id))
            {
                return NotFound($"Payment Status with ID {id} not found.");
            }

            if (clsPaymentStatus.DeletePaymentStatus(id))
            {
                return Ok($"Payment Status with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Payment Status.");
        }

        [HttpGet("Exists/{id}", Name = "IsPaymentStatusExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPaymentStatusExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPaymentStatus.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}