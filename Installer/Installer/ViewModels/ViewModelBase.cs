using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace Installer.ViewModels
{
    internal class ViewModelBase : ObservableObject
    {
        public void RaisePropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public new event PropertyChangedEventHandler? PropertyChanged;
    }
}