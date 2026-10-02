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
    public class PaymentMethodController : ControllerBase
    {
        private readonly IValidator<clsPaymentMethodDTO> _validator;

        public PaymentMethodController(IValidator<clsPaymentMethodDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllPaymentMethods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsPaymentMethodDTO>> GetAllPaymentMethods()
        {
            List<clsPaymentMethodDTO> list = clsPaymentMethod.GetAllPaymentMethods();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Payment Methods Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetPaymentMethodById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPaymentMethodDTO> GetPaymentMethodById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsPaymentMethod paymentMethod = clsPaymentMethod.Find(id);

            if (paymentMethod == null)
            {
                return NotFound($"Payment Method with ID {id} not found.");
            }

            return Ok(paymentMethod.DTO);
        }

        [HttpPost(Name = "AddPaymentMethod")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsPaymentMethodDTO> AddPaymentMethod([FromBody] clsPaymentMethodDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsPaymentMethod paymentMethod = new clsPaymentMethod(newDTO, clsPaymentMethod.enMode.AddNew);

            if (paymentMethod.Save())
            {
                newDTO.PaymentMethodID = paymentMethod.PaymentMethodID;
                return CreatedAtRoute("GetPaymentMethodById", new { id = newDTO.PaymentMethodID }, newDTO);
            }

            return BadRequest("Failed to create new Payment Method.");
        }

        [HttpPut("{id}", Name = "UpdatePaymentMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsPaymentMethodDTO> UpdatePaymentMethod(int id, [FromBody] clsPaymentMethodDTO updatedDTO)
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

            clsPaymentMethod paymentMethod = clsPaymentMethod.Find(id);

            if (paymentMethod == null)
            {
                return NotFound($"Payment Method with ID {id} not found.");
            }

            paymentMethod.PaymentMethodName = updatedDTO.PaymentMethodName;

            if (paymentMethod.Save())
            {
                return Ok(paymentMethod.DTO);
            }

            return BadRequest("Failed to update Payment Method.");
        }

        [HttpDelete("{id}", Name = "DeletePaymentMethod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeletePaymentMethod(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsPaymentMethod.IsExist(id))
            {
                return NotFound($"Payment Method with ID {id} not found.");
            }

            if (clsPaymentMethod.DeletePaymentMethod(id))
            {
                return Ok($"Payment Method with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Payment Method.");
        }

        [HttpGet("Exists/{id}", Name = "IsPaymentMethodExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsPaymentMethodExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsPaymentMethod.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}