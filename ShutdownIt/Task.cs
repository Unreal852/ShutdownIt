using ShutdownIt.Computer_Actions;
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

        public Task(IAction action, TimeSpan executeAt)
        {
            m_action = action;
            m_timeSpan = executeAt;
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
            if (DateTime.Now.ToTimeSpan() >= m_timeSpan)
            {
                m_timer.Stop();
                m_action.Execute();
            }
        }
    }
}
