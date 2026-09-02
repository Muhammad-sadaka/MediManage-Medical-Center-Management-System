using System;
using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{

    public class clsMedicalAnalysis
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsMedicalAnalysisDTO DTO
        {
            get
            {
                return new clsMedicalAnalysisDTO
                (
                    this.MedicalAnalysisID,
                    this.Result,
                    this.OrderDate,
                    this.ResultDate,
                    this.AnalysisStatusID,
                    this.AnalysisTypeID,
                    this.DetectionID
                );
            }
        }

        public int? MedicalAnalysisID { get; set; }
        public string Result { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public int? AnalysisStatusID { get; set; }
        public int? AnalysisTypeID { get; set; }
        public int? DetectionID { get; set; }

        public clsMedicalAnalysis(clsMedicalAnalysisDTO dto, enMode cMode = enMode.AddNew)
        {
            this.MedicalAnalysisID = dto.MedicalAnalysisID;
            this.Result = dto.Result;
            this.OrderDate = dto.OrderDate;
            this.ResultDate = dto.ResultDate;
            this.AnalysisStatusID = dto.AnalysisStatusID;
            this.AnalysisTypeID = dto.AnalysisTypeID;
            this.DetectionID = dto.DetectionID;
            this.Mode = cMode;
        }

        private bool _AddNewMedicalAnalysis()
        {
            this.MedicalAnalysisID = clsMedicalAnalysesDataAccess.AddNewMedicalAnalysis(this.DTO);
            return (this.MedicalAnalysisID.HasValue);
        }

        private bool _UpdateMedicalAnalysis()
        {
            return clsMedicalAnalysesDataAccess.UpdateMedicalAnalysis(this.DTO);
        }

        public static clsMedicalAnalysis Find(int? ID)
        {
            clsMedicalAnalysisDTO dto = clsMedicalAnalysesDataAccess.GetMedicalAnalysisInfoByID(ID);

            if (dto != null)
                return new clsMedicalAnalysis(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsMedicalAnalysisDTO> GetAllMedicalAnalyses()
        {
            return clsMedicalAnalysesDataAccess.GetAllMedicalAnalyses();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMedicalAnalysis())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMedicalAnalysis();
            }

            return false;
        }

        public static bool DeleteMedicalAnalysis(int? ID)
        {
            return clsMedicalAnalysesDataAccess.DeleteMedicalAnalysis(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsMedicalAnalysesDataAccess.IsMedicalAnalysisExist(ID);
        }
    }
}