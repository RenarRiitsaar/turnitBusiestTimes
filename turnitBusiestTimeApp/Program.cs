namespace turnitBusiestTimeApp {
    internal class Program {

        static  Dictionary<String, int> breaksMap = new Dictionary<String, int>();
        static BreakOperations breaks = new BreakOperations();
        static FileHandler handler = new FileHandler();




        static void Main(string[] args) {

            bool active = true;

            if (args.Length != 0) {
             
                handler.checkPath(args, breaksMap);
                showEntries();
                breaks.busiestTime(breaksMap);
                active = false;

            }

            while (active) {

                Console.WriteLine("Enter a break time in format <startTime><EndTime> ex: 13:0014:00 or 'exit' to quit.");
                Console.Write("Input: ");
                String userInput = Console.ReadLine().Trim();


                
                switch (userInput) {
                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        CheckInput checkInput = new CheckInput();

                        if (checkInput.checkTimeRange(userInput)) {
                           
                            breaks.addBreak(breaksMap, userInput);
                            showEntries();
                            breaks.busiestTime(breaksMap);
              
                        }else{
                            Console.WriteLine("\n Invalid time format Enter <startTime><EndTime> ex: 13:0014:00 \n");
                            
                        }
                        break;

                }
            }
        }

        private static void showEntries() {
            // Prints all entries in breaksMap dictionary
            foreach (var breakEntry in breaksMap) {
                Console.WriteLine("Break Time: " + breakEntry.Key + ", " + "Drivers: " + breakEntry.Value);
            }
        }
    }
}

