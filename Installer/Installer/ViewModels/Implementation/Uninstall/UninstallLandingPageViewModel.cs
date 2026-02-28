using Installer.ViewModels.Interface.Uninstall;

namespace Installer.ViewModels.Implementation.Uninstall
{
    internal class UninstallLandingPageViewModel : ViewModelBase, IUninstallLandingPage
    {
        public string Name => "Uninstall Landing Page";

        public bool CanNext => true;
        public bool CanBack => false;
        public bool CanFinish => false;
    }
}