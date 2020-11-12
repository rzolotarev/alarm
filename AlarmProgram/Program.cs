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
            var alarmThread = new Thread(() => AlarmHandler());

            alarmThread.Start();
            alarmThread.Join();
        }

        static void AlarmHandler()
        {
            var stateManager = new StateManager();
            stateManager.Run();            
        }

        static void RunAlarmTimer()
        {
            var startTime = DateTime.Now;
            var currentTime = DateTime.Now;
            while (currentTime < startTime.AddHours(8))
            {
                Console.WriteLine($"working {DateTime.Now}");
                Thread.Sleep(TimeSpan.FromMinutes(40));
                foreach(var item in Enumerable.Repeat(0, 3))
                {
                    SystemSounds.Beep.Play();
                    Thread.Sleep(3000);
                }

                Console.WriteLine($"resting {DateTime.Now}");
                Thread.Sleep(RestIntervalFactory.Create());
                foreach (var item in Enumerable.Repeat(0, 3))
                {
                    SystemSounds.Beep.Play();
                    Thread.Sleep(3000);
                }
                currentTime = DateTime.Now;
            }

            Console.WriteLine($"the end of the work day {DateTime.Now}");
        }


    }
}
