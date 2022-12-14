using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTaskCSharp
{
    internal class Task4
    {
        //TestCaseData for Array Pair Sum
        public static IEnumerable<TestCaseData> testCaseDataArrayPair()
        {
            yield return new TestCaseData(new int[] { 1, 3, 6, 2, 2, 0, 4, 5 }, 5);
        }

        //Function for count pairs with specific sum
        public int Count_Pairs(int[] arr, int target)
        {
            var countSum = arr.SelectMany((fst, i) => arr.Skip(i + 1).Select(snd => (fst, snd))).Where(pair => pair.fst + pair.snd == target).Count();
            return countSum;
        }

        //Target sum of array pairs
        [Test, TestCaseSource("testCaseDataArrayPair")]
        public void arrayPairTarget(int[] values, int target)
        {
            int actualCount = Count_Pairs(values, target);
            int expectedValue = 4;
            Assert.AreEqual(expectedValue, actualCount);
        }
    }
}
