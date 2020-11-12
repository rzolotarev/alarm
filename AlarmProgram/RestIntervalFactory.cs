using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmProgram
{
    internal class RestIntervalFactory
    {
        private static int _counter = 0;
        public static TimeSpan Create()
        {
            if (_counter < 1)
            {
                _counter++;
                return TimeSpan.FromMinutes(5);
            }

            _counter = 0;
            return TimeSpan.FromMinutes(15);
        }
    }
}
