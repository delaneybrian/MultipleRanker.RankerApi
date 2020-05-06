using System;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface ITimeProvider
    {
        DateTime GetDateTimeNowUtc();
    }
}
