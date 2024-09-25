using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnitBusiestTimeApp {
    internal class FileHandler {

        BreakOperations breakOp = new BreakOperations();


        //Checks if file exists
        public void checkPath(string[] args, Dictionary<String, int> breaksMap) {
           

            if (args.Length > 1 && args[0] == "filename") {
                string filename = args[1];

                if (File.Exists(filename)) {
            
                    readFile(args, breaksMap);
                
                }
                else {
                    Console.WriteLine("File not found!");
                }

            }
            else {
                Console.WriteLine("Invalid input! Use filename path/to/file.txt");

            }
        }

        public void readFile(String[] args, Dictionary<string, int> breaks) {

            String filePath = args[1];
            CheckInput checkInput = new CheckInput();
            List<string> concatTimes = new List<string>();

            try {


                // Open the file for reading
                using (StreamReader reader = new StreamReader(filePath)) {
                    String line;

                    // Read each line from the file
                    while ((line = reader.ReadLine()) != null) {

                        // Remove whitespace and format time strings
                        String trimmed = line.Trim();

                        String[] time = trimmed.Split("-");
                        String startTime = time[0];
                        String endTime = time[1];
                        String concatTime = time[0] + time[1];
                        concatTimes.Add(concatTime);

                    }
                }
            }catch (Exception ex) {
                Console.WriteLine("Error on reading file");
            }


            foreach (String time in concatTimes) {

                    //Using method from checkInput to check time range
                    if (checkInput.checkTimeRange(time)) {
                    breakOp.addBreak(breaks, time);
                    }
                }
        }
    }
}
  

