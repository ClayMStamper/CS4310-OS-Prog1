using System;
using System.Collections.Generic;

namespace OS_Prog1 {
    public class FCFS : Scheduler{
        public override void ScheduleProcesses() {
            
            //generates list of processes
            base.ScheduleProcesses();

            Debug.Log($"{processGenerator}");
            
//            Event eve = new Event();
//            events.Add(eve);
        }
    }
}