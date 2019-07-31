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
   public class Patient
    {
        public string PatientID { get; set; }
        public decimal SPO2 { get; set; }
        public decimal PulseRate { get; set; }
        public  decimal Temperature { get; set; }
    }

    //public class DataGenerator
    //{
    //    private static string b;
    //    private static object[] RandomDataGenerator()
    //    {
    //        Random random = new Random();
    //        int a = random.Next(2, 101);
    //        string url = "https://my.api.mockaroo.com/patient_data.csv?key=1b9c8070";
    //        Process.Start(url);
    //        //var data = new WebClient().DownloadString(url);
    //        string path = @"C:\Users\320052122\Downloads\patient_data.csv";
    //        while (true)
    //        {
    //            if (File.Exists(path))
    //                break;
    //        }

    //        Console.WriteLine("The row no. is {0} ", a);
    //        object[] jsonObj = new object[a];
    //        using (var reader = new StreamReader(@"C:\Users\320052122\Downloads\patient_data.csv"))
    //        {
    //            for (int i = 1; i <= a; i++)
    //            {
    //                b = reader.ReadLine();
    //                jsonObj[i] = new JObject(b);
    //                if (i == a)
    //                {
    //                    Console.WriteLine("The Patient data :{0}", b);
    //                }
    //            }
    //        }

    //        return jsonObj;
    //    }


    //    public void valueExtractor(object[] obj)
    //    {
    //        object[] jsonObjects = RandomDataGenerator();
    //    }
    //}



    public class JsonGenerator
    {
        public static bool abnormalTemp;
        public static bool abnormalSpo2;
        public static bool abnormalPR;
        public void DataReader(string filename)
        {
            // to read the file from AutoGenerator
            // logic for converting into JSON string
            //store it for future purposes
            string str;
        }

        public void ValueExtractor(string jsonfile)
        {
            //parse the json string to get parameters as per the case study
            // SPO2, temperature, pulse rate
            //pass these to range checking module
        }

        public void AddPatients()
        {
            Patient p = new Patient() { PatientID = "qw123", PulseRate = 20, SPO2 = 34, Temperature = 233 };
            string jsonSerialize = JsonConvert.SerializeObject(p);
            Console.WriteLine(jsonSerialize);
        }


        private string jsonFile = @"C:\Users\320052122\Desktop\Alerting\MOCK_DATA.json";
        public void AddPatient()
        {
            // { "patient id": "TRJIW432", "SPO2": 96, "pulse rate": 75, "temperature": 98.6 }
            Console.WriteLine("Enter Patient ID : ");
            var PatientID = Console.ReadLine();
            Console.WriteLine("\nEnter SPO2 value : ");
            var SPO2 = Console.ReadLine();
            Console.WriteLine("\nEnter pulse rate value : ");
            var pulseRate = Console.ReadLine();
            Console.WriteLine("\nEnter temperature value : ");
            var temperature = Console.ReadLine();

            var newPatients = "{ 'PatientID': " + PatientID + ", 'SPO2': " + SPO2 + ", 'PulseRate': " + pulseRate + ",'Temperature':" + temperature + "}";
            try
            {
                var json = File.ReadAllText(jsonFile);
                var jsonObj = JObject.Parse(json);
                var PatientArray = jsonObj.GetValue("Patients") as JArray;
                var newPatient = JObject.Parse(newPatients);
                PatientArray.Add(newPatient);

                jsonObj["Patients"] = PatientArray;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(jsonFile, newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }
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

                //Console.WriteLine(n.Value);
                str[i++] = n.Value.ToString();


            }
            AlertIsNeeded(str);
            


                Console.WriteLine();
        }
        

    }   

        
        public Boolean[] AlertIsNeeded(string[] str)
        {
            Boolean[] result=new bool[] { true, true, true };
            if (Convert.ToInt32(str[1]) < 91 || Convert.ToInt32(str[1]) > 100)
            {
                Alerter("SPO2-->" + Convert.ToString(str[1]));
                result[0] = false;
            }

            if (Convert.ToInt32(str[2]) < 60 || Convert.ToInt32(str[2]) > 100)
            {

                Alerter("PulseRate-->" + Convert.ToString(str[2]));
                result[2] = false;
            }

            if (Convert.ToDouble(str[3]) < 97.0 || Convert.ToDouble(str[3]) > 99.0)
            {

                Alerter("Temperature-->" + Convert.ToString(str[3]));
                result[1] = false;
            }

            return result;
        }

        private void Alerter(string alert)
        {
            Console.WriteLine("The {0} is out of range", alert);
        }

    }


}
