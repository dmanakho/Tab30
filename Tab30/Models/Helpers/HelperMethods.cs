using System;


namespace Tab30.Models.Helpers
{
    public static class HelperMethods
    {
        public static DateTime? ConvertToUTC(DateTime? localTime)
        {
            DateTime? _UTCTime = null;
            if (localTime.HasValue)
            {
                _UTCTime = localTime.Value.ToUniversalTime();
            }
            return _UTCTime;
        }
        public static DateTime? ConvertToLocal(DateTime? _UTCTime)
        {
            DateTime? _localTime = null;
            if (_UTCTime.HasValue)
            {
                _localTime = _UTCTime.Value.ToLocalTime();
            }
            return _localTime;
        }

    }
}
