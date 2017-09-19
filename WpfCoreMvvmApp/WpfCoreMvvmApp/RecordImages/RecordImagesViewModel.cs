using System;
using System.Windows.Input;
using CoreMvvm;

namespace WpfCoreMvvmApp.RecordImages
{
    public class RecordImagesViewModel : BaseViewModel
    {
        private readonly RelayCommandAsync<string> _gotoSettingsCommand;

        public RecordImagesViewModel()
        {
            _gotoSettingsCommand = new RelayCommandAsync<string>(async x => _gotoSettings());
        }

        public ICommand GotoSettingsCommand { get { return _gotoSettingsCommand; } }
        public event Action OnGotoSettings = delegate { };
        
        private void _gotoSettings()
        {
            OnGotoSettings();
        }
    }
}