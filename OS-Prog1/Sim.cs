using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    
    
    public class Sim {

        private Scheduler scheduler;
        public Sim(int schedulerType, float lambda, float serviceTime, float quantumInterval) {
            
            Init(schedulerType, lambda, serviceTime, quantumInterval);
            scheduler.Run();
            GenerateReport();
            
        }

        private void Init(int schedulerType, float lambda, float serviceTime, float quantum) {

            switch (schedulerType) {
                case 1: 
                    scheduler = new FCFS(lambda, serviceTime, quantum);
                    break;
                case 2:
                    scheduler = new SRTF(lambda, serviceTime, quantum);
                    break;
                case 3:
                    scheduler = new HRRN(lambda, serviceTime, quantum);
                    break;
                case 4:
                    scheduler = new RR(lambda, serviceTime, quantum);
                    break;
                default:
                    scheduler = new Scheduler(lambda, serviceTime, quantum); //shouldn't ever happen
                    break;
            }

        }

        private void GenerateReport() {
            
        }

        //generate random value following an exponential distribution
        public static float RandExp(float lambda) {
            
            float u = 0, x = 0;
            while (x <= 0) {
                u = (float) new Random().NextDouble();
                x = (-1 / lambda) * MathF.Log(u);
            }

            return x;

        }
        
    }
    
}