using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmProgram.AlarmStates
{
    public interface IAlarmState
    {
        int Period { get; }        
        bool Run();
    }
}
