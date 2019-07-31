using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DataGenerator;

namespace JsonGenerator
{
    public class Generator
    {
        static void Main(string[] args)
        {
            Generator ob = new Generator();
            ob.JsonHandler();
            
        }

        public StringBuilder FileHandler()
        {
            string file = @"C:\Users\320052122\Desktop\Alerting\user.json";
            StringBuilder content = new StringBuilder(100);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                content.Append(line);
            }
            reader.Dispose();
            return content;
        }

        public JArray JsonHandler()
        {
            JArray j = DataGenerator.DataGenerator.RandomDataGenerator();
            return j;
        }
    }
    
}
