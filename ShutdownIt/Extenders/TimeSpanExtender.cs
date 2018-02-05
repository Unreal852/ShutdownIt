using System;

namespace ShutdownIt
{
    public static class TimeSpanExtender
    {
        /// <summary>
        /// Clear all days of a <see cref="TimeSpan"/> this is used to check timespan without days
        /// </summary>
        /// <param name="timeSpan">TimeSpan</param>
        /// <returns><see cref="TimeSpan"/></returns>
        public static TimeSpan ClearDays(this TimeSpan timeSpan)
        {
            return new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}
