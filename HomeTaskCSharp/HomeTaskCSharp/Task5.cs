using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTaskCSharp
{
    internal class Task5
    {
        public class Guests
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
        }

        //TesCaseData for Person list
        public static IEnumerable<TestCaseData> testCaseDataPersonList()
        {
            yield return new TestCaseData("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill");
        }

        public static string SortGuestList(List<Guests> guestList)
        {
            var sortedList = guestList.OrderBy(x => x.lastName.ToLower()).ThenBy(x => x.firstName.ToLower());
            List<Guests> uperCaseList = sortedList.Select(x => new Guests() { firstName = x.firstName.ToUpper(), lastName = x.lastName.ToUpper() }).ToList();

            string result = "";

            foreach (var item in uperCaseList)
            {
                result += $"({item.lastName}, {item.firstName})";
            }

            return result;
        }

        [Test, TestCaseSource("testCaseDataPersonList")]
        public void listGuests(string input)
        {
            string[] str = input.Split(new char[] { ';' });
            Dictionary<string, string> dictGuests = new Dictionary<string, string>();
            dictGuests = str.ToDictionary(s => s.Split(':')[0], s => s.Split(':')[1]);

            List<Guests> result = dictGuests.Select(x => new Guests() { firstName = x.Key, lastName = x.Value }).ToList();

            string actualResult = SortGuestList(result);
            string expectedResul = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";

            Assert.AreEqual(expectedResul, actualResult);
        }
    }
}
