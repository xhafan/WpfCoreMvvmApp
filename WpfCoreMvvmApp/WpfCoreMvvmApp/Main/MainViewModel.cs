using CoreMvvm;
using WpfCoreMvvmApp.RecordImages;
using WpfCoreMvvmApp.Settings;

namespace WpfCoreMvvmApp.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly RecordImagesViewModel _recordImagesViewModel;
        private readonly SettingsViewModel _settingsViewModel;

        public MainViewModel(
            RecordImagesViewModel recordImagesViewModel,
            SettingsViewModel settingsViewModel
            )
        {
            _recordImagesViewModel = recordImagesViewModel;
            _settingsViewModel = settingsViewModel;

            _recordImagesViewModel.OnGotoSettings += _gotoSettings;

            CurrentViewModel = recordImagesViewModel;
        }

        private void _gotoSettings()
        {
            CurrentViewModel = _settingsViewModel;  
        }

        public BaseViewModel CurrentViewModel { get; private set; }
    }
}
