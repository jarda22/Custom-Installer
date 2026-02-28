using Installer.ViewModels.Interface;

namespace Installer.ViewModels.Implementation
{
    internal class SummaryPageViewModel : ViewModelBase, ISummaryPageViewModel
    {
        public string Name => "Summary Page";

        public bool CanNext => false;

        public bool CanBack => true;

        public bool CanFinish => true;
    }
}