using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs
{
    internal class AppointmentCaseDTO
    {
    }
    public class clsAppointmentCaseDTO
    {
        public int? AppointmentCaseID { get; set; }
        public string AppointmentCaseName { get; set; }

        public clsAppointmentCaseDTO(int? appointmentCaseID, string appointmentCaseName)
        {
            this.AppointmentCaseID = appointmentCaseID;
            this.AppointmentCaseName = appointmentCaseName;
        }
    }
}
