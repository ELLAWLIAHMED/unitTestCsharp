using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingSample
{
    public class CreditSimulationTestData
    {
        public static IEnumerable ValidCreditSimulationData()
        {
            yield return new TestCaseData( 7.5, 36, 100000, 3110.62 );
            yield return new TestCaseData(7.5, 48, 100000, 2417.89);
            yield return new TestCaseData(5, 48, 100000, 2302.93);
            yield return new TestCaseData(5, 48, 50000, 1151.46);
        }

        public static IEnumerable InValidCreditSimulationData()
        {
            yield return new TestCaseData(-1, 36, 100000);
            yield return new TestCaseData(7.5, -2, 100000);
            yield return new TestCaseData(5, 48, 0);
        }
    }
}
