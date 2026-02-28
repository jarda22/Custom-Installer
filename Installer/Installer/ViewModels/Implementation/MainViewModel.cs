using CommunityToolkit.Mvvm.Input;
using Installer.Data;
using Installer.Helpers;
using Installer.Interfaces;
using Installer.ViewModels.Interface;
using System.Collections.ObjectModel;
using Unity;

namespace Installer.ViewModels.Implementation
{
    internal class MainViewModel : ViewModelBase, IMainViewModel
    {
        private int currentPage = 0;

        private ObservableCollection<IInstallerPageBase> pageCollection;

        internal MainViewModel(IUnityContainer container, bool isInstallMode = true)
        {
            InstallData data = container.Resolve<InstallData>();

            string collectionName = "InstallPages";
            if (RegistryHelper.CheckLocallyInstalled(data.AppName) || RegistryHelper.CheckGloballyInstalled(data.AppName))
            {
                collectionName = "UninstallPages";
                RegistryHelper.DeleteLocalKey(data.AppName);
            }
            else
            {
                RegistryHelper.CreateLocalKey(data);
            }

            this.pageCollection = container.Resolve<ObservableCollection<IInstallerPageBase>>(collectionName);
        }

        public IInstallerPageBase CurrentPage => this.pageCollection[currentPage];

        public RelayCommand NextCommand => new(this.Next);

        public RelayCommand BackCommand => new(this.Back);

        public RelayCommand CancelCommand => new(this.Cancel);

        public RelayCommand FinishCommand => new(this.Finish);

        private void Finish()
        {
            // Reference a saving helper class that does all the things we want.
        }

        private void Cancel()
        {
            App.Current.Shutdown();
        }

        private void Back()
        {
            if (this.CurrentPage.CanBack && this.currentPage > 0)
            {
                this.currentPage--;
                this.RaisePropertyChanged(nameof(this.CurrentPage));
            }
        }

        private void Next()
        {
            if (this.CurrentPage.CanNext && this.currentPage < this.pageCollection.Count)
            {
                this.currentPage++;
                this.RaisePropertyChanged(nameof(this.CurrentPage));
            }
        }
    }
}