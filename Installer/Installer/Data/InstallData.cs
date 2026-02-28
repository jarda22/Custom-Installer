namespace Installer.Data
{
    internal class InstallData
    {
        public string AppName { get; set; } = "Test";

        public string AppVersion { get; set; } = "1.0.0";

        public string InstallLocation { get; set; } = @"C:\Test";

        public string UninstallLocation { get; set; } = @"C:\Test";
    }
}
