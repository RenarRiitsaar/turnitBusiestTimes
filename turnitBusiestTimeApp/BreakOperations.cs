using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnitBusiestTimeApp {
    public class BreakOperations {

        public Dictionary<string, int> addBreak(Dictionary<string, int> breaks, String userInput) {



            //Increments drivers on existing break time
            if (breaks.ContainsKey(userInput)) {
                breaks[userInput] += 1;
            }
            else {

                //Adds new break time and a driver 
                breaks.Add(userInput, 1);
            }

            return breaks;
        }

        public int TimeToMinutes(string time) {

            //Converts hours to minutes
            String[] timeToParts = time.Split(":");
            int hours = int.Parse(timeToParts[0]);
            int minutes = int.Parse(timeToParts[1]);
            return hours * 60 + minutes;
        }

        public string MinutesToTime(int min) {

            //Converts Minutes to time ex: 11:20
            int hours = min / 60;
            int minutes = min % 60;

            return $"{hours:D2}:{minutes:D2}";
        }

        public void busiestTime(Dictionary<string, int> breaks) {

            // Storing drivers by minute
            int[] driverCountPerMinute = new int[1440];

            // Splitting start and end time
            foreach (var breakEntry in breaks) {
                string startTime = breakEntry.Key.Substring(0, 5);
                string endTime = breakEntry.Key.Substring(5);
                int startMinutes = TimeToMinutes(startTime);
                int endMinutes = TimeToMinutes(endTime);

                // Update driver count for each minute
                for (int i = startMinutes; i < endMinutes; i++) {
                    driverCountPerMinute[i] += breakEntry.Value;
                }
            }

            int maxDrivers = 0;
            int startMax = 0;
            int endMax = 0;


            for (int i = 0; i < driverCountPerMinute.Length; i++) {

                //Checks if driver count on minute is higher than maxDrivers
                if (driverCountPerMinute[i] > maxDrivers) {

                    maxDrivers = driverCountPerMinute[i];
                    startMax = i; 
                    endMax = i;   
     
                }
                //update busiest end time
                else if (driverCountPerMinute[i] == maxDrivers) {
                    endMax = i; 
                }
            }

            Console.WriteLine($"Busiest Time: " + MinutesToTime(startMax) + "-" + MinutesToTime(endMax + 1) + " with " + maxDrivers + " drivers ");
        }


    }
}
    

