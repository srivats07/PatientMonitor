using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PatientMonitor
{

    public class JsonGenerator
    {
        public static bool abnormalTemp;
        public static bool abnormalSpo2;
        public static bool abnormalPR;

        public void GetUserDetails()
        {
           string ln;
           while ((ln = Console.ReadLine()) != null)
            {
                Thread.Sleep(TimeSpan.FromSeconds(4));
                
            var jobect = JObject.Parse(ln);
            Console.WriteLine(jobect);
            int i = 0;
            string[] str = new string[]{null, null, null, null };
            foreach (var n in jobect)
            {
                str[i++] = n.Value.ToString();
            }
            CheckWhetherAlertIsNeeded(str);
            Console.WriteLine();
        }
    }   

        public void CheckWhetherAlertIsNeeded(string[] str)
        {
            Boolean[] result=new bool[] { true, true, true };
            if (Convert.ToInt32(str[1]) < 91 || Convert.ToInt32(str[1]) > 100)
            {
                SendAlert("SPO2-->" + Convert.ToString(str[1]));
            }
            if (Convert.ToInt32(str[2]) < 60 || Convert.ToInt32(str[2]) > 100)
            {
                SendAlert("PulseRate-->" + Convert.ToString(str[2]));
            }
            if (Convert.ToDouble(str[3]) < 97.0 || Convert.ToDouble(str[3]) > 99.0)
            {
                SendAlert("Temperature-->" + Convert.ToString(str[3]));
            }
        }

        private void SendAlert(string alert)
        {
            Console.WriteLine("The {0} is out of range", alert);
        }

    }
}
