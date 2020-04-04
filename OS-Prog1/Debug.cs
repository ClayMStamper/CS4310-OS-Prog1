using System;

namespace OS_Prog1 {

    public enum DebugLevel {
        Message,
        Urgent,
        Error
    }

    public static class Debug {

        public static DebugLevel debugLevel = DebugLevel.Message;
        
        public static void Log(string msg) {
            Log(msg, DebugLevel.Message);
        }

        public static void Log(string msg, DebugLevel msgLevel) {

            if (debugLevel <= msgLevel) {
                Console.WriteLine(msg);
            }
            
        }
        
    }
}