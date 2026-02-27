using Installer.ViewModels.Interface.Uninstall;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
