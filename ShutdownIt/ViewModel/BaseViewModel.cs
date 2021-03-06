﻿using System.ComponentModel;

namespace ShutdownIt.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {

        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null && !string.IsNullOrWhiteSpace(propertyName))
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
