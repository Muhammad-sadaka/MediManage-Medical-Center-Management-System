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
    public class MedicalAnalyseController : ControllerBase
    {
        private readonly IValidator<clsMedicalAnalysisDTO> _validator;

        public MedicalAnalyseController(IValidator<clsMedicalAnalysisDTO> validator)
        {
            _validator = validator;
        }

        [HttpGet("All", Name = "GetAllMedicalAnalyses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsMedicalAnalysisListDTO>> GetAllMedicalAnalyses()
        {
            List<clsMedicalAnalysisListDTO> list = clsMedicalAnalysis.GetAllMedicalAnalyses();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Medical Analyses Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetMedicalAnalysisById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicalAnalysisDTO> GetMedicalAnalysisById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsMedicalAnalysis analysis = clsMedicalAnalysis.Find(id);

            if (analysis == null)
            {
                return NotFound($"Medical Analysis with ID {id} not found.");
            }

            return Ok(analysis.DTO);
        }

        [HttpPost(Name = "AddMedicalAnalysis")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsMedicalAnalysisDTO> AddMedicalAnalysis([FromBody] clsMedicalAnalysisDTO newDTO)
        {
            var validationResult = _validator.Validate(newDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            clsMedicalAnalysis analysis = new clsMedicalAnalysis(newDTO, clsMedicalAnalysis.enMode.AddNew);

            if (analysis.Save())
            {
                newDTO.MedicalAnalysisID = analysis.MedicalAnalysisID;
                return CreatedAtRoute("GetMedicalAnalysisById", new { id = newDTO.MedicalAnalysisID }, newDTO);
            }

            return BadRequest("Failed to create new Medical Analysis.");
        }

        [HttpPut("{id}", Name = "UpdateMedicalAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicalAnalysisDTO> UpdateMedicalAnalysis(int id, [FromBody] clsMedicalAnalysisDTO updatedDTO)
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

            clsMedicalAnalysis analysis = clsMedicalAnalysis.Find(id);

            if (analysis == null)
            {
                return NotFound($"Medical Analysis with ID {id} not found.");
            }

            analysis.Result = updatedDTO.Result;
            analysis.OrderDate = updatedDTO.OrderDate;
            analysis.ResultDate = updatedDTO.ResultDate;
            analysis.AnalysisStatusID = updatedDTO.AnalysisStatusID;
            analysis.AnalysisTypeID = updatedDTO.AnalysisTypeID;
            analysis.DetectionID = updatedDTO.DetectionID;
            analysis.Notes = updatedDTO.Notes;

            if (analysis.Save())
            {
                return Ok(analysis.DTO);
            }

            return BadRequest("Failed to update Medical Analysis.");
        }

        [HttpDelete("{id}", Name = "DeleteMedicalAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMedicalAnalysis(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (!clsMedicalAnalysis.IsExist(id))
            {
                return NotFound($"Medical Analysis with ID {id} not found.");
            }

            if (clsMedicalAnalysis.DeleteMedicalAnalysis(id))
            {
                return Ok($"Medical Analysis with ID {id} has been deleted.");
            }

            return BadRequest("Failed to delete Medical Analysis.");
        }

        [HttpGet("Exists/{id}", Name = "IsMedicalAnalysisExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsMedicalAnalysisExist(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicalAnalysis.IsExist(id))
            {
                return Ok(true);
            }

            return NotFound(false);
        }
    }
}