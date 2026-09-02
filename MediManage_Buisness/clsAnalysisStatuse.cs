using MediManage_DataAccess;
using System.Collections.Generic;


namespace MediManage_Business
{
   

    public class clsAnalysisStatus
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsAnalysisStatusDTO AnalysisStatusDTO
        {
            get { return new clsAnalysisStatusDTO(this.AnalysisStatusID, this.AnalysisStatusName); }
        }

        public int? AnalysisStatusID { get; set; }
        public string AnalysisStatusName { get; set; }

        public clsAnalysisStatus(clsAnalysisStatusDTO dto, enMode cMode = enMode.AddNew)
        {
            this.AnalysisStatusID = dto.AnalysisStatusID;
            this.AnalysisStatusName = dto.AnalysisStatusName;
            this.Mode = cMode;
        }

        private bool _AddNewAnalysisStatus()
        {
            this.AnalysisStatusID = clsAnalysisStatuseData.AddNewAnalysisStatus(this.AnalysisStatusDTO);
            return (this.AnalysisStatusID.HasValue);
        }

        private bool _UpdateAnalysisStatus()
        {
            return clsAnalysisStatuseData.UpdateAnalysisStatus(this.AnalysisStatusDTO);
        }

        public static clsAnalysisStatus Find(int? ID)
        {
            clsAnalysisStatusDTO dto = clsAnalysisStatuseData.GetAnalysisStatusInfoByID(ID);

            if (dto != null)
                return new clsAnalysisStatus(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsAnalysisStatusDTO> GetAllAnalysisStatuses()
        {
            return clsAnalysisStatuseData.GetAllAnalysisStatuses();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAnalysisStatus())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAnalysisStatus();
            }

            return false;
        }

        public static bool DeleteAnalysisStatus(int? ID)
        {
            return clsAnalysisStatuseData.DeleteAnalysisStatus(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsAnalysisStatuseData.IsAnalysisStatusExist(ID);
        }
    }
}



