using System;

namespace OS_Prog1 {
    class Program {
        static void Main(string[] args) {

            int schedularType;
            float lambda, serviceTime, quantum;

            if (!int.TryParse(args[0], out schedularType)) {
                WriteError(args[0], 0);
            }
            
            if (!float.TryParse(args[1], out lambda)) {
                WriteError(args[1], 1);
            }
            
            if (!float.TryParse(args[2], out serviceTime)) {
                WriteError(args[2], 2);
            }
            
            if (!float.TryParse(args[3], out quantum)) {
                WriteError(args[3], 3);
            }
            
            Sim sim = new Sim(schedularType, lambda, serviceTime, quantum);
            
        }

        private static void WriteError(object arg, int index) {
            Console.WriteLine($"ERROR: failed to parse {arg} from arg[{index}]");
        }
    }

}