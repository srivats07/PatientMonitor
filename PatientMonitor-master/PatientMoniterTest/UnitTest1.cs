using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitor;

namespace PatientMoniterTest
{
    
    

    public static class Global
    {
        public static CheckParameter check = new CheckParameter();
        public static Boolean[] result = new bool[] { true, true, true };
        public static bool expected = true;
        public static Dictionary<CheckParameter.Parameters, string> values = new Dictionary<CheckParameter.Parameters, string>();

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
        public void SPO2ValidTC()
        {
            Global.init();
            Global.expected = true;
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[0], "SPO2 valid test fails");
            Global.Dispose();
            //Assert.AreEqual(Global.expected, Global.result[2], "Temperature valid test fails");
            //Assert.AreEqual(Global.expected, Global.result[1], "Pulse Rate valid test fails");
        }
        [TestMethod]
        public void SPO2InvalidTC()
        {
         
            Global.expected = false;
            Global.init();
            Global.values.Remove(CheckParameter.Parameters.SPO2);
            Global.values.Add(CheckParameter.Parameters.SPO2,"110");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[0], "SPO2 Invalid test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void SPO2BoundaryTCMinus1()
        {
            Global.init();
            Global.expected = false;
            Global.values.Remove(CheckParameter.Parameters.SPO2);
            Global.values.Add(CheckParameter.Parameters.SPO2, "90");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[0], "SPO2 Boundary -1 test fails");
            Global.Dispose();
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.SPO2);
            Global.values.Add(CheckParameter.Parameters.SPO2, "99");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[0], "SPO2 Boundary -1 test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void SPO2BoundaryTCZero()
        {
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.SPO2);
            Global.values.Add(CheckParameter.Parameters.SPO2, "91");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[0], "SPO2 Boundary Zero test fails");
            Global.Dispose();
            Global.init();
            Global.values.Remove(CheckParameter.Parameters.SPO2);
            Global.values.Add(CheckParameter.Parameters.SPO2, "100");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[0], "SPO2 Boundary Zero test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void SPO2BoundaryTCPlusOne()
        {
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.SPO2);
            Global.values.Add(CheckParameter.Parameters.SPO2, "92");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[0], "SPO2 Boundary +1 test fails");
            Global.Dispose();
            Global.init();
            Global.expected = false;
            Global.values.Remove(CheckParameter.Parameters.SPO2);
            Global.values.Add(CheckParameter.Parameters.SPO2, "101");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[0], "SPO2 Boundary +1 test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void TempValidTC()
        {
            Global.init();
            Global.expected = true;
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[2], "Temp valid test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void TempInvalidTC()
        {
            Global.expected = false;
            Global.init();
            Global.values.Remove(CheckParameter.Parameters.Temperature);
            Global.values.Add(CheckParameter.Parameters.Temperature, "90.35");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[2], "Temp Invalid test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void TempBoundaryTCMinus1()
        {
            Global.init();
            Global.expected = false;
            Global.values.Remove(CheckParameter.Parameters.Temperature);
            Global.values.Add(CheckParameter.Parameters.Temperature, "96.9");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[2], "Temperature Boundary -1 test fails");
            Global.Dispose();
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.Temperature);
            Global.values.Add(CheckParameter.Parameters.Temperature, "98.9");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[2], "Temperature Boundary -1 test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void TempBoundaryTCZero()
        {
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.Temperature);
            Global.values.Add(CheckParameter.Parameters.Temperature, "97.00");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[2], "Temperature Boundary Zero test fails");
            Global.Dispose();
            Global.init();
            Global.values.Remove(CheckParameter.Parameters.Temperature);
            Global.values.Add(CheckParameter.Parameters.Temperature, "99.00");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[2], "Temperature Boundary Zero test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void TempBoundaryTCPlusOne()
        {
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.Temperature);
            Global.values.Add(CheckParameter.Parameters.Temperature, "97.1");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[2], "Temperature Boundary +1 test fails");
            Global.Dispose();
            Global.init();
            Global.expected = false;
            Global.values.Remove(CheckParameter.Parameters.Temperature);
            Global.values.Add(CheckParameter.Parameters.Temperature, "99.1");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[2], "Temperature Boundary +1 test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void PulseValidTC()
        {
            Global.init();
            Global.expected = true;
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[1], "Pulse valid test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void PulseInvalidTC()
        {
            Global.init();
            Global.expected = false;
            Global.values.Remove(CheckParameter.Parameters.PulseRate);
            Global.values.Add(CheckParameter.Parameters.PulseRate, "50");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[1], "Pulse Invalid test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void PulseBoundaryTCMinus1()
        {
            Global.init();
            Global.expected = false;
            Global.values.Remove(CheckParameter.Parameters.PulseRate);
            Global.values.Add(CheckParameter.Parameters.PulseRate, "59");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[1], "Pulse Rate Boundary -1 test fails");
            Global.Dispose();
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.PulseRate);
            Global.values.Add(CheckParameter.Parameters.PulseRate, "99");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[1], "Pulse Rate Boundary -1 test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void PulseBoundaryTCZero()
        {
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.PulseRate);
            Global.values.Add(CheckParameter.Parameters.PulseRate, "60");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[1], "Pulse Rate Boundary Zero test fails");
            Global.Dispose();
            Global.init();
            Global.values.Remove(CheckParameter.Parameters.PulseRate);
            Global.values.Add(CheckParameter.Parameters.PulseRate, "100");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[1], "Pulse Rate Boundary Zero test fails");
            Global.Dispose();
        }
        [TestMethod]
        public void PulseBoundaryTCPlus1()
        {
            Global.init();
            Global.expected = true;
            Global.values.Remove(CheckParameter.Parameters.PulseRate);
            Global.values.Add(CheckParameter.Parameters.PulseRate, "61");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[1], "Pulse Rate Boundary +1 test fails");
            Global.Dispose();
            Global.init();
            Global.expected = false;
            Global.values.Remove(CheckParameter.Parameters.PulseRate);
            Global.values.Add(CheckParameter.Parameters.PulseRate, "101");
            Global.result = Global.check.CheckWhetherAlertIsNeeded(Global.values);
            Assert.AreEqual(Global.expected, Global.result[1], "Pulse Rate Boundary +1 test fails");
            Global.Dispose();
        }

    }
}
