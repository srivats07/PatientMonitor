﻿using System;
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



        /// <summary>
        /// The min and max values of spo2, pulseRate and temperature are declared in App.config
        /// </summary>
        static readonly int SPO2Min = Convert.ToInt32(ConfigurationManager.AppSettings["SPO2Min"]);
        static readonly int SPO2Max = Convert.ToInt32(ConfigurationManager.AppSettings["SPO2Max"]);
        static readonly double TempMin = Convert.ToDouble(ConfigurationManager.AppSettings["TempMin"]);
        static readonly double TempMax = Convert.ToDouble(ConfigurationManager.AppSettings["TempMax"]);
        static readonly int PulseMin = Convert.ToInt32(ConfigurationManager.AppSettings["PulseMin"]);
        static readonly int PulseMax = Convert.ToInt32(ConfigurationManager.AppSettings["PulseMax"]);


        /// <summary>
        /// Patient Parameters
        /// </summary>
        public enum Parameters
        {
            PatientID,

            SPO2,
            PulseRate,
            Temperature
        }

        /// <summary>
        /// Checks whether parameters are in range and sends Alert accordingly
        /// </summary>
        /// <param name="dict"></param>
        public void VitalsAreNormal(Dictionary<Parameters, string> dict)
        {
            GetParameters(dict,out var SPO2, out var pulseRate, out var temperature);

            if (AbnormalSpo2(SPO2))
            {
                SendAlert("spo2-->" + Convert.ToString(SPO2));
            }
            if (AbnormalPulse(pulseRate))
            {
                SendAlert("pulseRate-->" + Convert.ToString(pulseRate));
            }
            if (AbnormalTemperature(temperature))
            {
                SendAlert("temperature-->" + Convert.ToString(temperature));
            }
        }
        /// <summary>
        /// extract parameter values
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="pulseRate"></param>
        /// <param name="temperature"></param>
        /// <returns></returns>
        public void GetParameters(Dictionary<Parameters, string> dict,out int SPO2, out int pulseRate, out double temperature)
        {
            SPO2 = int.Parse(dict[Parameters.SPO2]);
            pulseRate = int.Parse(dict[Parameters.PulseRate]);
            temperature = double.Parse(dict[Parameters.Temperature]);
            
        }
        /// <summary>
        /// Checks temperature range
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public bool AbnormalTemperature(double temp)
        {
            return temp > TempMax || temp < TempMin;
        }
        /// <summary>
        /// Checks PulseRate range
        /// </summary>
        /// <param name="pulseRate"></param>
        /// <returns></returns>
        public bool AbnormalPulse(int pulseRate)
        {
            return pulseRate > PulseMax || (pulseRate) < PulseMin;
        }

        /// <summary>
        /// Checks SPO2 range
        /// </summary>
        /// <param name="spo2"></param>
        /// <returns></returns>
        public bool AbnormalSpo2(int spo2)
        {
            return (spo2 > SPO2Max || spo2 < SPO2Min);
        }

        /// <summary>
        /// Sends Alert message when parameter is out of range
        /// </summary>
        /// <param name="alert"></param>
        private void SendAlert(string alert)
        {
            Console.WriteLine("The {0} is out of range", alert);
        }

    }



}

