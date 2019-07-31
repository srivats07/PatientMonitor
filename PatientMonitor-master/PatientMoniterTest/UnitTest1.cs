using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitor;

namespace PatientMoniterTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void SPO2ValidTC()
        {
            string[] values=new string[] { "Tester", "95", "65", "98.5" };

            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 valid test fails");
        }
        [TestMethod]
        public void SPO2InvalidTC()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            string[] values = new string[] { "Tester", "101", "65", "98.5" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 Invalid test fails");
        }
        [TestMethod]
        public void SPO2BoundaryTCMinus1()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            string[] values = new string[] { "Tester", "90", "65", "98.5" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 Boundary -1 test fails");
            expected = true;
            values = new string[] { "Tester", "99", "65", "98.5" };
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 Boundary -1 test fails");
        }
        [TestMethod]
        public void SPO2BoundaryTCZero()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            string[] values = new string[] { "Tester", "91", "65", "98.5" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 Boundary zero test fails");
            values = new string[] { "Tester", "100", "65", "98.5" };
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 Boundary zero test fails");
        }
        [TestMethod]
        public void SPO2BoundaryTCPlusOne()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            string[] values = new string[] { "Tester", "92", "65", "98.5" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 Boundary plus 1 test fails");
            values = new string[] { "Tester", "101", "65", "98.5" };
            expected = false;
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 Boundary plus 1 test fails");
        }
        [TestMethod]
        public void TempValidTC()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            string[] values = new string[] { "Tester", "95", "65", "98.5" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[1], "Temp valid test fails");
        }
        [TestMethod]
        public void TempInvalidTC()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            string[] values = new string[] { "Tester", "95", "65", "90.3" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[1], "Temp Invalid test fails");
        }
        [TestMethod]
        public void TempBoundaryTCMinus1()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            string[] values = new string[] { "Tester", "95", "65", "96.9" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[1], "Temp Boundary -1 test fails");
            expected = true;
            values = new string[] { "Tester", "95", "65", "98.9" };
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[1], "Temp Boundary -1 test fails");
        }
        [TestMethod]
        public void TempBoundaryTCZero()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            string[] values = new string[] { "Tester", "95", "65", "97.0" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[1], "Temp Boundary zero test fails");
            values = new string[] { "Tester", "95", "65", "99.0" };
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[1], "Temp Boundary zero test fails");
        }
        [TestMethod]
        public void TempBoundaryTCPlusOne()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            string[] values = new string[] { "Tester", "95", "65", "97.1" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[1], "Temp Boundary +1 test fails");
            expected = false;
            values = new string[] { "Tester", "95", "65", "99.1" };
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[1], "Temp Boundary +1 test fails");
        }
        [TestMethod]
        public void PulseValidTC()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            string[] values = new string[]{ "Tester", "95", "65", "98.5" }; ;
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[2], "Pulse valid test fails");
        }
        [TestMethod]
        public void PulseInvalidTC()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            string[] values = new string[] { "Tester", "95", "50", "98.5" };;
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[2], "Pulse Invalid test fails");
        }
        [TestMethod]
        public void PulseBoundaryTCMinus1()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            string[] values = new string[] { "Tester", "95", "59", "97.0" }; 
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[2], "Pulse Boundary -1 test fails");
            expected = true;
            values =  new string[] { "Tester", "95", "99", "97.0" };
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[2], "Pulse Boundary -1 test fails");
        }
        [TestMethod]
        public void PulseBoundaryTCZero()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            string[] values = new string[] { "Tester", "95", "60", "97.0" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[2], "Pulse Boundary zero test fails");
            values = new string[] { "Tester", "95", "100", "97.0" };
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[2], "Pulse Boundary zero test fails");
        }
        [TestMethod]
        public void PulseBoundaryTCPlus1()
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            string[] values = new string[] { "Tester", "95", "61", "97.0" };
            JsonGenerator check = new JsonGenerator();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[2], "Pulse Boundary +1 test fails");
            expected = false;
            values = new string[] { "Tester", "95", "101", "97.0" };
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[2], "Pulse Boundary +1 test fails");
        }

    }
}
