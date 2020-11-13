using AlarmProgram.AlarmStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var stateManager = new StateManager();
            stateManager.Run();
        }
    }
}
