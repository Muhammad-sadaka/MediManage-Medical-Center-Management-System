using MediManage_Business;
using MediManage_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MediManage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisStatuseController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllAnalysisStatuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<clsAnalysisStatusDTO>> GetAllAnalysisStatuses()
        {
            List<clsAnalysisStatusDTO> list = clsAnalysisStatus.GetAllAnalysisStatuses();
            if (list == null || list.Count == 0)
            {
                return NotFound("No Analysis Statuses Found!");
            }
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetAnalysisStatusById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAnalysisStatusDTO> GetAnalysisStatusById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            clsAnalysisStatus status = clsAnalysisStatus.Find(id);

            if (status == null)
            {
                return NotFound($"Analysis Status with ID {id} not found.");
            }

            return Ok(status.AnalysisStatusDTO);
        }

        [HttpPost(Name = "AddAnalysisStatus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<clsAnalysisStatusDTO> AddAnalysisStatus(clsAnalysisStatusDTO newDTO)
        {
            if (newDTO == null || string.IsNullOrEmpty(newDTO.AnalysisStatusName))
            {
                return BadRequest("Invalid data.");
            }

            clsAnalysisStatus status = new clsAnalysisStatus(newDTO, clsAnalysisStatus.enMode.AddNew);

            if (status.Save())
            {
                newDTO.AnalysisStatusID = status.AnalysisStatusID;
                return CreatedAtRoute("GetAnalysisStatusById", new { id = newDTO.AnalysisStatusID }, newDTO);
            }
            else
            {
                return BadRequest("Failed to create new Analysis Status.");
            }
        }

        [HttpPut("{id}", Name = "UpdateAnalysisStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<clsAnalysisStatusDTO> UpdateAnalysisStatus(int id, clsAnalysisStatusDTO updatedDTO)
        {
            if (id < 1 || updatedDTO == null || string.IsNullOrEmpty(updatedDTO.AnalysisStatusName))
            {
                return BadRequest("Invalid data.");
            }

            clsAnalysisStatus status = clsAnalysisStatus.Find(id);

            if (status == null)
            {
                return NotFound($"Analysis Status with ID {id} not found.");
            }

            status.AnalysisStatusName = updatedDTO.AnalysisStatusName;

            if (status.Save())
            {
                return Ok(status.AnalysisStatusDTO);
            }
            else
            {
                return BadRequest("Failed to update Analysis Status.");
            }
        }

        [HttpDelete("{id}", Name = "DeleteAnalysisStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAnalysisStatus(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAnalysisStatus.DeleteAnalysisStatus(id))
            {
                return Ok($"Analysis Status with ID {id} has been deleted.");
            }
            else
            {
                return NotFound($"Analysis Status with ID {id} not found. No rows deleted!");
            }
        }

        [HttpGet("Exists/{id}", Name = "IsAnalysisStatusExist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IsAnalysisStatusExist(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Invalid ID {id}");
            }

            if (clsAnalysisStatus.IsExist(id))
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