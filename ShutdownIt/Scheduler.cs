using ShutdownIt.Computer_Actions;
using System;
using System.Collections.Generic;

namespace ShutdownIt
{
    public static class Scheduler
    {
        private static List<Task> m_tasks = new List<Task>();

        /// <summary>
        /// Run a new task
        /// </summary>
        /// <param name="action">Action to execute when the task is completed</param>
        /// <param name="executeTime">When to execute the action</param>
        public static void Run(IAction action, TimeSpan executeTime)
        {
            m_tasks.Add(new Task(action, executeTime));
        }

        /// <summary>
        /// Cancel all tasks
        /// </summary>
        public static void CancelTasks()
        {
            m_tasks.ForEach((Task t) => t.Cancel = true);
            m_tasks.Clear();
        }

        public static bool HasAnyTaskStarted => m_tasks.Count > 0;
    }
}
