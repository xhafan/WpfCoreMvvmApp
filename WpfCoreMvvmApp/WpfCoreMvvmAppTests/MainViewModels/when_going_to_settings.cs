using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfCoreMvvmApp.Main;
using WpfCoreMvvmApp.RecordImages;
using WpfCoreMvvmApp.Settings;

namespace WpfCoreMvvmAppTests.MainViewModels
{
    [TestClass]
    public class when_going_to_settings
    {
        [TestMethod]
        public void current_viewmodel_is_notified()
        {
            var currentViewModelIsNotified = false;
            var recordImage = new RecordImagesViewModel();
            var main = new MainViewModel(
                recordImage,
                new SettingsViewModel()
                );
            main.PropertyChanged += (s, e) => 
                {
                    if (e.PropertyName == "CurrentViewModel")
                    {
                        currentViewModelIsNotified = true;
                    }
                };
            recordImage.GotoSettingsCommand.Execute(null);

            Assert.IsTrue(currentViewModelIsNotified);
        }
    }
}
