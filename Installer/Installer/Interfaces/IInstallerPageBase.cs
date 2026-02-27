using System.ComponentModel;

namespace Installer.Interfaces
{
    internal interface IInstallerPageBase : INotifyPropertyChanged
    {
        public string Name { get; }

        public bool CanNext { get; }

        public bool CanBack { get; }

        public bool CanFinish { get; }
    }
}
