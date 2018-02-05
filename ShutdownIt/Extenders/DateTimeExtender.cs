using System;

namespace ShutdownIt
{
    public static class DateTimeExtender
    {
        /// <summary>
        /// Convert <see cref="DateTime"/> to a <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns><see cref="TimeSpan"/> Time</returns>
        public static TimeSpan ToTimeSpan(this DateTime date)
        {
            return TimeSpan.FromTicks(date.Ticks);
        }
    }
}
