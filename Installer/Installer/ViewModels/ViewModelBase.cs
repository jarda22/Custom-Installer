using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
