using System;
using System.Collections.Generic;

namespace OS_Prog1 {


    public class Sim {

        public static Sim Singleton { get; private set; }

        protected Queue<Event> eventQueue;
        private float lambda, serviceTime, quantum;

        private Scheduler scheduler;
        private float clock;

        public Sim(int schedulerType) {

            Singleton = this;

            Init(schedulerType);
            Run();
            GenerateReport();

        }

        private void Init(int schedulerType) {

            switch (schedulerType) {
                case 1:
                    scheduler = new FCFS();
                    break;
                case 2:
                    scheduler = new SRTF();
                    break;
                case 3:
                    scheduler = new HRRN();
                    break;
                case 4:
                    scheduler = new RR();
                    break;
                default:
                    scheduler = new Scheduler(); //shouldn't ever happen
                    break;
            }

        }

        private void Run() {

            scheduler.ScheduleProcesses();

        }

        private void GenerateReport() {
            
        }


    }
}