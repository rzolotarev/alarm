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
    public class WorkState : IAlarmState
    {
        private readonly StateManager _manager;        
        private static ManualResetEvent resetEvent = new ManualResetEvent(false);                

        public WorkState(StateManager manager)
        {
            _manager = manager;
        }

        public int Period => 40;        

        public bool Run()
        {
            resetEvent.Reset();
            Console.WriteLine($"time to work {DateTime.Now}");
            using (var timer = new System.Timers.Timer(Period * 60 * 1000))
            {
                timer.AutoReset = false;
                timer.Elapsed += OnTimedEvent;
                timer.Start();
                resetEvent.WaitOne();
            }            
            _manager.State = new RelaxState(_manager);            
            return true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            foreach (var item in Enumerable.Repeat(0, 3))
            {
                SystemSounds.Beep.Play();
                Thread.Sleep(3000);
            }            
            resetEvent.Set();                        
        }
    }
}
