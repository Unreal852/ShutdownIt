using ShutdownIt.Computer_Actions;
using ShutdownIt.ViewModel;
using System;
using System.Windows.Forms;

namespace ShutdownIt
{
    public class Task
    {
        private Timer m_timer = new Timer();

        private TimeSpan m_timeSpan;

        private bool m_cancel = false;

        private IAction m_action;

        private MainWindowViewModel m_viewModel;

        public Task(IAction action, TimeSpan executeAt, MainWindowViewModel viewModel = null)
        {
            m_action = action;
            m_timeSpan = executeAt;
            m_viewModel = viewModel;
            m_timer.Tick += OnTick;
            m_timer.Enabled = true;
            m_timer.Interval = 1000;
            m_timer.Start();
        }

        public bool Cancel
        {
            get => m_cancel;
            set
            {
                m_cancel = value;
                if (m_cancel)
                    m_timer.Stop();
            }
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (Cancel)
                return;
            TimeSpan currentTime = DateTime.Now.ToTimeSpan();
            if (currentTime >= m_timeSpan)
            {
                m_timer.Stop();
                m_action.Execute();
            }
            if (m_viewModel != null)
            {
                TimeSpan remaining = currentTime > m_timeSpan ? (currentTime - m_timeSpan) : (m_timeSpan - currentTime);
                m_viewModel.WindowTitle = $"ShutdownIt - {remaining.Hours} {(remaining.Hours > 1 ? "Hours" : "Hour")} {remaining.Minutes} {(remaining.Minutes > 1 ? "Minutes" : "Minute")} {remaining.Seconds} {(remaining.Seconds > 1 ? "Secondes" : "Seconde")} Remaining";
            }
        }
    }
}
