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

namespace PatientMonitor
{
    

    public class JsonGenerator
    {
        static void Main(string[] args)
        {
            JsonGenerator jsg = new JsonGenerator();
            while (true)
            {
                jsg.GetUserDetails();
                Thread.Sleep(1000);
            }
        }
        

        Dictionary<CheckParameter.Parameters, string> dict = new Dictionary<CheckParameter.Parameters, string>();

        public void GetUserDetails()
        {
            string ln;
            ln = RandomValueGenerator.RandomDataGenerator();
            Console.WriteLine(ln);
            
            //PatientMonitor.CheckParameter.CheckWhetherAlertIsNeeded();
            //foreach (var d in data)
            //{
            //    Console.WriteLine(d.Value);
            //}

        }

        private string[] StringArrayGenerator(string ln)
        {


            int i = 0;

            string[] str = new string[4];
            var jobect = JObject.Parse(ln);
            //Console.WriteLine(jobect);


            foreach (var n in jobect)
            {
                str[i++] = n.Value.ToString();

            }

            //Console.WriteLine(dict.Values);
            return str;
        }
    }
}
