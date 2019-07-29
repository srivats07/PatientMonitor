using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alert
{
    class CheckParameter
    {
        public static bool abnormalTemp;
        public static bool abnormalSpo2;
        public static bool abnormalPR;
        static void Main(string[] args)
        {
            string b = "04-3522593,98,83,110";
            string[] values = TakeInput(b);
            Console.WriteLine(values[0]);
            Console.WriteLine(values[1]);
            Console.WriteLine(values[2]);
            Console.WriteLine(values[3]);
            ValueCheck(values);

        }

        private static string[] TakeInput(string data)
        {
            string[] values = data.Split(',');

            return values;
        }
        private static void SendAlert(bool temp, bool spo2, bool pr)
        {
            if (temp)
            {
                Console.WriteLine("Abnormal Temperature value");
                System.Windows.MessageBox.Show("Abnormal Temperature value");
            }

            if (spo2)
            {
                Console.WriteLine("Abnormal SPO2 value");
                System.Windows.MessageBox.Show("Abnormal SPO2 value");
            }

            if (pr)
            {
                Console.WriteLine("Abnormal Pulse Rate is detected");
                System.Windows.MessageBox.Show("Abnormal Pulse Rate is detected");
            }
        }

        private static void ValueCheck(string[] values)
        {
            //Checking Temperature Value
            float temp = float.Parse(values[1]);
            int spo2 = Int32.Parse(values[2]);
            int pulseRate = Int32.Parse(values[3]);


            if (temp > 99 || temp < 97)
            {
                abnormalTemp = true;
            }

            if (spo2 < 91)
            {
                abnormalSpo2 = true;
            }

            if (pulseRate > 220 || pulseRate < 40)
            {
                abnormalPR = true;
            }
            SendAlert(abnormalTemp, abnormalSpo2, abnormalPR);

        }


    }
}
