using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class MedicalAnalyseDTO
    {
    }
    public class clsMedicalAnalysisDTO
    {
        public int? MedicalAnalysisID { get; set; }
        public string Result { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public int? AnalysisStatusID { get; set; }
        public int? AnalysisTypeID { get; set; }
        public int? DetectionID { get; set; }
        public string Notes { get; set; }

        public clsMedicalAnalysisDTO(int? medicalAnalysisID, string result, DateTime? orderDate, DateTime? resultDate, int? analysisStatusID, int? analysisTypeID, int? detectionID, string Notes)
        {
            this.MedicalAnalysisID = medicalAnalysisID;
            this.Result = result;
            this.OrderDate = orderDate;
            this.ResultDate = resultDate;
            this.AnalysisStatusID = analysisStatusID;
            this.AnalysisTypeID = analysisTypeID;
            this.DetectionID = detectionID;
            this.Notes = Notes;
        }
    }

    public class clsMedicalAnalysisListDTO
    {
        public int? MedicalAnalysisID { get; set; }
        public string PatientName { get; set; }
        public string AnalysisType { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }



        public clsMedicalAnalysisListDTO(int? medicalAnalysisID, string patientName, string analysisType, DateTime? orderDate, string analysisStatus)
        {
            this.MedicalAnalysisID = medicalAnalysisID;
            this.PatientName = patientName;
            this.AnalysisType = analysisType;
            this.OrderDate = orderDate;
            this.Status = analysisStatus;
        }
    }
}
