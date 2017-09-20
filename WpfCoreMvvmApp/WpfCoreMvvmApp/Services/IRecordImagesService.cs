using System;

namespace WpfCoreMvvmApp.Services
{
    public interface IRecordImagesService
    {   
        event Action<int, string> OnImageRecorded;
        void Save();
    }
}