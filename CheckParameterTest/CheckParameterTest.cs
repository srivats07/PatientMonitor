using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alert;
namespace CheckParameterTest
{
    
    [TestClass]
    public class CheckParameterTest
    {
        [TestMethod]
        public void init()
        {
            Random generator=new Random();
            //double value = generator.Next(0, 300);
            double value = -1;
            string[] triplet = new string[] {"Tester","","","" };
            
            
            if (value < 255)
            {
                triplet[1] = "98";
                triplet[3] = "60";
                if (value >= 91 && value <= 100)
                {
                    triplet[2] = value.ToString();
                    SPO2ValidTC(triplet);
                }

                else if (value > 100 && value < 91)
                {
                    triplet[2] = value.ToString();
                    SPO2InvalidTC(triplet);
                }
                triplet[1] = "98";
                triplet[2] = "91";

                if (value >= 60 && value <= 100)
                {
                    triplet[3] = value.ToString();
                    PulseValidTC(triplet);
                }
                    
                else if (value > 100 && value < 60)
                {
                    triplet[3] = value.ToString();
                    PulseValidTC(triplet);
                }

                triplet[2] = "91";
                triplet[3] = "60";

                if (value >= 97 && value <= 99)
                {
                    triplet[1] = value.ToString();
                    TempValidTC(triplet);
                }
                    
                else if (value > 99 && value < 97)
                {
                    triplet[1] = value.ToString();
                    TempInvalidTC(triplet);
                }
                    
            }
        }
        
        [TestMethod]
        public void SPO2ValidTC(string[] values)
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            CheckParameter check=new CheckParameter();
            result=check.AlertIsNeeded(values);
            Assert.AreEqual(expected,result[0],"SPO2 valid test fails");
        }
        [TestMethod]
        public void SPO2InvalidTC(string[] values)
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            CheckParameter check = new CheckParameter();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "SPO2 Invalid test fails");
        }
        [TestMethod]
        public void SPO2BoundaryTC()
        {
            Boolean[] result = new bool[] { true, true, true };
        }
        [TestMethod]
        public void TempValidTC(string[] values)
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            CheckParameter check = new CheckParameter();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "Temp valid test fails");
        }
        public void TempInvalidTC(string[] values)
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            CheckParameter check = new CheckParameter();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "Temp Invalid test fails");
        }
        public void TempBoundaryTC()
        {
            Boolean[] result = new bool[] { true, true, true };
        }
        public void PulseValidTC(string[] values)
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = false;
            CheckParameter check = new CheckParameter();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "Pulse valid test fails");
        }
        public void PulseInvalidTC(string[] values)
        {
            Boolean[] result = new bool[] { true, true, true };
            bool expected = true;
            CheckParameter check = new CheckParameter();
            result = check.AlertIsNeeded(values);
            Assert.AreEqual(expected, result[0], "Pulse Invalid test fails");
        }
        public void PulseBoundaryTC()
        {
            Boolean[] result = new bool[] { true, true, true };
        }
    }
}
