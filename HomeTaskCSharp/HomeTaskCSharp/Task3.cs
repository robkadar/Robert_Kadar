using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTaskCSharp
{
    internal class Task3
    {
        //TestCaseData for Digital Root
        public static IEnumerable<TestCaseData> testCaseDataDigitalRoot()
        {
            yield return new TestCaseData(16, 7);
            yield return new TestCaseData(942, 6);
            yield return new TestCaseData(132189, 6);
            yield return new TestCaseData(493193, 2);
        }


        public int DigitalRoot(long n)
        {
            if (n < 10) return (int)n;
            
            return DigitalRoot(GetDigits(n).Sum());

        }

        public static List<int> GetDigits(long n)
        {
            List<int> digits = new List<int>();

            while (n > 0)
            {
                digits.Add((int)(n % 10));
                n /= 10;
            }
            return digits;
        }

        [Test, TestCaseSource("testCaseDataDigitalRoot")]
        public void digitalRoot(long digRoot, int expectedResult)
        {
            int actualDigitalRoot = DigitalRoot(digRoot);
            Assert.AreEqual(expectedResult, actualDigitalRoot);
        }
    }
}
