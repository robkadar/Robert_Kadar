using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTaskCSharp
{
    public class Task1
    {
        //TestCaseData for Filtered List
        public static IEnumerable<TestCaseData> testCaseDataFilteredList()
        {
            yield return new TestCaseData(new List<object> { 1, 2, 'a', 'b' }, new List<int> { 1, 2 });
            yield return new TestCaseData(new List<object> { 1, 2, 'a', 'b', 0, 15 }, new List<int> { 1, 2, 0, 15 });
            yield return new TestCaseData(new List<object> { 1, 2, 'a', 'b', "aasf", '1', "123", 231 }, new List<int> { 1, 2, 231 });
        }

        public static List<int> GetIntegersFromList(List<object> list)
        {
            List<int> intList = list
                .Where(i => i.GetType() == typeof(int))
                .Select(i => (int)i)
                .ToList();
            return intList;
        }

        [Test, TestCaseSource("testCaseDataFilteredList")]
        public static void filteredList(List<object> actualList, List<int> expectedList)
        {
            List<int> list = new List<int>();
            list = GetIntegersFromList(actualList);
            Assert.AreEqual(expectedList, list);
        }
    }
}