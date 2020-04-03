using System;
using System.Collections.Generic;

namespace OS_Prog1 {


    public class Sim {

        public static Sim Singleton { get; private set; }

        protected Queue<Process> events;
        private float lambda, serviceTime, quantum;

        private Scheduler scheduler;

        public Sim(int schedulerType, float lambda, float serviceTime, float quantumInterval) {

            Singleton = this;

            Init(schedulerType, lambda, serviceTime, quantumInterval);
            Run();
            GenerateReport();

        }

        private void Init(int schedulerType, float lambda, float serviceTime, float quantum) {

            this.lambda = lambda;
            this.serviceTime = serviceTime;
            this.quantum = quantum;

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

        private void Run() {

//            events.Dequeue().Process();

        }

        private void GenerateReport() { }

        //generate random value following an exponential distribution
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