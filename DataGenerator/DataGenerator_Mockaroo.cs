﻿using System;
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
    class DataGenerator_MockarooAPI
    {
        public static string b;
        static void Main(string[] args)
        {

            JObject data = RandomDataGenerator();



        }

        private static JObject RandomDataGenerator()
        {
            StreamReader sr = new StreamReader(@"C:\Users\320052122\Downloads\patient_data.csv");
            string line;
            JObject o = new JObject();
            while ((line = sr.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                string[] csv = line.Split(',');
                var dictionary = new Dictionary<string, string>();
                dictionary.Add("PatientID", csv[0]);
                dictionary.Add("Temperature", csv[1]);
                dictionary.Add("SPO2", csv[2]);
                dictionary.Add("PulseRate", csv[3]);



                string jsons = JsonConvert.SerializeObject(dictionary);
                // converting into json object used for piping
                o = JObject.Parse(jsons);
                foreach (var E in o)
                {
                    Console.WriteLine(E.Value);
                }
                //Console.WriteLine("Patient Details: {0}", jsons);


            }
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
