using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitor;
using JsonGenerator;
using Newtonsoft.Json.Linq;

namespace Alerting
{
    class Alerting
    {
        static void Main(string[] args)
        {
            string ln;
            CheckParameter obj = new CheckParameter();
            while ((ln=Console.ReadLine())!=null)
            {
                Console.WriteLine(ln);
                Console.WriteLine("---------------------------------");
                string[] string_array = StringArrayGenerator(ln);
                Dictionary<CheckParameter.Parameters,string> Data = DictGenerator(string_array);
                obj.CheckWhetherAlertIsNeeded(Data);
                Console.WriteLine();

            }

            
        }


        private static Dictionary<CheckParameter.Parameters,string> DictGenerator(string [] str)
        {
            Dictionary<CheckParameter.Parameters, string> dict = new Dictionary<CheckParameter.Parameters, string>();
            dict.Add(CheckParameter.Parameters.PatientID, str[0]);
            dict.Add(CheckParameter.Parameters.SPO2, str[1]);
            dict.Add(CheckParameter.Parameters.PulseRate, str[2]);
            dict.Add(CheckParameter.Parameters.Temperature, str[3]);
            return dict;
        }

        private static string[] StringArrayGenerator(string ln)
        {
            int i = 0;

            string[] str_array = new string[4];
            var jobect = JObject.Parse(ln);
            //Console.WriteLine(jobect);
            
            foreach (var n in jobect)
            {
                str_array[i++] = n.Value.ToString();

            }

            //Console.WriteLine(dict.Values);
            return str_array;
        }
    }
}
