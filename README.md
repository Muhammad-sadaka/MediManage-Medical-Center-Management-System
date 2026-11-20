# 🏥 MediManage — Medical Center Management System

![Language](https://img.shields.io/badge/language-C%23-brightgreen)
![Desktop](https://img.shields.io/badge/desktop-Windows%20Forms%20(.NET%20Framework%204.8)-purple)
![API](https://img.shields.io/badge/API-ASP.NET%20Core%20Web%20API-blue)
![Database](https://img.shields.io/badge/database-SQL%20Server-red)
![Architecture](https://img.shields.io/badge/architecture-3--Tier-informational)
![License](https://img.shields.io/badge/license-MIT-green)

![MediManage](screenshots/Logo.png)

A medical center management system made of two independent applications: a **Windows Forms desktop app** and an **ASP.NET Core REST API** secured with JWT. Both share the same business layer and data access layer. The system covers patients, doctors, appointments, examinations, prescriptions, lab analyses, and billing.

| At a glance | |
|---|---|
| Database tables | 24 |
| Windows Forms | 34 |
| API controllers | 25+ |
| API endpoints | 170 |

---

## 🎯 What This Project Demonstrates

- A **3-tier** design where two different front ends (desktop and API) reuse one business layer
- A REST API with **JWT authentication** and permission-based access
- **Password hashing** with SHA-256 and a per-user salt
- Appointment scheduling with **conflict and time-overlap detection** enforced in a T-SQL stored procedure
- Workflow automation: completing an examination updates the appointment and generates invoice and lab-test records
- A relational SQL Server schema with stored procedures and auditing fields on the main tables

---

## ✨ Features

### People and users
- A central person registry, so personal data is never duplicated across roles
- User accounts with activation/deactivation and granular, per-module permissions

### Patients
- Register patients linked to existing person records
- Track chronic diseases, medication sensitivities, and patient status (Active / Deceased / Transferred)

### Doctors
- Profiles with specialty, license number, and qualifications
- Consultation fee per doctor
- Active/Inactive status with automatic handling of the doctor's appointments
- Filter by specialty

### Appointments
- Booking with conflict and overlap detection (see *Business Rules*)
- Working hours enforcement: Saturday to Thursday, 8 AM to 8 PM
- Status lifecycle: Booked → Completed / Cancelled / Absent
- Past booked appointments are marked **Absent** automatically on system startup
- Filter by date, doctor, and status

### Medical examinations
- Record symptoms, diagnosis, and vitals (blood pressure, temperature, heart rate, weight)
- Completing an examination marks its appointment as **Completed**
- Deleting an examination returns its appointment to **Booked**

### Prescriptions
- Multiple medicines per prescription with dosage, frequency, and duration
- Printable prescription form and a read-only view for history

### Lab analyses
- Request analyses from an examination, with configurable prices per type
- Status lifecycle: Pending → Completed, with result and result date

### Invoices and payments
- Invoices and lab-test records are generated automatically from the examination
- Itemized billing and printable invoice form
- Partial payments with full history; status updates automatically: Unpaid → Partial → Paid

### Dashboard
- Total patients, today's appointments, today's revenue, and the upcoming appointment list

---

## 📏 Business Rules

| Rule | Detail |
|------|--------|
| Doctor double-booking | A doctor cannot have two appointments at the same time |
| Time overlap | A new appointment cannot overlap the time range (`AppointmentDate` + `Duration`) of another appointment for the same doctor |
| Patient double-booking | A patient cannot have overlapping appointments, even with different doctors |
| Back-to-back | An appointment may start exactly when the previous one ends |
| Working hours | Saturday to Thursday, 8 AM to 8 PM |
| Absent appointments | Past booked appointments are marked Absent on startup |
| Examination → appointment | Completing an examination completes its appointment; deleting the examination reverts it to Booked |
| Payment status | Calculated from the total paid against the invoice total |

### How the overlap check works

Two time ranges overlap when each one starts before the other ends:

```sql
@NewStart < ExistingEnd  AND  @NewEnd > ExistingStart
```

`SP_AddNewAppointment` computes the new end time from `AppointmentDate` and `Duration` (in minutes), checks the doctor **or** the patient against existing appointments, and raises an error instead of inserting when a conflict exists.

---

## 🧱 Architecture

```
┌──────────────────────┐      ┌──────────────────────────┐
│  Desktop App         │      │  ASP.NET Core Web API    │
│  Windows Forms       │      │  25+ controllers, JWT    │
└──────────┬───────────┘      └────────────┬─────────────┘
           │                                │
           └───────────────┬────────────────┘
                           ▼
              ┌──────────────────────────┐
              │  Business Logic Layer    │  clsXxx.cs: validation, rules, enums
              └────────────┬─────────────┘
                           ▼
              ┌──────────────────────────┐
              │  Data Access Layer       │  clsXxxDAL.cs: ADO.NET + stored procedures
              └────────────┬─────────────┘
                           ▼
                  SQL Server (MediManage)
```

The desktop app and the API are independent of each other. They never call one another; each one reaches the database through the same business and data access layers.

---

## 🔐 Security

- **JWT** authentication on the API
- **Permission-based access**: each user receives only the modules they are allowed to use
- Passwords are stored as **SHA-256 + salt** hashes, never as plain text

### Permissions

| Permission | Grants access to |
|------------|------------------|
| Manage People | Person records |
| Manage Patients | Patient module |
| Manage Doctors | Doctor module |
| Manage Appointments | Booking and appointment management |
| Manage Examinations | Medical examinations |
| Manage Prescriptions | Prescriptions |
| Manage Analyses | Lab analyses |
| Manage Invoices & Payments | Billing and payments |
| Manage Users | User accounts |

---

## 🗄️ Database Design

The database is named **MediManage** and has **24 tables**. Main tables carry auditing fields: `CreatedByUserID`, `CreatedDate`, `ModifiedByUserID`, `ModifiedDate`.

| Group | Tables |
|-------|--------|
| Core | `People`, `Users`, `Patients`, `Doctors` |
| Operational | `Appointments`, `MedicalExaminations`, `MedicalPrescriptions`, `PrescriptionMedicines`, `MedicalAnalyses` |
| Financial | `Bills`, `BillItems`, `Payments` |
| Lookup | `Countries`, `BloodTypes`, `MaritalStatuses`, `Specialties`, `AppointmentStatuses`, `PatientCases`, `AnalysisTypes`, `AnalysisStatuses`, `ServiceTypes`, `PaymentStatuses`, `PaymentMethods`, `Medicines` |

`Appointments` columns: `AppointmentID`, `PatientID`, `DoctorID`, `CreatedByUserID`, `BookingDate`, `AppointmentDate`, `AppointmentCaseID`, `Duration`, `Reason`, `Notes`.

---

## 📸 Screenshots

| | |
|---|---|
| ![Login](screenshots/Login.png)<br>Login | ![Main Menu](screenshots/MainMenu.png)<br>Dashboard |
| ![People](screenshots/PeopleList.png)<br>People | ![Patients](screenshots/PatientsList.png)<br>Patients |
| ![Doctors](screenshots/DoctorsList.png)<br>Doctors | ![Appointments](screenshots/AppointmentsList.png)<br>Appointments |
| ![Examination](screenshots/MedicalExamination.png)<br>Examination | ![Prescription](screenshots/MedicalPrescription.png)<br>Prescription |
| ![Analyses](screenshots/MedicalAnalyses.png)<br>Lab analyses | ![Invoices](screenshots/Invoices.png)<br>Invoices |

---

## 🚀 Getting Started

### Requirements
- Windows 7 SP1 or newer
- Visual Studio 2022 with the **.NET desktop development** and **ASP.NET and web development** workloads
- .NET Framework 4.8 (desktop) and the .NET SDK matching the API project
- SQL Server 2014 or newer and SSMS

### 1. Clone
```bash
git clone https://github.com/<your-username>/<your-repo>.git
```

### 2. Create the database
Open the SQL script in the `Database` folder with SSMS and run it. It creates the **MediManage** database, tables, stored procedures, and seed data.

### 3. Configure the connection string
Set it in the project you run.

Desktop (`App.config`):
```xml
<connectionStrings>
  <add name="ConnectionString"
       connectionString="Server=.;Database=MediManage;Integrated Security=True;"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

API (`appsettings.json`):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=MediManage;Integrated Security=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "<a-long-random-secret>",
    "Issuer": "<issuer>",
    "Audience": "<audience>"
  }
}
```
Replace `Server=.` with your instance name (for example `.\SQLEXPRESS`).
> Never commit a real JWT key. Use user secrets or environment variables.

### 4. Run
Open the `.sln` file and build with `Ctrl + Shift + B`. Run the desktop project, the API project, or both. They work independently.

### Default admin account
```
Username: admin
Password: <your-default-password>
```
> Change it after the first login.

---

## 🧪 Daily Workflow

```
Book appointment → Examine patient → Prescription (if needed) → Lab analyses (if needed)
        → Invoice generated → Collect payment
```

---

## 📁 Project Structure

```
MediManage/
├── DataAccessLayer/       clsXxxDAL.cs   (ADO.NET, stored procedures)
├── BusinessLayer/         clsXxx.cs      (rules, validation, enums)
├── PresentationLayer/     frmXxx.cs      (34 forms, grouped by module)
├── API/                   Controllers, JWT, services
├── Database/              SQL script
└── screenshots/
```

---

## 🗺️ Roadmap

- [ ] Make the overlap check and the insert atomic (transaction with locking) to prevent simultaneous bookings
- [ ] Ignore cancelled appointments in the overlap check
- [ ] Replace SHA-256 with a slow password hash (PBKDF2 or Argon2)
- [ ] Refresh tokens for the API
- [ ] Unit tests for the business layer
- [ ] Report export to PDF and Excel

---

## 🤝 Contributing

1. Fork the repository
2. Create a branch: `git checkout -b feature/your-feature`
3. Commit your changes: `git commit -m "Add your feature"`
4. Push the branch and open a Pull Request

## 📄 License

Released under the [MIT License](LICENSE).

## 👤 Author

**Muhammad** — Junior Software Developer, Damascus, Syria
B.S. in Applied IT, Syrian Virtual University

- GitHub: [@Muhammad-sadaka](https://github.com/Muhammad-sadaka)
- LinkedIn: [@linkedin](https://linkedin.com/in/muhammad-al-sadaka-338956323
)