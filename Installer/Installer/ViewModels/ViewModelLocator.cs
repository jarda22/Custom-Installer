using Installer.Data;
using Installer.Interfaces;
using Installer.ViewModels.Implementation;
using Installer.ViewModels.Implementation.Install;
using Installer.ViewModels.Implementation.Uninstall;
using Installer.ViewModels.Interface;
using Installer.ViewModels.Interface.Install;
using Installer.ViewModels.Interface.Uninstall;
using System.Collections.ObjectModel;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Installer.ViewModels
{
    internal class ViewModelLocator
    {
        private IUnityContainer container;

        internal ViewModelLocator()
        {
            this.container = new UnityContainer();
            this.container.RegisterType<IMainViewModel, MainViewModel>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IInstallLandingPageViewModel, InstallLandingPageViewModel>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IUninstallLandingPage, UninstallLandingPageViewModel>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<ISummaryPageViewModel, SummaryPageViewModel>(new ContainerControlledLifetimeManager());

            this.container.RegisterType<InstallData>(new ContainerControlledLifetimeManager());

            this.container.RegisterInstance("InstallPages", this.GetInstallPageCollection(), new ContainerControlledLifetimeManager());
            this.container.RegisterInstance("UninstallPages", this.GetUninstallPageCollection(), new ContainerControlledLifetimeManager());
        }

        public IMainViewModel MainViewModel => this.container.Resolve<MainViewModel>();

        private ObservableCollection<IInstallerPageBase> GetInstallPageCollection()
        {
            return new ObservableCollection<IInstallerPageBase>()
            {
                this.container.Resolve<InstallLandingPageViewModel>(),
                this.container.Resolve<SummaryPageViewModel>(),
            };
        }

        private ObservableCollection<IInstallerPageBase> GetUninstallPageCollection()
        {
            return new ObservableCollection<IInstallerPageBase>()
            {
                this.container.Resolve<UninstallLandingPageViewModel>(),
                this.container.Resolve<SummaryPageViewModel>(),
            };
        }
    }
}