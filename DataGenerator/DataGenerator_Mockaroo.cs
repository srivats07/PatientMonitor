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

namespace DataGenerator
{
    class DataGenerator_MockarooAPI
    {
        public static string b;
        static void Main(string[] args)
        {

            string data = RandomDataGenerator();

        }

        private static string RandomDataGenerator()
        {
            Random random = new Random();
            int a = random.Next(2, 101);
            string url = "https://my.api.mockaroo.com/patient_data.csv?key=1b9c8070";
            Process.Start(url);
            //var data = new WebClient().DownloadString(url);
            string path = @"C:\Users\320067581\Downloads\patient_data.csv";
            while (true)
            {
                if (File.Exists(path))
                    break;
            }
            Console.WriteLine("The row no. is {0} ", a);
            using (var reader = new StreamReader(@"C:\Users\320067581\Downloads\patient_data.csv"))
            {
                for (int i = 1; i <= a; i++)
                {
                    b = reader.ReadLine();
                    if (i == a)
                    {
                        Console.WriteLine("The Patient data :{0}", b);
                    }
                }
            }

            return b;
        }

    }
}
