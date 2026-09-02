using System.Collections.Generic;
using MediManage_DataAccess;

namespace MediManage_Business
{


    public class clsAnalysisType
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsAnalysisTypeDTO AnalysisTypeDTO
        {
            get { return new clsAnalysisTypeDTO(this.AnalysisTypeID, this.AnalysisTypeName, this.Price); }
        }

        public int? AnalysisTypeID { get; set; }
        public string AnalysisTypeName { get; set; }
        public decimal? Price { get; set; }

        public clsAnalysisType(clsAnalysisTypeDTO dto, enMode cMode = enMode.AddNew)
        {
            this.AnalysisTypeID = dto.AnalysisTypeID;
            this.AnalysisTypeName = dto.AnalysisTypeName;
            this.Price = dto.Price;
            this.Mode = cMode;
        }

        private bool _AddNewAnalysisType()
        {
            this.AnalysisTypeID = clsAnalysisTypeData.AddNewAnalysisType(this.AnalysisTypeDTO);
            return (this.AnalysisTypeID.HasValue);
        }

        private bool _UpdateAnalysisType()
        {
            return clsAnalysisTypeData.UpdateAnalysisType(this.AnalysisTypeDTO);
        }

        public static clsAnalysisType Find(int? ID)
        {
            clsAnalysisTypeDTO dto = clsAnalysisTypeData.GetAnalysisTypeInfoByID(ID);

            if (dto != null)
                return new clsAnalysisType(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsAnalysisTypeDTO> GetAllAnalysisTypes()
        {
            return clsAnalysisTypeData.GetAllAnalysisTypes();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAnalysisType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAnalysisType();
            }

            return false;
        }

        public static bool DeleteAnalysisType(int? ID)
        {
            return clsAnalysisTypeData.DeleteAnalysisType(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsAnalysisTypeData.IsAnalysisTypeExist(ID);
        }
    }
}