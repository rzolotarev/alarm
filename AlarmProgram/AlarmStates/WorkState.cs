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
        private readonly System.Timers.Timer _timer = new System.Timers.Timer();
        private static ManualResetEvent resetEvent = new ManualResetEvent(false);

        public WorkState(StateManager manager)
        {
            _manager = manager;
        }

        public int Period => 40;        

        public bool Run()
        {
            Console.WriteLine($"working {DateTime.Now}");             
            _timer.Interval = Period * 40 * 1000;
            _timer.Elapsed += OnTimedEvent;
            _timer.Start();
            _timer.AutoReset = false;
            resetEvent.WaitOne();
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
