using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnitBusiestTimeApp {
    internal class CheckInput {

        public void checkTimeInput(String input) {

        }


        //Checks time format and ensures that startTime is before endTime
        public bool checkTimeRange(String input) {

            try {

                //Splitting startTime to hours and minutes 
                String[] startTimeString = input.Substring(0, 5).Split(":");
                String startTimeConcat = startTimeString[0] + startTimeString[1];

                //Parsing String to int
                int startTimeInt = int.Parse(startTimeConcat);

                //Splitting endTime to hours and minutes
                String[] endTime = input.Substring(5, 5).Split(":");

                //Setting endTime hour to 24 if startTime is 23
                if (startTimeString[0] == "23" && endTime[0] == "00") {
                    endTime[0] = "24";
                }
                String endTimeConcat = endTime[0] + endTime[1];

                //Parsing String to int
                int endTimeInt = int.Parse(endTimeConcat);


                //Booleans for colons in time format 
                bool isStartColonValid = input[2] == ':';
                bool isEndColonValid = input[7] == ':';

                // Ensures that time is the correct format and doesn't exceed hours and minutes ex: 25:61 returns false
                if (int.Parse(startTimeString[0]) > 23 || int.Parse(startTimeString[1]) > 59 ||
                    int.Parse(startTimeString[0]) < 0 || int.Parse(startTimeString[1]) < 0 ||
                    int.Parse(endTime[0]) > 24 || int.Parse(endTime[1]) > 59 ||
                    int.Parse(endTime[0]) < 0 || int.Parse(endTime[1]) < 0){

                    return false;
                }

                //Checks input length, colon placement and that startTime is before endTime
                return input.Length == 10 && isStartColonValid && isEndColonValid && startTimeInt < endTimeInt;
            }
            catch (Exception ex) {
                return false;
                  }
            }
        }
    }
