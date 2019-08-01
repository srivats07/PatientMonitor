using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitor;

namespace PatientMoniterTest
{
    
    

    public static class Initialization
    {
        public static CheckParameter check = new CheckParameter();
        public static bool expected = true;
        public static Dictionary<CheckParameter.Parameters, string> values = new Dictionary<CheckParameter.Parameters, string>();
        public static int SPO2Expected = 95;
        public static Double TemperatureExpected = 98.50;
        public static int PulseExpected = 65;

        public static void init()
        {
            values.Add(CheckParameter.Parameters.PatientID, "Tester");
            values.Add(CheckParameter.Parameters.SPO2, "95");
            values.Add(CheckParameter.Parameters.PulseRate, "65");
            values.Add(CheckParameter.Parameters.Temperature, "98.50");
        }
        public static void Dispose()
        {
            values.Remove(CheckParameter.Parameters.PatientID);
            values.Remove(CheckParameter.Parameters.SPO2);
            values.Remove(CheckParameter.Parameters.PulseRate);
            values.Remove(CheckParameter.Parameters.Temperature);
        }
    }
    
    

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParameters()
        {
            Initialization.init();
            Initialization.check.GetParameters(Initialization.values, out var SPO2, out var pulseRate, out var temperature);
            

            Assert.AreEqual(Initialization.SPO2Expected,SPO2,"SPO2 parameter mismatch");
            Assert.AreEqual(Initialization.TemperatureExpected, temperature, "Temperature parameter mismatch");
            Assert.AreEqual(Initialization.PulseExpected, pulseRate, "Pulse Rate parameter mismatch");
        }

        [TestMethod]
        public void TestSpo2Valid()
        {
            Initialization.expected = false;
            bool Actual ;
            Actual = Initialization.check.AbnormalSpo2(95);
            Assert.AreSame(false,Initialization.check.AbnormalSpo2(95),"Abnormal Spo2 Test failed");

        }
        [TestMethod]
        public void TestTempValid()
        {
            Initialization.expected = false;
            bool Actual;
            Actual = Initialization.check.AbnormalTemperature(95);
            Console.WriteLine(Actual);
            Assert.AreEqual(false, Initialization.check.AbnormalTemperature(98.58), "Abnormal Temperature Test failed");

        }
        [TestMethod]
        public void TestPulseValid()
        {

        }
        [TestMethod]
        public void TestSpo2Invalid()
        {

        }




    }
}
