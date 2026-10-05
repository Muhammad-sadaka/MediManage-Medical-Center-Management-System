using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using MediManage_Business;

namespace MediManage
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser;

        private static string EncryptString(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return "";
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedData = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(encryptedData);
            }
            catch
            {
                return "";
            }
        }

        private static string DecryptString(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return "";
            try
            {
                byte[] encryptedData = Convert.FromBase64String(encryptedText);
                byte[] data = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(data);
            }
            catch
            {
                return "";
            }
        }

        public static bool RememberUsernameAndPasswordInRegistry(string Username, string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\MediManage";
            string valueName = "MediManageLogin";

            string encryptedPassword = EncryptString(Password);

            string dataToSave = Username + "#//#" + encryptedPassword;
            try
            {
                if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
                {
                    dataToSave = "";
                }

                Registry.SetValue(KeyPath, valueName, dataToSave, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred {ex.Message}", "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool GetStoredCredentialFromRegistry(ref string Username, ref string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\MediManage";
            string valueName = "MediManageLogin";
            try
            { 
                string value = Registry.GetValue(KeyPath, valueName, null) as string;
                if (!string.IsNullOrEmpty(value))
                {
                    string[] result = value.Split(new string[] { "#//#" }, StringSplitOptions.None);
                    if (result.Length == 2)
                    {
                        Username = result[0];
                        Password = DecryptString(result[1]);

                        if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                            return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred {ex.Message}", "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}