using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTaskCSharp
{
    internal class Task2
    {
        //TestCaseData for 'First non repeating function'
        public static IEnumerable<TestCaseData> testCaseDataFirstLetter()
        {
            yield return new TestCaseData("stress", 't');
            yield return new TestCaseData("AbcaBDC", 'D');
        }

        //Function for First Non Repeating Letter
        public char first_non_repeating_letter(string str)
        {
            var result = str
                .GroupBy(c => c.ToString(), c => c, StringComparer.OrdinalIgnoreCase)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key)
                .First();

            return char.Parse(result);
        }

        [Test, TestCaseSource("testCaseDataFirstLetter")]
        public void nonRepeatingLetter(string strTest, char expectedChar)
        {
            char firstLetter = first_non_repeating_letter(strTest);
            Assert.AreEqual(expectedChar, firstLetter);
        }
    }
}
