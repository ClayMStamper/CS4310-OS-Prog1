using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    
    public enum EventType {Arrival, Completion, Slice}

    public class Event {
        
        public Process myProc;
        public EventType type;
        public double time;

        public Event(Process myProc, EventType type, double time) {
            this.myProc = myProc;
            this.type = type;
            this.time = time;
        }
        
        public Event(Process myProc, EventType type) {
            this.myProc = myProc;
            this.type = type;
            switch (type) {
                case EventType.Arrival:
                    time = myProc.arrival;
                    break;
                case EventType.Completion:
                    break;
                default:
                    
                    break;
            }
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

        public virtual void EnqueueReady(Process proc) { //insert into priority queue logic
            readyList.Insert(0, proc);
        }

        public virtual Process DequeueFromReady() {
            
            if (readyList.Count <= 0)
                return null;
            
            Process end = readyList[^1];
            readyList.Remove(end);
            return end;
            
        }

        public bool ReadyQueueEmpty() {
            return (readyList.Count <= 0);
        }
        
        public virtual void SetupProcesses() {    
            
            processGenerator = new ProcessGenerator(10);
            processGenerator.Generate();
            processList = processGenerator.processes;
            GetArrivalEvents();
            
        }

        private void GetArrivalEvents() {
            for (var i = 0; i < processList.Count; i++) {
                Process proc = processList[i];
                Event lastEvent = null;
                if (arrivalEvents.Count > 0)
                    lastEvent= arrivalEvents[i-1];
                double lastArrTime = lastEvent == null ? 0 : lastEvent.time;
                Event arrEvent = new Event(proc, EventType.Arrival, proc.arrival + lastArrTime);
                arrivalEvents.Add(arrEvent);
            }
        }

        public override string ToString() {
            return processGenerator.ToString();
        }
    }
}