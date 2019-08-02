using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using PatientMonitor;

namespace PatientMoniterTest
{
    
    

    public static class Initialization
    {
        public static CheckParameter check = new CheckParameter();
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
            Assert.AreEqual(false, Initialization.check.AbnormalSpo2(95), "Abnormal Spo2 Invalid Test failed");
        }
        [TestMethod]
        public void TestTempValid()
        {
            Assert.AreEqual(false, Initialization.check.AbnormalTemperature(98.58), "Abnormal Temperature Invalid Test failed");
        }
        [TestMethod]
        public void TestPulseValid()
        {
            Assert.AreEqual(false, Initialization.check.AbnormalPulse(65), "Abnormal Pulse Invalid Test failed");
        }
        [TestMethod]
        public void TestSpo2BoundaryMinus1()
        {
            Assert.AreEqual(true, Initialization.check.AbnormalSpo2(90), "Abnormal Spo2 Boundary -1 Test failed");
            Assert.AreEqual(false, Initialization.check.AbnormalSpo2(99), "Abnormal Spo2 Boundary -1 Test failed");
        }
        [TestMethod]
        public void TestTempBoundaryMinus1()
        {
            Assert.AreEqual(true, Initialization.check.AbnormalTemperature(96.99), "Abnormal Temperature Boundary -1 Test failed");
            Assert.AreEqual(false, Initialization.check.AbnormalTemperature(98.99), "Abnormal Temperature Boundary -1 Test failed");
        }
        [TestMethod]
        public void TestPulseBoundaryMinus1()
        {
            Assert.AreEqual(true, Initialization.check.AbnormalPulse(59), "Abnormal Pulse Boundary -1 Test failed");
            Assert.AreEqual(false, Initialization.check.AbnormalPulse(99), "Abnormal Pulse Boundary -1 Test failed");
        }
        [TestMethod]
        public void TestSpo2Boundaryzero()
        {
            Assert.AreEqual(false, Initialization.check.AbnormalSpo2(91), "Abnormal Spo2 Boundary Zero Test failed");
            Assert.AreEqual(false, Initialization.check.AbnormalSpo2(100), "Abnormal Spo2 Boundary Zero Test failed");
        }
        [TestMethod]
        public void TestTempBoundaryZero()
        {
            Assert.AreEqual(false, Initialization.check.AbnormalTemperature(97.00), "Abnormal Temperature Boundary Zero Test failed");
            Assert.AreEqual(false, Initialization.check.AbnormalTemperature(99.00), "Abnormal Temperature Boundary Zero Test failed");
        }
        [TestMethod]
        public void TestPulseBoundaryZero()
        {
            Assert.AreEqual(false, Initialization.check.AbnormalPulse(60), "Abnormal Pulse Boundary Zero Test failed");
            Assert.AreEqual(false, Initialization.check.AbnormalPulse(100), "Abnormal Pulse Boundary Zero Test failed");
        }
        [TestMethod]
        public void TestSpo2BoundaryPlus1()
        {
            Assert.AreEqual(false, Initialization.check.AbnormalSpo2(92), "Abnormal Spo2 Boundary +1 Test failed");
            Assert.AreEqual(true, Initialization.check.AbnormalSpo2(101), "Abnormal Spo2 Boundary +1 Test failed");
        }
        [TestMethod]
        public void TestTempBoundaryPlus1()
        {
            Assert.AreEqual(false, Initialization.check.AbnormalTemperature(97.01), "Abnormal Temperature Boundary +1 Test failed");
            Assert.AreEqual(true, Initialization.check.AbnormalTemperature(99.01), "Abnormal Temperature Boundary +1 Test failed");
        }
        [TestMethod]
        public void TestPulseBoundaryPlus1()
        {
            Assert.AreEqual(false, Initialization.check.AbnormalPulse(61), "Abnormal Pulse Boundary +1 Test failed");
            Assert.AreEqual(true, Initialization.check.AbnormalPulse(101), "Abnormal Pulse Boundary +1 Test failed");
        }
        [TestMethod]
        public void TestSpo2Invalid()
        {
            Assert.AreEqual(true, Initialization.check.AbnormalSpo2(80), "Abnormal Spo2 Invalid Test failed");
        }
        [TestMethod]
        public void TestTempInvalid()
        {
            Assert.AreEqual(true, Initialization.check.AbnormalTemperature(110.25), "Abnormal Temperature Invalid Test failed");
        }
        [TestMethod]
        public void TestPulseInvalid()
        {
            Assert.AreEqual(true, Initialization.check.AbnormalPulse(55), "Abnormal Pulse Invalid Test failed");
        }
    }
}
