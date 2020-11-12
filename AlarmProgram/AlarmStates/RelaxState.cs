using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmProgram.AlarmStates
{
    public class RelaxState : IAlarmState
    {
        private readonly StateManager _manager;

        public RelaxState(StateManager manager)
        {
            this._manager = manager;
        }

        public int Period => throw new NotImplementedException();

        public void Action(object state)
        {
            throw new NotImplementedException();
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }
    }
}
