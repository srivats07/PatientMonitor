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
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine(ln);
                string[] stringArray = ConvertJson(ln);
                Dictionary<CheckParameter.Parameters,string> data = GenerateData(stringArray);
                obj.VitalsAreNormal(data);
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Creates dictionary containing key value pairs of Patient data
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static Dictionary<CheckParameter.Parameters,string> GenerateData(string [] str)
        {
            Dictionary<CheckParameter.Parameters, string> dict = new Dictionary<CheckParameter.Parameters, string>
            {
                { CheckParameter.Parameters.PatientId, str[0] },
                { CheckParameter.Parameters.Spo2, str[1] },
                { CheckParameter.Parameters.PulseRate, str[2] },
                { CheckParameter.Parameters.Temperature, str[3] }
            };
            return dict;
        }

        /// <summary>
        /// creates string array of the Patient data
        /// </summary>
        /// <param name="ln"></param>
        /// <returns></returns>
        private static string[] ConvertJson(string ln)
        {
            int i = 0;
            string[] strArray = new string[4];
            var jObject = JObject.Parse(ln);
            foreach (var n in jObject)
            {
                strArray[i++] = n.Value.ToString();
            }
            return strArray;
        }
    }
}
