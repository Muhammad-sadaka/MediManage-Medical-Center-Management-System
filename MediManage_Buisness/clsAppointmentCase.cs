using System.Collections.Generic;
using MediManage_DataAccess;


namespace MediManage_Business
{

    public class clsAppointmentCase
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsAppointmentCaseDTO AppointmentCaseDTO
        {
            get { return new clsAppointmentCaseDTO(this.AppointmentCaseID, this.AppointmentCaseName); }
        }

        public int? AppointmentCaseID { get; set; }
        public string AppointmentCaseName { get; set; }

        public clsAppointmentCase(clsAppointmentCaseDTO dto, enMode cMode = enMode.AddNew)
        {
            this.AppointmentCaseID = dto.AppointmentCaseID;
            this.AppointmentCaseName = dto.AppointmentCaseName;
            this.Mode = cMode;
        }

        private bool _AddNewAppointmentCase()
        {
            this.AppointmentCaseID = clsAppointmentCaseData.AddNewAppointmentCase(this.AppointmentCaseDTO);
            return (this.AppointmentCaseID.HasValue);
        }

        private bool _UpdateAppointmentCase()
        {
            return clsAppointmentCaseData.UpdateAppointmentCase(this.AppointmentCaseDTO);
        }

        public static clsAppointmentCase Find(int? ID)
        {
            clsAppointmentCaseDTO dto = clsAppointmentCaseData.GetAppointmentCaseInfoByID(ID);

            if (dto != null)
                return new clsAppointmentCase(dto, enMode.Update);
            else
                return null;
        }

        public static List<clsAppointmentCaseDTO> GetAllAppointmentCases()
        {
            return clsAppointmentCaseData.GetAllAppointmentCases();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppointmentCase())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateAppointmentCase();
            }

            return false;
        }

        public static bool DeleteAppointmentCase(int? ID)
        {
            return clsAppointmentCaseData.DeleteAppointmentCase(ID);
        }

        public static bool IsExist(int? ID)
        {
            return clsAppointmentCaseData.IsAppointmentCaseExist(ID);
        }
    }
}