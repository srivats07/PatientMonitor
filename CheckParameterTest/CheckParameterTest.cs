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
            double value = generator.Next(0, 300);
            if (value < 255)
            {

            }


        }
        
        [TestMethod]
        public void SPO2ValidTC()
        {
        }
        [TestMethod]
        public void SPO2InvalidTC()
        {
        }
        [TestMethod]
        public void SPO2BoundaryTC()
        {
        }
        [TestMethod]
        public void TempValidTC()
        {
        }
        public void TempInvalidTC()
        {
        }
        public void TempBoundaryTC()
        {
        }
        public void PulseValidTC()
        {
        }
        public void PulseInvalidTC()
        {
        }
        public void PulseBoundaryTC()
        {
        }
    }
}
