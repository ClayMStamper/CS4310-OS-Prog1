using System;
using System.Collections.Generic;

namespace OS_Prog1 {


    public class Sim {

        public static Sim Singleton { get; private set; }

        protected List<Event> eventQueue;

        private Scheduler scheduler;

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

            scheduler.SetupProcesses();
            List<Process> processes = scheduler.processList;
            Process current = processes[0];
            float clock = 0, lastClock = 0, idleTime = 0;

            foreach (Event arrEvent in scheduler.arrivalEvents) {
                
                float arrTime = lastClock + arrEvent.time;
                
                if (arrTime < clock) { //arrival while current process is being serviced, send to scheduler
                    eventQueue.Add(arrEvent); //track the event for analytics
                    scheduler.ScheduleProcess(arrEvent.myProc); //process arrived - have scheduler handle
                }
                else {
                    lastClock = clock;
                    current = scheduler.DequeueReadyProcess();
                    clock += current.burst;
                }
            }

            while (scheduler.readyList.Count > 0) {
                
            }
            
        }

        private void GenerateReport() {
            
        }


    }
}