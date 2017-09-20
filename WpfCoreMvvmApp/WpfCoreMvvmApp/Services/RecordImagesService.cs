using System;
using System.ComponentModel;
using System.Threading;

namespace WpfCoreMvvmApp.Services
{
    // background worker code taken from https://stackoverflow.com/a/30554133/379279
    public class RecordImagesService : IRecordImagesService
    {
        private static BackgroundWorker _backgroundWorker;
        private bool _saveIsRequired;

        public RecordImagesService()
        {
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _backgroundWorker.DoWork += _backgroundWorkerDoWork;
            _backgroundWorker.ProgressChanged += _backgroundWorkedProgressChanged;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorkerRunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync();
        }

        public event Action<int, string> OnImageRecorded = (imageNumber, status) => {};

        public void Save()
        {
            _saveIsRequired = true;
        }

        private void _backgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            RecordImages(e);
        }

        private void RecordImages(DoWorkEventArgs e)
        {
            for (int i = 0; i < 200; i++)
            {
                if (_backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (_saveIsRequired)
                {
                    _backgroundWorker.ReportProgress(i, "Image was saved");
                    _saveIsRequired = false;
                }
                else
                {
                    _backgroundWorker.ReportProgress(i, "Image recorded");
                }
                Thread.Sleep(1000);
            }
        }

        private void _backgroundWorkedProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnImageRecorded(e.ProgressPercentage, (string)e.UserState);
        }

        private void _backgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // handle background worker cancelled
            }
            else if (e.Error != null)
            {
                // handle background worked error
            }
            else
            {
                // handle background worked completed successfully
            }
        }
    }
}