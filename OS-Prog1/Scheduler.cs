using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    public class Scheduler {
        
        protected float lambda, serviceTime, quantum;
        
        protected Queue<Event> events;

        public Scheduler(float lambda, float serviceTime, float quantum) {
            this.lambda = lambda;
            this.serviceTime = serviceTime;
            this.quantum = quantum;
        }

        public virtual void Run() {
//            Console.WriteLine(new NotImplementedException());
        }
        
    }
}