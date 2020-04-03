using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    public class Scheduler {
        
        protected float lambda, serviceTime, quantum;
        protected Queue<Process> readyProcessQueue;
        
        public Scheduler(float lambda, float serviceTime, float quantum) {
            this.lambda = lambda;
            this.serviceTime = serviceTime;
            this.quantum = quantum;
        }

        public virtual Process ScheduleProcess() {
            
            return readyProcessQueue.Dequeue();
            
        }
        
    }
}