using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PatientMonitor;

namespace JsonGenerator
{
    public class RandomValueGenerator
    {
        const int TempMinGenerate = 90;
        const int TempMaxGenerate = 100;
        const int PulseMinGenerate = 40;
        const int PulseMaxGenerate = 220;
        const int Spo2MinGenerate = 30;
        const int Spo2MaxGenerate = 254;

        static Random random = new Random();
        
        /// <summary>
        /// Generates random data
        /// </summary>
        /// <returns></returns>
        public static String RandomDataGenerator()
        {
            String json = null;
            
            string patientId = RandomString();
            double patientTemperature = Math.Round(TempMinGenerate + (TempMaxGenerate - TempMinGenerate) * random.NextDouble(), 2, MidpointRounding.ToEven);
            decimal patientPulseRate = random.Next(PulseMinGenerate, PulseMaxGenerate);
            decimal patientSpo2 = random.Next(Spo2MinGenerate, Spo2MaxGenerate);
            var patients = new
            {
                PatientID = patientId,
                SPO2 = patientSpo2,
                PulseRate = patientPulseRate,
                Temperature = patientTemperature,
            };
            json = JsonConvert.SerializeObject(patients);
            return json;
        }
        /// <summary>
        /// Generates random PatientId
        /// </summary>
        /// <returns></returns>

        public static string RandomString()
        {
            StringBuilder builder = new StringBuilder();

            char ch;
            for (int i = 0; i < 8; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}

