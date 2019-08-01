using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PatientMonitor;

namespace JsonGenerator
{
    public class RandomValueGenerator
    {
        public static int size = 100;
        public static string b;
        public static Random rand = new Random();

        public static String RandomDataGenerator()
        {
            //bool count = true;
            String json = null;
            
           
                Random random = new Random();

                string PatientID = RandomString();
                double PatientTemperature = Math.Round(90 + (100 - 90) * rand.NextDouble(),2,MidpointRounding.ToEven);
                decimal PatientPulseRate = random.Next(40, 220);
                decimal PatientSPO2 = random.Next(30, 254);
                var Patients = new
                {
                    PatientID = PatientID,
                    SPO2 = PatientSPO2,
                    PulseRate = PatientPulseRate,
                    Temperature = PatientTemperature,
                    
                };
                json = JsonConvert.SerializeObject(Patients);


            

            return json;
        }


        public static string RandomString()
        {
            StringBuilder builder = new StringBuilder();

            char ch;
            for (int i = 0; i < 8; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        //public static void JsonObjectToStringArray()
        //{
        //    string ln;
        //    while ((ln = RandomValueGenerator.RandomDataGenerator()) != null)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(4));
        //        var jobect = JObject.Parse(ln);
        //        Console.WriteLine(jobect);
        //        int i = 0;
        //        string[] str = new string[] { null, null, null, null };
        //        foreach (var n in jobect)
        //        {
        //            str[i++] = n.Value.ToString();
        //        }

        //        Console.WriteLine(str);
        //        CheckParameter.CheckWhetherAlertIsNeeded(str);
        //        Console.WriteLine();
        //    }
    }



}

