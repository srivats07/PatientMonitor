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
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DataGenerator
{
    public class Patient
    {
        public string pat_id;
        public string pat_spo2;
        public string pat_temp;
        public string pat_pulse;
    }
    public class DataGenerator_MockarooAPI
    {
        public static string b;
        static void Main(string[] args)
        {
            DataGenerator_MockarooAPI generator=new DataGenerator_MockarooAPI();
            JObject data = generator.RandomDataGenerator();

            foreach (var vars in data)
            {
                Console.WriteLine(vars.Value);
            }

        }

        public JObject RandomDataGenerator()
        {
            int counter = 0;
            var dictionary = new Dictionary<int, string>();
            //var dictionary = new List<Patient>();
            StreamReader sr = new StreamReader(@"C:\Users\320067390\Downloads\patient_data.csv");
            string line;
            JObject o = new JObject();
            while ((line = sr.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                string[] csv = line.Split(',');

                dictionary.Add(counter++,csv[0]);
                dictionary.Add(counter++, csv[1]);
                dictionary.Add(counter++, csv[2]);
                dictionary.Add(counter++, csv[3]);
            }

            string jsons = JsonConvert.SerializeObject(dictionary);
                // converting into json object used for piping
            o = JObject.Parse(jsons);
                
                //Console.WriteLine("Patient Details: {0}", jsons);


            
            ////var a = RandomFileGenerator();
            ////Console.WriteLine("The row no. is {0} ", a);
            //int a = 88;
            //JObject jsonObj = new JObject();
            //using (var reader = new StreamReader(@"C:\Users\320052122\Downloads\patient_data.csv"))
            //{
            //    for (int i = 1; i <= a; i++)
            //    {
            //        b = reader.ReadLine();
            //        Console.WriteLine(b);
            //        //jsonObj.Add(JObject.Parse(b));
            //        if (i == a)
            //        {
            //            Console.WriteLine("The Patient data :{0}", b);
            //        }
            //    }
            //}

            return o;
        }

        private static int RandomFileGenerator()
        {
            Random random = new Random();
            int a = random.Next(2, 101);
            string url = "https://my.api.mockaroo.com/patient_data.csv?key=1b9c8070";
            Process.Start(url);


            //var data = new WebClient().DownloadString(url);
            string path = @"C:\Users\320052122\Downloads\patient_data.csv";

            while (true)
            {
                if (File.Exists(path))
                    break;
            }

            return a;
        }
    }

    
}
