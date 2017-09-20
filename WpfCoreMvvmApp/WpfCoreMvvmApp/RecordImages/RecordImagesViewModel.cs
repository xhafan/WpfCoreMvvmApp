using System;
using System.Windows;
using System.Windows.Input;
using CoreMvvm;
using WpfCoreMvvmApp.Services;

namespace WpfCoreMvvmApp.RecordImages
{
    public class RecordImagesViewModel : BaseViewModel
    {
        private readonly RelayCommandAsync<string> _gotoSettingsCommand;
        private readonly RelayCommandAsync<string> _saveImagesCommand;
        private readonly IRecordImagesService _recordImagesService;

        public RecordImagesViewModel(
            IRecordImagesService recordImagesService
            )
        {
            _recordImagesService = recordImagesService;
            _recordImagesService.OnImageRecorded += _recordImagesServiceOnOnImageRecorded;

            _gotoSettingsCommand = new RelayCommandAsync<string>(async x => _gotoSettings());
            _saveImagesCommand = new RelayCommandAsync<string>(async x => _saveImages());
        }

        public ICommand GotoSettingsCommand => _gotoSettingsCommand;
        public ICommand SaveImagesCommand => _saveImagesCommand;
        public event Action OnGotoSettings = delegate { };
        public int ImageNumber { get; private set; }
        public string Status { get; private set; }

        private void _gotoSettings()
        {
            OnGotoSettings();
        }

        private void _saveImages()
        {
            _recordImagesService.Save();
        }

        private void _recordImagesServiceOnOnImageRecorded(int imageNumber, string status)
        {
            ImageNumber = imageNumber;
            Status = status;
        }
    }
}