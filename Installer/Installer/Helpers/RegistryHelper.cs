using Installer.Data;
using Microsoft.Win32;
using System.IO;

namespace Installer.Helpers
{
    internal static class RegistryHelper
    {
        public static string Current_User_Uninstall => @"Software\Microsoft\Windows\CurrentVersion\Uninstall";

        public static string Local_Machine_Uninstall => @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

        public static bool CheckLocallyInstalled(string appName)
        {
            using (RegistryKey? uninstallKey = Registry.CurrentUser.OpenSubKey(Current_User_Uninstall))
            {
                if (uninstallKey != null)
                {
                    using (RegistryKey? appKey = uninstallKey.OpenSubKey(appName))
                    {
                        if (appKey != null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool CheckGloballyInstalled(string appName)
        {
            using (RegistryKey? uninstallKey = Registry.LocalMachine.OpenSubKey(Local_Machine_Uninstall))
            {
                if (uninstallKey != null)
                {
                    using (RegistryKey? appKey = uninstallKey.OpenSubKey(appName))
                    {
                        if (appKey != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool CreateLocalKey(InstallData appData)
        {
            using (RegistryKey appKey = Registry.CurrentUser.CreateSubKey(Path.Combine(Current_User_Uninstall, appData.AppName)))
            {
                if (appKey != null)
                {
                    appKey.SetValue("DisplayName", appData.AppName);
                    appKey.SetValue("DisplayVersion", appData.AppVersion);
                    appKey.SetValue("InstallLocation", appData.InstallLocation);
                    appKey.SetValue("UninstallLocation", appData.UninstallLocation);
                    appKey.SetValue("NoModify", 1);
                    appKey.SetValue("NoRepair", 1);
                    appKey.Close();

                    return true;
                }
            }

            return false;
        }

        public static bool DeleteLocalKey(string keyName) 
        {
            string appPath = Path.Combine(Current_User_Uninstall, keyName);

            using (RegistryKey? appKey = Registry.CurrentUser.OpenSubKey(appPath))
            {
                if (appKey != null)
                {
                    Registry.CurrentUser.DeleteSubKey(appPath);
                }
            }

            return false;
        }

        public static bool DeleteGlobalKey(string keyName)
        {
            string appPath = Path.Combine(Local_Machine_Uninstall, keyName);

            using (RegistryKey? appKey = Registry.LocalMachine.OpenSubKey(appPath))
            {
                if (appKey != null)
                {
                    Registry.CurrentUser.DeleteSubKey(appPath);
                }
            }

            return false;
        }
    }
}