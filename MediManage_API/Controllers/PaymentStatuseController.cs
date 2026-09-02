using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentStatuseController : ControllerBase
    {
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
            if (id < 1)
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
        public ActionResult<clsPaymentStatusDTO> AddPaymentStatus(clsPaymentStatusDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.PaymentStatusName))
            {
                return BadRequest("Invalid payment status data.");
            }

            clsPaymentStatus paymentStatus = new clsPaymentStatus(newDTO, clsPaymentStatus.enMode.AddNew);

            if (paymentStatus.Save())
            {
                newDTO.PaymentStatusID = paymentStatus.PaymentStatusID;
                return CreatedAtRoute("GetPaymentStatusById", new { id = newDTO.PaymentStatusID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Payment Status.");
            }
        }

        [HttpPut("{id}", Name = "UpdatePaymentStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPaymentStatusDTO> UpdatePaymentStatus(int id, clsPaymentStatusDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.PaymentStatusName))
            {
                return BadRequest("Invalid payment status data.");
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
            else
            {
                return BadRequest("Failed to update Payment Status.");
            }
        }

        [HttpDelete("{id}", Name = "DeletePaymentStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePaymentStatus(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPaymentStatus.DeletePaymentStatus(id))
            {
                return Ok($"Payment Status with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Payment Status with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsPaymentStatusExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPaymentStatusExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPaymentStatus.IsExist(id))
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