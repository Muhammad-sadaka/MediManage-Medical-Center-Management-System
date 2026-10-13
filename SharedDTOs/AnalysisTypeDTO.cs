using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class AnalysisTypeDTO
    {
    }
    public class clsAnalysisTypeDTO
    {
        public int? AnalysisTypeID { get; set; }
        public string AnalysisTypeName { get; set; }
        public decimal? Price { get; set; }

        public clsAnalysisTypeDTO(int? analysisTypeID, string analysisTypeName, decimal? price)
        {
            this.AnalysisTypeID = analysisTypeID;
            this.AnalysisTypeName = analysisTypeName;
            this.Price = price;
        }
    }

}
