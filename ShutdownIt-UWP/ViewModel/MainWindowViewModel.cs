using ShutdownIt.Commands;
using ShutdownIt.Computer_Actions;
using ShutdownIt_UWP.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace ShutdownIt.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string m_selectTimeText = "Select Time";
        private string m_timeDescription = "Choose when you want to perform a action";
        private string m_actionDescription = "Choose the action to perform";
        private string m_startDescription = "Go";
        private string m_windowTitle = "ShutdownIt";

        private bool m_is24Hours = true;

        private ComboBoxItem m_timeWait;

        private ComboBoxItem m_action;

        private TimeSpan m_time;

        public MainWindowViewModel()
        {

        }

        public ICommand StartCommand => new RelayCommand(async (object obj) =>
        {
            if (SelectedTime == null || SelectedTimeWait == null || SelectedAction == null)
            {
                await MessageBox.Show("Missing Fields", "Please fill all requiered fields");
                return;
            }
            else if(Scheduler.HasAnyTaskStarted)
            {
                switch(await MessageBox.Show("Cancel Task", "Do you really want to cancel task ?", "Yes", "No"))
                {
                    case ContentDialogResult.Primary:
                        Scheduler.CancelTasks();
                        StartDescription = "Start";
                        WindowTitle = "ShutdownIt";
                        return;
                    case ContentDialogResult.Secondary:
                        return;
                }
            }

            TimeWait timeWait = (TimeWait)SelectedTimeWait.Content;
            IAction action = (IAction)SelectedAction.Content;

            if (timeWait == TimeWait.In)
            {
                TimeSpan executeTime = DateTime.Now.AddWithoutDays(SelectedTime).ToTimeSpan();
                Scheduler.Run(action, executeTime, this);
            }
            else
            {
                TimeSpan current = DateTime.Now.ToTimeSpan();
                TimeSpan executeTime = SelectedTime;
                if(executeTime.Hours < 01)
                {
                    executeTime = executeTime.Add(new TimeSpan(1, executeTime.Hours, executeTime.Minutes, executeTime.Seconds, executeTime.Milliseconds));
                }
                else if(executeTime <= current)
                {
                    await MessageBox.Show("Wrong Date", "You selected a date that is already passed");
                    return;
                }
                Scheduler.Run(action, executeTime, this);
            }
            StartDescription = "Cancel";
        });

        public string TimeDescription
        {
            get => m_timeDescription;
            set
            {
                if (m_timeDescription == value)
                    return;
                m_timeDescription = value;
                OnPropertyChanged(nameof(TimeDescription));
            }
        }

        public string ActionDescription
        {
            get => m_actionDescription;
            set
            {
                if (m_actionDescription == value)
                    return;
                m_actionDescription = value;
                OnPropertyChanged(nameof(ActionDescription));
            }
        }

        public string StartDescription
        {
            get => m_startDescription;
            set
            {
                if (m_startDescription == value)
                    return;
                m_startDescription = value;
                OnPropertyChanged(nameof(StartDescription));
            }
        }

        public string SelectTimeText
        {
            get => m_selectTimeText;
            set
            {
                if (m_selectTimeText == value)
                    return;
                m_selectTimeText = value;
                OnPropertyChanged(nameof(SelectTimeText));
            }
        }

        public string WindowTitle
        {
            get => m_windowTitle;
            set
            {
                if (m_windowTitle == value)
                    return;
                m_windowTitle = value;
                Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Title = value;
                OnPropertyChanged(nameof(WindowTitle));
            }
        }

        public bool Is24Hours
        {
            get => m_is24Hours;
            set
            {
                if (m_is24Hours == value)
                    return;
                m_is24Hours = value;
                OnPropertyChanged(nameof(Is24Hours));
            }
        }

        public TimeSpan SelectedTime
        {
            get => m_time;
            set
            {
                if (m_time == value)
                    return;
                m_time = value;
                OnPropertyChanged(nameof(SelectedTime));
            }
        }

        public ComboBoxItem SelectedTimeWait
        {
            get => m_timeWait;
            set
            {
                if (m_timeWait == value)
                    return;
                m_timeWait = value;
                OnPropertyChanged(nameof(SelectedTimeWait));
            }
        }

        public ComboBoxItem SelectedAction
        {
            get => m_action;
            set
            {
                if (m_action == value)
                    return;
                m_action = value;
                OnPropertyChanged(nameof(SelectedAction));
            }
        }

        public List<ComboBoxItem> TimeItems => new List<ComboBoxItem>() { new ComboBoxItem() { Content = TimeWait.At },
            new ComboBoxItem() { Content = TimeWait.In } };

        public List<ComboBoxItem> ActionItems => new List<ComboBoxItem>() { new ComboBoxItem() { Content =  new ShutdownAction() },
            new ComboBoxItem() { Content = new RebootAction() },
            new ComboBoxItem() { Content = new LockAction()},
            new ComboBoxItem() { Content = new LogOffAction() } };
    }
}
