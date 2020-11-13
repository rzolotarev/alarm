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
        const int maxExcercises = 10;
        private static int excercies = 0;

        public WorkState(StateManager manager)
        {
            _manager = manager;
        }

        public int Period => 1;        

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
            excercies++;
            _manager.State = new RelaxState(_manager);
            return excercies <= 10;            
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
