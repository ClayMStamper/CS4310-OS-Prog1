using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    public class Scheduler {
        
        protected float lambda, serviceTime, quantum;
        protected PriorityEventQueue eventQueue;

        protected Process lastArrived;
        protected int processCount;
        protected float clock;
        
        public Scheduler(float lambda, float serviceTime, float quantum) {
            this.lambda = lambda;
            this.serviceTime = serviceTime;
            this.quantum = quantum;
        }

        public virtual Queue<Event> ScheduleEventQueue(int processCount) {

            clock = 0f;
            
            for (int i = 0; i < processCount; i++) {
                
                Process process = new Process();
                process.arrival.time = clock + RandomExp();
                process.completion.time = process.arrival.time + RandomExp();
                process.arrival.processId = process.id;
                process.completion.processId = process.id;


            }

            return eventQueue.ToQueue();

        }

        protected virtual void ScheduleEvent(Event eve) {
            
            
            
        }
        
        public float RandomExp() {

            float u = 0, x = 0;

            while (x <= 0) {
                u = (float) new Random().NextDouble();
                x = (-1 / lambda) * MathF.Log(u);
            }

            return x;

        }
        
    }
}