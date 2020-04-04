using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    
    public enum EventType {Arrival, Completion, Slice}

    public class Event {
        
        private Process myProc;
        private EventType type;
        private float time;

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

        public List<Event> events;
        protected float clock;
        protected ProcessGenerator processGenerator;

        public virtual void ScheduleProcesses() {
            
            processGenerator = new ProcessGenerator(10000);
            
        }

    }
}