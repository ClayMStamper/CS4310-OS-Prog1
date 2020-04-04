using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    public class FCFS : Scheduler{
        public FCFS(float lambda, float serviceTime, float quantum) : base(lambda, serviceTime, quantum) {
            
        }

        protected override void ScheduleEvent(Event eve) {

            for (int i = 0; i < eventQueue.Count; i++) {
                eventQueue.Enqueue(eve, Priority.Arrival);
            }

        }
    }
}