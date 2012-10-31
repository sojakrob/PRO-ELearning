using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Utils
{
    public static class Conversion
    {
        private const int SECS_PER_MINUTE = 60;


        public static int MinutesToSeconds(int minutes)
        {
            return minutes * SECS_PER_MINUTE;
        }
        public static int SecondsToMinutes(int seconds)
        {
            return seconds / SECS_PER_MINUTE;
        }
    }
}