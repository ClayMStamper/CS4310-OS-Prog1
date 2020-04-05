using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    public class Process {
        public int id;
        public float arrival, burst, completion, turnAround, timeRem;

        public override string ToString() {
            string msg = $"\n========\nProcess: {id}";
            msg += $"\nMy arrival: {arrival}";
            msg += $"\nMy burst time: {burst}";
            msg += $"\nMy completion time: {completion}";
            msg += $"\nMy turn Around: {turnAround}";
            msg += $"\nMy time rem: {timeRem}";
            msg += "\n==============\n";
            
            return msg;
        }
    }
    
    public class ProcessGenerator {

        private int count;
        private float lambda, servTime;

        public List<Process> processes = new List<Process>();

        public ProcessGenerator(int count) {
            this.count = count;
            lambda = Program.lambda;
            servTime = Program.serviceTime;
        }

        public void Generate() {

            for (int i = 0; i < count; i++) {
                
                Process proc = new Process();
                proc.arrival = RandomExp(lambda);
                proc.burst = RandomExp(servTime);
                proc.timeRem = proc.burst;
                proc.id = i;
                
                processes.Add(proc);

            }

        }

        private float RandomExp(float t) {

            
            /*
             * float u,x;
	            x = 0;
	            while (x == 0)
		            {
			            u = urand();
			            x = (-1/lambda)*log(u);
		            }
	            return(x);
             */
            float u = 0, x = 0;

            while (x <= 0) {
                u = (float) new Random().NextDouble();
                x = (-1 / t) * MathF.Log(u);
            }

            return x;

        }

        public override string ToString() {
            
            string msg = $"\n========\nProcess Generator:";

            foreach (Process process in processes) {
                msg += process.ToString();
            }
            
            msg += "\n==============\n";

            
            return msg;
            
        }
    }
    
}