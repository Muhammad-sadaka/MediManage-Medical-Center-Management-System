using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MediManage_DataAccess
{
    public static class clsDataAccessSettings
    {
        public static string sourceName = "MediManage";

        public static string ConnectionString { get; private set; }

        static clsDataAccessSettings()
        {
            try
            {
                // قراءة appsettings.json من مجلد التشغيل (bin/Debug أو bin/Release)
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                ConnectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? "Server=.;Database=MediManage;Integrated Security=True;TrustServerCertificate=True;";
            }
            catch (Exception ex)
            {
                // Fallback احتياطي في حال لم يتم العثور على الملف
                ConnectionString = "Server=.;Database=MediManage;Integrated Security=True;TrustServerCertificate=True;";

                EventLogCreate();
                EventLog.WriteEntry(sourceName, "Error loading connection string: " + ex.Message, EventLogEntryType.Error);
            }
        }

        public static void EventLogCreate()
        {
            try
            {
                if (!EventLog.SourceExists(sourceName))
                    EventLog.CreateEventSource(sourceName, "Application");
            }
            catch
            {
                // تجاهل أخطاء الصلاحيات
            }
        }
    }
}