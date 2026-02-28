using Installer.ViewModels.Interface.Install;

namespace Installer.ViewModels.Implementation.Install
{
    internal class InstallLandingPageViewModel : ViewModelBase, IInstallLandingPageViewModel
    {
        public string Name => "Install Landing Page";
        public bool CanNext => true;
        public bool CanBack => false;
        public bool CanFinish => false;
    }
}