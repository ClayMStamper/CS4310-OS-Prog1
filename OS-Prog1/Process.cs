using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    public class Process {

        public static int count;

        public Process() {
            id = count;
            count++;
        }
        
        public int id;
        public ProcessArrival arrival = new ProcessArrival();
        public ProcessCompletion completion = new ProcessCompletion();

    }
}