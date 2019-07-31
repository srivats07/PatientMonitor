using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DataGenerator
{
   public class DataGenerator
   {
       public static int size = 100;
        public static string b;
        public static Random rand = new Random();



        public static void Main(string[] args)
        {

             RandomDataGenerator();

        }
        /// <summary>
        /// creates random values upto 100 and returns all random values as JArray
        /// </summary>
        /// <returns></returns>
        public static JObject RandomDataGenerator()
        {
            //bool count = true;
            String[] json = new string[size];
            Random random = new Random();
            for (int i=0;i<size;++i)
            {
                
                string PatientID = RandomString();
                decimal PatientTemperature = random.Next(2, 101);
                decimal PatientPulseRate = random.Next(40, 220);
                decimal PatientSPO2 = random.Next(30, 254);

                //Console.WriteLine(PatientID);
                //Console.WriteLine(PatientTemperature);
                //Console.WriteLine(PatientSPO2);
                //Console.WriteLine(PatientPulseRate);

               var  Patients = new 
                {
                    PatientID = PatientID,
                    Temperature = PatientTemperature,
                    PulseRate = PatientPulseRate,
                    SPO2 = PatientSPO2
                };
               var jk = JsonConvert.SerializeObject(Patients);
               json[i] = jk;


            }
            JObject j = JObject.FromObject(json);
            //foreach (var s in json)
            //{
            //    Console.WriteLine(s);

            //}

            Console.WriteLine("------------------------------------");
            
            
            foreach (var data in j)
            {
                Console.WriteLine(data);
            }

            return j;


            //using (var reader = new StreamReader(@"C:\Users\320067581\Downloads\MOCK_DATA.csv"))
            //{
            //    for (int i = 1; i <= a; i++)
            //    {
            //        b = reader.ReadLine();
            //        if (i == a)
            //        {
            //            Console.WriteLine("The Patient data :{0}", b);
            //        }
            //    }
            //}


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

    }
}
