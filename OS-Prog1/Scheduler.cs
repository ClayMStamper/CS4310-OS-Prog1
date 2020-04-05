using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    
    public enum EventType {Arrival, Completion, Slice}

    public class Event {
        
        public Process myProc;
        public EventType type;
        public float time;

        public Event(Process myProc, EventType type, float time) {
            this.myProc = myProc;
            this.type = type;
            this.time = time;
        }

        public override string ToString() {
            
            string typeStr = "";
            switch (type) {
                case EventType.Arrival:
                    typeStr = "Arrival";
                    break;
                case EventType.Completion:
                    typeStr = "Completion";
                    break;
                case EventType.Slice:
                    typeStr = "Slice";
                    break;
            } //set type str
            
            string msg = $"\n========\nEvent: {myProc.id}";
            
            msg += $"\nMy type: {typeStr}";
            msg += $"\nMy time: {time}";
            msg += "\n==============\n";

            
            return msg;
        }
    }
    
    public class Scheduler {

        public List<Event> arrivalEvents = new List<Event>();
        public List<Process> processList = new List<Process>();
        public List<Process> readyList = new List<Process>(); //acts like a priority queue - this is my "readyQueue"
        
        protected float clock;
        protected ProcessGenerator processGenerator;

        public virtual void ScheduleProcess(Process proc) { //insert into priority queue logic
            readyList.Insert(0, proc);
        }

        public virtual Process DequeueReadyProcess() {
            
            if (readyList.Count <= 0)
                return null;
            
            Process end = readyList[^0];
            return end;
            
        }
        
        public virtual void SetupProcesses() {    
            
            processGenerator = new ProcessGenerator(10000);
            processGenerator.Generate();
            processList = processGenerator.processes;
            GetArrivalEvents();
            
        }

        private void GetArrivalEvents() {
            foreach (Process proc in processList) {
                Event arrEvent = new Event(proc, EventType.Arrival, proc.arrival);
                arrivalEvents.Add(arrEvent);
            }
        }

        

    }
}