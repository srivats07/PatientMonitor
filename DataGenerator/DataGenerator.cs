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

namespace DataGenerator
{
    class DataGenerator
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
            Console.WriteLine("The row no. is {0} ", a);
            using (var reader = new StreamReader(@"C:\Users\320067581\Downloads\MOCK_DATA.csv"))
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
