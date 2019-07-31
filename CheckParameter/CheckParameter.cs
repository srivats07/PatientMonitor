using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecieverPipe;
namespace Alert
{
    class CheckParameter
    {
        public static bool abnormalTemp;
        public static bool abnormalSpo2;
        public static bool abnormalPR;
        static void Main(string[] args)
        {


            JArray j = Program.JArrayCreator();
            
            var json = j.ToString();
            //foreach (var h in j)
            //{
            //    Console.WriteLine(h);
            //}
            
            string temp1=null;
            for (int i = 0; i < json.Length; i++)
            {
                temp1 = json.Replace('"', ' ').Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("PatientID =","").Replace("Temperature =", "").Replace("PulseRate =", "").Replace("SPO2 =", "");
            }
            var s = temp1.Split('\n');
            Console.WriteLine("0000000000000000");
            //for (int i = ; i < UPPER; i++)
            //{
                
            //}
            Console.WriteLine("--------------------");
            Console.WriteLine(s[0]);
            Console.WriteLine(s[1]);
            Console.WriteLine(s[3]);

            for (int i = 0; i < UPPER; i++)
            {
                
            }
            var value[] = s[i].Split(',');
            //JToken jj = JToken.Parse(json);
            //JObject jjj = jj["PatientID"].Value<JObject>();
            //List<string> keys = jjj.Properties().Select(p => p.Name).ToList();

            //foreach (var key in keys)
            //{
            //    Console.WriteLine(key);
            //}
            //string[] str =new string[100];

            //    str = json.Split(',');



            //Console.WriteLine(str);
            //char[] ch = { '{', '}','[',']'};
            //String [] str = new string[100];
            //string str = j.ToString().Trim(ch);
            //Console.WriteLine(str);
            //foreach (var v in j)
            //{

            //    var temp1 =v.ToString().Replace(',',' ').Replace('"',' ').Replace('{',' ').Replace('}',' ').Replace('[',' ').Replace(']',' ');

            //    Console.WriteLine(temp1);

            //}

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
