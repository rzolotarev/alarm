using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmProgram.AlarmStates
{
    public class StateManager
    {        
        public IAlarmState State { get; set; }

        public StateManager()
        {
            State = new WorkState(this);
        }

        public void Run()
        {
            while(State.Run())
            {

            }
        }
    }
}
