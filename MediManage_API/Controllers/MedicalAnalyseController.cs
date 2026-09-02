using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediManage_Business;
using MediManage_DataAccess;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAnalyseController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllMedicalAnalyses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsMedicalAnalysisDTO>> GetAllMedicalAnalyses()
        {
            List<clsMedicalAnalysisDTO> list = clsMedicalAnalysis.GetAllMedicalAnalyses();
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
            if (id < 1)
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
        public ActionResult<clsMedicalAnalysisDTO> AddMedicalAnalysis(clsMedicalAnalysisDTO newDTO)
        {
            if (newDTO == null || !newDTO.AnalysisTypeID.HasValue || !newDTO.DetectionID.HasValue)
            {
                return BadRequest("Invalid medical analysis data.");
            }

            clsMedicalAnalysis analysis = new clsMedicalAnalysis(newDTO, clsMedicalAnalysis.enMode.AddNew);

            if (analysis.Save())
            {
                newDTO.MedicalAnalysisID = analysis.MedicalAnalysisID;
                return CreatedAtRoute("GetMedicalAnalysisById", new { id = newDTO.MedicalAnalysisID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Medical Analysis.");
            }
        }

        [HttpPut("{id}", Name = "UpdateMedicalAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsMedicalAnalysisDTO> UpdateMedicalAnalysis(int id, clsMedicalAnalysisDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || !updatedDTO.AnalysisTypeID.HasValue || !updatedDTO.DetectionID.HasValue)
            {
                return BadRequest("Invalid medical analysis data.");
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

            if (analysis.Save())
            {
                return Ok(analysis.DTO);
            }
            else
            {
                return BadRequest("Failed to update Medical Analysis.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteMedicalAnalysis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMedicalAnalysis(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicalAnalysis.DeleteMedicalAnalysis(id))
            {
                return Ok($"Medical Analysis with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Medical Analysis with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsMedicalAnalysisExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsMedicalAnalysisExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsMedicalAnalysis.IsExist(id))
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