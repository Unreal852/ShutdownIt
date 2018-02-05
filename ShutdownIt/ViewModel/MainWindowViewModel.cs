using ExtraTools;
using ShutdownIt.Commands;
using ShutdownIt.Computer_Actions;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShutdownIt.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string m_selectTimeText = "Select Time";
        private string m_timeDescription = "Choose when you want to perform a action";
        private string m_actionDescription = "Choose the action to perform";
        private string m_startDescription = "Go";

        private bool m_is24Hours = true;

        private ComboBoxItem m_timeWait;

        private ComboBoxItem m_action;

        private DateTime m_time;

        public MainWindowViewModel()
        {

        }

        public ICommand StartCommand => new RelayCommand((object obj) =>
        {
            if (SelectedTime == null || SelectedTimeWait == null || SelectedAction == null)
            {
                DialogBox.Show("Missing Fields", "Please fill all requiered fields");
                return;
            }
            else if(Scheduler.HasAnyTaskStarted)
            {
                switch(DialogBox.Show("Cancel", "Cancel Tasks ?", "Yes", "No"))
                {
                    case DialogBox.ResultEnum.LeftButtonClicked:
                        Scheduler.CancelTasks();
                        StartDescription = "Start";
                        return;
                    case DialogBox.ResultEnum.RightButtonClicked:
                        return;
                }
            }

            TimeWait timeWait = (TimeWait)SelectedTimeWait.Content;
            IAction action = (IAction)SelectedAction.Content;

            if (timeWait == TimeWait.In)
            {
                TimeSpan executeTime = DateTime.Now.Add(SelectedTime.ToTimeSpan()).ToTimeSpan();
                Scheduler.Run(action, executeTime);
            }
            else
                Scheduler.Run(action, SelectedTime.ToTimeSpan());
            StartDescription = "Cancel";
        });

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
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public DateTime SelectedTime
        {
            get => m_time;
            set
            {
                if (m_time == value)
                    return;
                m_time = value;
                OnPropertyChanged(nameof(SelectedTime));
                CommandManager.InvalidateRequerySuggested();
            }
        }

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

        public List<ComboBoxItem> TimeItems => new List<ComboBoxItem>() { new ComboBoxItem() { Content = TimeWait.At },
            new ComboBoxItem() { Content = TimeWait.In } };

        public List<ComboBoxItem> ActionItems => new List<ComboBoxItem>() { new ComboBoxItem() { Content =  new ShutdownAction() },
            new ComboBoxItem() { Content = new RebootAction() },
            new ComboBoxItem() { Content = new LockAction()},
            new ComboBoxItem() { Content = new LogOffAction() } };
    }
}
