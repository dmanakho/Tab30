using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Tab30.Models.Helpers
{
    public class Helpers
    {
        public static DateTime? ConvertToUTCTime(DateTime? localTime)
        {
            DateTime? _UTCTime = null;
            if (localTime.HasValue)
            {
                _UTCTime = localTime.Value.ToUniversalTime();
            }
            return _UTCTime;
        }
        public static DateTime? ConvertToLocalTime(DateTime? _UTCTime)
        {
            DateTime? _localTime = null;
            if (_UTCTime.HasValue)
            {
                _localTime = _UTCTime.Value.ToLocalTime();
            }
            return _localTime;
        }

        //returns list of ClassOff starting from this year (seniors) all the way 7 years ahead (6th graders).

        public static IEnumerable<int> ClassOfList()
        {
            var _currentYear = DateTime.Now.Year;

            var _classOff = new List<int>();

            for (int i = 0; i < 7; i++)
            {
                _classOff.Add(_currentYear += i);
            }
            return _classOff;
        }
        public enum OutOfCirculation
        {
           Destroyed =1,
           Stolen =2,
           Lost =3,
           GoneReasonUnknown =4
        }
    }
}