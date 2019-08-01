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
        public static int size = 100;
        public static string b;
        public static Random rand = new Random();
        /// <summary>
        /// Generates random data
        /// </summary>
        /// <returns></returns>
        public static String RandomDataGenerator()
        {
            String json = null;
            Random random = new Random();
            string patientId = RandomString();
            double patientTemperature = Math.Round(90 + (100 - 90) * rand.NextDouble(), 2, MidpointRounding.ToEven);
            decimal patientPulseRate = random.Next(40, 220);
            decimal patientSpo2 = random.Next(30, 254);
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
        /// Generates random PatientID
        /// </summary>
        /// <returns></returns>

        public static string RandomString()
        {
            StringBuilder builder = new StringBuilder();

            char ch;
            for (int i = 0; i < 8; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}

