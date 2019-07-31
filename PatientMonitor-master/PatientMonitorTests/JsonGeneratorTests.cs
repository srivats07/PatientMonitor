using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientMonitor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PatientMonitor.Tests
{
    [TestClass()]
    public class JsonGeneratorTests
    {



        [TestMethod()]
        public void GetUserDetailsTest()
        {
            string jsonFile = @"C:\Users\320052122\Desktop\PatientMonitor - master\PatientMonitorTests\TestData\MOCK_DATA.json";
              var json = File.ReadAllText(jsonFile);


        }

        
    }
}