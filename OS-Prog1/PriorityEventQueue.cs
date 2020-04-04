using System.Collections.Generic;

namespace OS_Prog1 {
    
    public enum Priority {
        Arrival,  Id
    }
    public class PriorityEventQueue {
        
        public List<Event> events;

        public int Count {
            get { return events.Count; }
        }

        public void Enqueue(Event eve, Priority priority) {
            switch (priority) {
                
                case Priority.Arrival:
                    InsertByArrival(eve);
                    break;
                
                case Priority.Id:
                    InsertById(eve);
                    break;
                
            }
            
        }

        private void InsertByArrival(Event eve) {
            // value is less than some other value in the list, add at that index
            for (int i = 0; i < events.Count - 1; i++) {
                if (eve.time < events[i].time) {
                    events.Insert(i, eve);
                    return;
                }
            }
            //else it's the highest time yet, add at the end:
            events.Add(eve);
            
        }

        private void InsertById(Event eve) {
            
            // value is less than some other value in the list, add at that index
            for (int i = 0; i < events.Count - 1; i++) {
                if (eve.processId < events[i].processId) {
                    events.Insert(i, eve);
                    return;
                }
            }
            // else it's the highest time yet, add at the end:
            events.Add(eve);
            
        }

//        private void InsertByCompletion(Event eve) {
//            // value is less than some other value in the list, add at that index
//            for (int i = 0; i < events.Count - 1; i++) {
//                if (eve.time < events[i].processId) {
//                    events.Insert(i, eve);
//                    return;
//                }
//            }
//            // else it's the highest time yet, add at the end:
//            events.Add(eve);
//        }
        
        public Event Dequeue() {
            Event last = events[^1]; //last index
            events.Remove(last);
            return last;
        }

        public Event Peek() {
            return events[^1];
        }

        public Event Peek(int i) {
            return events[i];
        }

        public Queue<Event> ToQueue() {
            Queue<Event> eventQueue = new Queue<Event>();
            for (int i = 0; i < events.Count - 1; i++) {
                eventQueue.Enqueue(events[i]);
            }

            return eventQueue;
        }
        
    }
}