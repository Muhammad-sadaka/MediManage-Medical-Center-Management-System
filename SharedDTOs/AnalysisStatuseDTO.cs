using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class AnalysisStatuseDTO
    {
    }
    public class clsAnalysisStatusDTO
    {
        public int? AnalysisStatusID { get; set; }
        public string AnalysisStatusName { get; set; }

        public clsAnalysisStatusDTO(int? analysisStatusID, string analysisStatusName)
        {
            this.AnalysisStatusID = analysisStatusID;
            this.AnalysisStatusName = analysisStatusName;
        }
    }
}
