using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace turnitBusiestTimeApp {

    [TestFixture]
    public class Tests {
   
        private int TimeToMinutes(string time) {
            var parts = time.Split(':');
            int hours = int.Parse(parts[0]);
            int minutes = int.Parse(parts[1]);
            return hours * 60 + minutes;
        }

        [Test]
        public void BusiestTime_TimeRange() {
            
            var breaks = new Dictionary<string, int>
            {
                { "10:0012:00", 3 }, 
                { "11:0013:00", 2 },  
                { "12:0014:00", 4 } 
            };

            BreakOperations breakOperations = new BreakOperations();

          
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            breakOperations.busiestTime(breaks);

            var output = sw.ToString().Trim();
            ClassicAssert.AreEqual("Busiest Time: 12:00-13:00 with 6 drivers", output);
            
        }

        [Test]
        public void BusiestTime_SingleBreak() {
            
            var breaks = new Dictionary<string, int>
            {
                { "09:0011:00", 1 }
            };

            BreakOperations breakOperations = new BreakOperations();

            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            breakOperations.busiestTime(breaks);

            var output = sw.ToString().Trim();
            ClassicAssert.AreEqual("Busiest Time: 09:00-11:00 with 1 drivers", output);
        }

        [Test]
        public void BusiestTime_SameDriverCount() {
            
            var breaks = new Dictionary<string, int>
            {
                { "09:0010:00", 2 },
                { "10:0011:00", 2 },
                { "11:0012:00", 2 }
            };

            BreakOperations breakOperations = new BreakOperations();

            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            breakOperations.busiestTime(breaks);

            var output = sw.ToString().Trim();
            ClassicAssert.AreEqual("Busiest Time: 09:00-12:00 with 2 drivers", output);
        }
    }
}
