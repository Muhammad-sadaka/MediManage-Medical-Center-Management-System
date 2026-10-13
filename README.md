# 🏥 Clinic Management System

<div align="center">

![Clinic Management System](screenshots/Logo.png)

**A comprehensive desktop application for managing medical clinics**  
Built with C# Windows Forms · SQL Server · 3-Tier Architecture

[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey.svg)](https://www.microsoft.com/windows)
[![Framework](https://img.shields.io/badge/.NET_Framework-4.8-purple.svg)](https://dotnet.microsoft.com)
[![Database](https://img.shields.io/badge/Database-SQL_Server-red.svg)](https://www.microsoft.com/sql-server)
[![Language](https://img.shields.io/badge/Language-C%23-brightgreen.svg)](https://docs.microsoft.com/en-us/dotnet/csharp)

</div>

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Screenshots](#-screenshots)
- [System Requirements](#-system-requirements)
- [Installation](#-installation)
- [Project Structure](#-project-structure)
- [Database Design](#-database-design)
- [Usage](#-usage)
- [Technologies Used](#-technologies-used)
- [Author](#-author)

---

## 🔍 Overview

**Clinic Management System** is a full-featured desktop application designed to streamline the daily operations of a medical clinic. It provides a complete solution for managing patients, doctors, appointments, medical examinations, prescriptions, lab analyses, and billing — all within a clean, intuitive interface.

The system is built using **3-Tier Architecture** ensuring separation of concerns between the Data Access Layer, Business Logic Layer, and Presentation Layer, making it maintainable, scalable, and easy to extend.

---

## ✨ Features

### 👤 People & Users Management
- Centralized person registry — no duplication across roles
- Full user account management with role-based permissions
- Support for activating/deactivating user accounts
- Granular permission control per module

### 🏥 Patient Management
- Register new patients linked to existing person records
- Track chronic diseases and medication sensitivities
- Full medical history per patient
- Patient status tracking (Active / Deceased / Transferred)

### 👨‍⚕️ Doctor Management
- Doctor profiles with specialty, license number, and qualifications
- Configurable consultation fees per doctor
- Active/Inactive status with automatic appointment handling
- Filter doctors by specialty

### 📅 Appointment Scheduling
- Book appointments with conflict detection (same doctor/patient, same time)
- Working hours enforcement (Saturday–Thursday, 8 AM – 8 PM)
- Auto-mark absent appointments on system startup
- Real-time status tracking: Booked → Completed / Cancelled / Absent
- Filter by date, doctor, and status

### 🩺 Medical Examinations
- Record examination details: symptoms, diagnosis, vitals
- Auto-updates linked appointment status to Completed
- Supports rollback: deleting an examination reverts appointment to Booked
- Vitals tracking: blood pressure, temperature, heart rate, weight

### 💊 Medical Prescriptions
- Create prescriptions linked to examinations
- Add multiple medicines with dosage, frequency, and duration
- Printable prescription format
- View-only mode for historical records

### 🧪 Medical Analyses
- Request lab analyses linked to examinations
- Status lifecycle: Pending → Completed
- Record and update results with result date
- Supports multiple analysis types with configurable pricing

### 💰 Invoices & Payments
- Auto-generate invoices upon examination completion
- Itemized billing (consultation, analyses, radiology, etc.)
- Partial payment support with full payment history
- Auto-update payment status: Unpaid → Partial → Paid

### 📊 Dashboard
- Daily statistics: total patients, today's appointments, today's revenue
- Today's upcoming appointments at a glance
- Instant overview upon login

---

## 📸 Screenshots

### Login Screen
![Login](screenshots/Login.png)

### Main Dashboard
![Main Menu](screenshots/MainMenu.png)

### People List
![People List](screenshots/PeopleList.png)

### Add New Person
![Add Person](screenshots/AddPerson.png)

### Patients List
![Patients List](screenshots/PatientsList.png)

### Add New Patient
![Add Patient](screenshots/AddPatient.png)

### Doctors List
![Doctors List](screenshots/DoctorsList.png)

### Add New Doctor
![Add Doctor](screenshots/AddDoctor.png)

### Appointments List
![Appointments List](screenshots/AppointmentsList.png)

### Add New Appointment
![Add Appointment](screenshots/AddAppointment.png)

### Medical Examination
![Medical Examination](screenshots/MedicalExamination.png)

### Medical Prescription
![Medical Prescription](screenshots/MedicalPrescription.png)

### Medical Analyses
![Medical Analyses](screenshots/MedicalAnalyses.png)

### Invoices & Payments
![Invoices](screenshots/Invoices.png)

### Users Management
![Users](screenshots/Users.png)

---

## 💻 System Requirements

| Component | Requirement |
|-----------|-------------|
| **OS** | Windows 7 / 8 / 10 / 11 |
| **Framework** | .NET Framework 4.8 |
| **Database** | SQL Server 2014 or later |
| **RAM** | 4 GB minimum |
| **Storage** | 100 MB free space |
| **Screen** | 1280 × 720 minimum resolution |

---

## 🚀 Installation

### Step 1: Clone the Repository
```bash
git clone https://github.com/YourUsername/ClinicManagementSystem.git
```

### Step 2: Set Up the Database
1. Open **SQL Server Management Studio (SSMS)**
2. Open the file:
```
Database/ClinicManagementSystem_Corrected.sql
```
3. Press **F5** to execute
4. Verify that the database `ClinicManagementSystem` was created successfully

### Step 3: Configure Connection String
Open `App.config` in the project and update the connection string:
```xml
<connectionStrings>
  <add name="ConnectionString"
       connectionString="Server=YOUR_SERVER_NAME;
                         Database=ClinicManagementSystem;
                         Integrated Security=True;"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```
> Replace `YOUR_SERVER_NAME` with your SQL Server instance name (e.g., `.` or `DESKTOP-XXX\SQLEXPRESS`)

### Step 4: Build & Run
1. Open `ClinicManagementSystem.sln` in **Visual Studio**
2. Build the solution: `Ctrl + Shift + B`
3. Run the application: `F5`

### Default Admin Account
```
Username : admin
Password : admin123
```
> ⚠️ Please change the default password after first login.

---

## 📁 Project Structure

```
ClinicManagementSystem/
│
├── 📁 DataAccessLayer/
│   ├── clsDataAccessSettings.cs      ← Connection string configuration
│   ├── clsPersonDAL.cs
│   ├── clsUserDAL.cs
│   ├── clsPatientDAL.cs
│   ├── clsDoctorDAL.cs
│   ├── clsAppointmentDAL.cs
│   ├── clsMedicalExaminationDAL.cs
│   ├── clsPrescriptionDAL.cs
│   ├── clsMedicalAnalysisDAL.cs
│   ├── clsBillDAL.cs
│   └── clsPaymentDAL.cs
│
├── 📁 BusinessLayer/
│   ├── clsPerson.cs
│   ├── clsUser.cs
│   ├── clsCurrentUser.cs             ← Logged-in user session
│   ├── clsPatient.cs
│   ├── clsDoctor.cs
│   ├── clsAppointment.cs
│   ├── clsMedicalExamination.cs
│   ├── clsPrescription.cs
│   ├── clsMedicalAnalysis.cs
│   ├── clsBill.cs
│   └── clsPayment.cs
│
├── 📁 PresentationLayer/
│   ├── frmLogin.cs
│   ├── frmMain.cs                    ← Main window with sidebar navigation
│   ├── 📁 People/
│   │   ├── frmPeopleList.cs
│   │   └── frmAddEditPerson.cs
│   ├── 📁 Patients/
│   │   ├── frmPatientsList.cs
│   │   └── frmAddEditPatient.cs
│   ├── 📁 Doctors/
│   │   ├── frmDoctorsList.cs
│   │   └── frmAddEditDoctor.cs
│   ├── 📁 Appointments/
│   │   ├── frmAppointmentsList.cs
│   │   └── frmAddEditAppointment.cs
│   ├── 📁 MedicalExaminations/
│   │   ├── frmExaminationsList.cs
│   │   └── frmAddEditExamination.cs
│   ├── 📁 Prescriptions/
│   │   ├── frmPrescriptionsList.cs
│   │   └── frmAddEditPrescription.cs
│   ├── 📁 Analyses/
│   │   ├── frmAnalysesList.cs
│   │   └── frmAddEditAnalysis.cs
│   ├── 📁 Invoices/
│   │   ├── frmInvoicesList.cs
│   │   ├── frmAddInvoice.cs
│   │   └── frmViewInvoice.cs
│   └── 📁 Users/
│       ├── frmUsersList.cs
│       └── frmAddEditUser.cs
│
├── 📁 Database/
│   └── ClinicManagementSystem_Corrected.sql
│
├── 📁 screenshots/
│   └── (application screenshots)
│
└── README.md
```

---

## 🗄️ Database Design

The database consists of **24 tables** organized into logical groups:

### Core Tables
| Table | Description |
|-------|-------------|
| `People` | Central registry for all persons in the system |
| `Users` | System user accounts and permissions |
| `Patients` | Patient-specific information |
| `Doctors` | Doctor profiles and specialties |

### Operational Tables
| Table | Description |
|-------|-------------|
| `Appointments` | Scheduled appointments |
| `MedicalExaminations` | Examination records and vitals |
| `MedicalPrescriptions` | Prescription headers |
| `PrescriptionMedicines` | Medicines per prescription (Junction) |
| `MedicalAnalyses` | Lab analysis requests and results |

### Financial Tables
| Table | Description |
|-------|-------------|
| `Bills` | Invoice headers |
| `BillItems` | Line items per invoice (Junction) |
| `Payments` | Payment transactions |

### Lookup Tables
| Table | Description |
|-------|-------------|
| `Countries` | Country list |
| `BloodTypes` | Blood type options |
| `MaritalStatuses` | Marital status options |
| `Specialties` | Doctor specialties with default fees |
| `AppointmentStatuses` | Appointment status values |
| `PatientCases` | Patient status values |
| `AnalysisTypes` | Lab analysis types with prices |
| `AnalysisStatuses` | Analysis status values |
| `ServiceTypes` | Billing service type categories |
| `PaymentStatuses` | Invoice payment status values |
| `PaymentMethods` | Payment method options |
| `Medicines` | Medicine reference list |

> ✅ All main tables include **Auditing Fields**:  
> `CreatedByUserID`, `CreatedDate`, `ModifiedByUserID`, `ModifiedDate`

---

## 📖 Usage

### First Time Setup
1. Log in with the default admin account
2. Go to **People** → Add your staff members
3. Go to **Users** → Create accounts for your staff
4. Go to **Doctors** → Register your doctors
5. Start booking appointments!

### Daily Workflow
```
Patient arrives
      ↓
Book Appointment (Appointments → Add New)
      ↓
Doctor examines patient
      ↓
Add Examination (Medical Examinations → Add New)
      ↓
Write Prescription if needed (Medical Prescriptions → Add New)
      ↓
Order Lab Tests if needed (Medical Analyses → Add New)
      ↓
Generate Invoice (Invoices → Add New)
      ↓
Collect Payment (Invoices → View → Add Payment)
```

### Permission Levels
| Permission | Description |
|------------|-------------|
| Manage People | Add/Edit/Delete person records |
| Manage Patients | Access patient module |
| Manage Doctors | Access doctor module |
| Manage Appointments | Book and manage appointments |
| Manage Examinations | Record medical examinations |
| Manage Prescriptions | Write and view prescriptions |
| Manage Analyses | Order and update lab analyses |
| Manage Invoices & Payments | Handle billing and payments |
| Manage Users | Create and manage user accounts |

---

## 🛠️ Technologies Used

| Technology | Version | Purpose |
|------------|---------|---------|
| **C#** | 7.0+ | Primary programming language |
| **Windows Forms** | .NET 4.8 | Desktop UI framework |
| **SQL Server** | 2014+ | Relational database |
| **ADO.NET** | - | Database connectivity |
| **3-Tier Architecture** | - | Application design pattern |

---

## 🏗️ Architecture

```
┌─────────────────────────────────────────┐
│         Presentation Layer (UI)          │
│      Windows Forms · frmXxx.cs files    │
└──────────────────┬──────────────────────┘
                   │ uses
┌──────────────────▼──────────────────────┐
│         Business Logic Layer (BL)        │
│         clsXxx.cs · Validation          │
│         Business Rules · Enums          │
└──────────────────┬──────────────────────┘
                   │ uses
┌──────────────────▼──────────────────────┐
│        Data Access Layer (DAL)           │
│    clsXxxDAL.cs · ADO.NET · SQL Server  │
└─────────────────────────────────────────┘
```

---

## 👨‍💻 Author

**Muhammad**

- 🌍 Damascus, Syria
- 💼 Junior Software Developer
- 🎓 B.S. in Applied IT — Syrian Virtual University
- 📧 your.email@example.com
- 🐙 [GitHub](https://github.com/YourUsername)
- 💼 [LinkedIn](https://linkedin.com/in/YourProfile)

---

## 📄 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.

---

<div align="center">

**⭐ If you found this project helpful, please give it a star! ⭐**

Made with ❤️ by Muhammad

</div>
