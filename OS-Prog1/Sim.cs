using System;
using System.Collections.Generic;
using System.IO;

namespace OS_Prog1 {


    public class Sim {

        public static Sim Singleton { get; private set; }

        protected List<Event> eventQueue = new List<Event>();
        private Scheduler scheduler;
        
        List<Process> processes = new List<Process>();
            
        //initialize fields needed for loop
        private Process currentProcess;
        private double clock;
        private double nextClock, idleTime;

        public Sim(int schedulerType) {

            Singleton = this;

            Init(schedulerType);
            Run();
            GenerateReport();

        }

        private void Init(int schedulerType) {

            //Init Scheduler
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
            
            //generate list of processes
            scheduler.SetupProcesses();
            processes = scheduler.processList;
            
            //start first process
            currentProcess = processes[0];
            clock = currentProcess.arrival;
            nextClock = clock + currentProcess.burst;
            currentProcess.start = currentProcess.arrival;

        }

        private void Run() {

            
            foreach (Event arrEvent in scheduler.arrivalEvents) {

                arrEvent.myProc.arrival = arrEvent.time;
                
                //handle time-slice TODO
                
                //handle arrival 
                eventQueue.Add(arrEvent); 
                scheduler.EnqueueReady(arrEvent.myProc); //process arrived - have scheduler handle

                //handle completion
                if (arrEvent.time >= nextClock) 
                    StartProcess(scheduler.DequeueFromReady());
                
            }

            //handle ready queue once events are finished arriving
            while (!scheduler.ReadyQueueEmpty()) {
                StartProcess(scheduler.DequeueFromReady());
            }

            foreach (Event eve in eventQueue) {
//                Debug.Log($"{eve}");
            }

        }

        private void StartProcess(Process proc) {

//            proc.start = clock;
//            clock = nextClock;
//            nextClock = proc.start + proc.burst;

            proc.start = clock > proc.arrival ? clock : proc.arrival;
            clock = nextClock;
            nextClock = proc.start + proc.burst;
            
            //enqueue completion event for finished process
            if (currentProcess != null) {
                currentProcess.completion = clock;
                currentProcess.turnAround = currentProcess.completion - currentProcess.start;
                eventQueue.Add(new Event(currentProcess, EventType.Completion, nextClock));
            }
            
            

            currentProcess = proc;
            
        }

        private void GenerateReport() {

            StreamWriter writer = new StreamWriter("./sim.data");
            writer.Write("");
            
            foreach (Process process in processes) {
                writer.WriteLine(process);
//                Debug.Log($"{process}");
            }
            

        }


    }
}