using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AlarmProgram.AlarmStates
{
    public class RelaxState : IAlarmState
    {
        private readonly StateManager _manager;        
        private readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

        public RelaxState(StateManager manager)
        {
            this._manager = manager;
        }

        public int Period => 5;        

        public bool Run()
        {
            resetEvent.Reset();

            Console.WriteLine($"Relax {DateTime.Now}");
            using (var timer = new System.Timers.Timer(Period * 60 * 1000))
            {
                timer.AutoReset = false;                
                timer.Elapsed += (sender, e) =>
                {
                    foreach (var item in Enumerable.Repeat(0, 3))
                    {
                        SystemSounds.Beep.Play();
                        Thread.Sleep(3000);
                    }
                    resetEvent.Set();
                };
                timer.Start();             
                resetEvent.WaitOne();
            }
            _manager.State = new WorkState(_manager);
            return true;
        }
    }
}
