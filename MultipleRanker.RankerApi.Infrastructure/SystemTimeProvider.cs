using System;
using MultipleRanker.RankerApi.Interfaces;

namespace MultipleRanker.RankerApi.Infrastructure
{
    public class SystemTimeProvider : ITimeProvider
    {
        public DateTime GetDateTimeNowUtc()
        {
            return DateTime.UtcNow;
        }
    }
}
