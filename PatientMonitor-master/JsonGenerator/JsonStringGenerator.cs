using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JsonGenerator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PatientMonitor;

namespace JsonGenerator
{
    public class JsonGenerator
    {
        Dictionary<CheckParameter.Parameters, string> dict = new Dictionary<CheckParameter.Parameters, string>();

        static void Main(string[] args)
        {
            JsonGenerator jsg = new JsonGenerator();
            while (true)
            {
                jsg.GetUserDetails();
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }
        
        /// <summary>
        /// Gets the randomly generated Patient Data
        /// </summary>
        

        public void GetUserDetails()
        {
            string ln;
            ln = RandomValueGenerator.RandomDataGenerator();
            Console.WriteLine(ln);
        }
        
    }
}
