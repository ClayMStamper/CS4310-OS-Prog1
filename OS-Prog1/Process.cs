using System;

namespace OS_Prog1 {
    public class Process {
        
        private float arrivalTime, serviceTime;
        
        public Process (Scheduler myScheduler) {

            arrivalTime = Sim.Singleton.RandomExp();
            serviceTime = Sim.Singleton.RandomExp(); //this might need a seperate init function

        }
        
    }
}