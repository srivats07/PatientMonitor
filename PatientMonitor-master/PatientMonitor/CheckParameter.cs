using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitor
{

    public class CheckParameter
    {
        public static bool abnormalTemp;
        public static bool abnormalSpo2;
        public static bool abnormalPR;
        static int Spo2_min = Convert.ToInt32(ConfigurationManager.AppSettings["SPO2_min"]);
        static int Spo2_max = Convert.ToInt32(ConfigurationManager.AppSettings["SPO2_max"]);
        static double Temp_min = Convert.ToDouble(ConfigurationManager.AppSettings["Temp_min"]);
        static double Temp_max = Convert.ToDouble(ConfigurationManager.AppSettings["Temp_max"]);
        static int Pulse_min = Convert.ToInt32(ConfigurationManager.AppSettings["Pulse_min"]);
        static int Pulse_max = Convert.ToInt32(ConfigurationManager.AppSettings["Pulse_max"]);

        public enum Parameters
        {
            PatientID,
            SPO2,
            PulseRate,
            Temperature
        }

        //public static void CheckWhetherAlertIsNeeded(string[] str)
        //{
        //    abnormalSpo2 = CheckSpo2Range(str[1]);
        //    abnormalPR = CheckPulseRate(str[2]);
        //    abnormalTemp = CheckTemperature(str[3]);
        //}

        //private static bool CheckSpo2Range(string Spo2)
        //{
        //    int Spo2_int = Convert.ToInt32(Spo2);
        //    if (Spo2_int < Spo2_min || Spo2_int > Spo2_max)
        //    {
        //        SendAlert("SPO2-->" + Convert.ToString(Spo2_int));
        //        return true;
        //    }
        //    else { return false; }
        //}

        //private static bool CheckPulseRate(string pulse)
        //{
        //    int pulse_int = Convert.ToInt32(pulse);
        //    if (pulse_int < Pulse_min || pulse_int > Pulse_max)
        //    {
        //        SendAlert("PulseRate-->" + Convert.ToString(pulse_int));
        //        return true;
        //    }
        //    else { return false; }
        //}

        //private static bool CheckTemperature(string temp)
        //{
        //    double temp_double = Convert.ToDouble(temp);
        //    if (temp_double < Temp_min || temp_double > Temp_max)
        //    {
        //        SendAlert("Temperature-->" + Convert.ToString(temp_double));
        //        return true;
        //    }
        //    else { return false; }
        //}

        //private static void SendAlert(string alert)
        //{
        //    Console.WriteLine("The {0} is out of range", alert);
        //}
        public void CheckWhetherAlertIsNeeded(Dictionary<Parameters, string> str)
        {
            var SPO2 = GetParameters(str, out var PulseRate, out var Temperature);

            if (checkSPO2(SPO2))
            {
                SendAlert("SPO2-->" + Convert.ToString(SPO2));
            }
            if (checkPulse(PulseRate))
            {
                SendAlert("PulseRate-->" + Convert.ToString(PulseRate));
            }
            if (checkTemperature(Temperature))
            {
                SendAlert("Temperature-->" + Convert.ToString(Temperature));
            }
        }

        private int GetParameters(Dictionary<Parameters, string> dict, out int PulseRate, out double Temperature)
        {
            int SPO2 = int.Parse(dict[Parameters.SPO2]);
            PulseRate = int.Parse(dict[Parameters.PulseRate]);
            Temperature = double.Parse(dict[Parameters.Temperature]);
            return SPO2;
        }

        private static bool checkTemperature(double temp)
        {
            return temp < 97.0 || temp > 99.0;
        }

        private static bool checkPulse(int PulseRate)
        {
            return PulseRate < 60 || (PulseRate) > 100;
        }

        private static bool checkSPO2(int SPO2)
        {
            return SPO2 < 91 || SPO2 > 100;
        }

        private void SendAlert(string alert)
        {
            Console.WriteLine("The {0} is out of range", alert);
        }

    }



}

