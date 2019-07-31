using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using JsonGenerator;
<<<<<<< HEAD:SenderPipe/Program.cs
=======
using DataGenerator;
>>>>>>> 0599f1cd6a37b2f82dfc7d0f4373a01a9934a903:SenderPipe/SenderPipe.cs
using Newtonsoft.Json.Linq;

namespace SenderPipe
{
    class SenderPipe
    {
        static void Main(string[] args)
        {

            if (args == null || args.Length < 2) return;

            // Get read and write pipe handles
            // Note: Roles are now reversed from how the other process is passing the handles in
            string pipeWriteHandle = args[0];
            string pipeReadHandle = args[1];


            // Create 2 anonymous pipes (read and write) for duplex communications (each pipe is one-way)
            using (var pipeRead = new AnonymousPipeClientStream(PipeDirection.In, pipeReadHandle))
            using (var pipeWrite = new AnonymousPipeClientStream(PipeDirection.Out, pipeWriteHandle))
            {
                if(pipeRead==null&&pipeWrite==null) return;

                try
                {
                    var values = new List<string>();

                    Reciever(pipeRead, values);


                    Sender(pipeWrite);
                }
                catch (Exception ex)
                {
                    //TODO Exception handling/logging
                    throw;
                }
            }
        }

        private static void Sender(AnonymousPipeClientStream pipeWrite)
        {
            // Send value to calling process
            using (var sw = new StreamWriter(pipeWrite))
            {
                sw.AutoFlush = true;
                // Send a 'sync message' and wait for the calling process to receive it
                sw.WriteLine("SYNC");
                pipeWrite.WaitForPipeDrain();

                
                JObject jsonObject = new JObject();

                DataGenerator_MockarooAPI generator=new DataGenerator_MockarooAPI();

                JArray j = generator.JsonHandler();
                

<<<<<<< HEAD:SenderPipe/Program.cs
                sw.WriteLine(j);

=======
                jsonObject=generator.RandomDataGenerator();
                //content = generator.FileHandler();
                foreach (var vars in jsonObject)
                {
>>>>>>> 0599f1cd6a37b2f82dfc7d0f4373a01a9934a903:SenderPipe/SenderPipe.cs

                    sw.WriteLine(vars.Value.ToString());
                }
               
                sw.WriteLine("END");
            }
        }

        private static void Reciever(AnonymousPipeClientStream pipeRead, List<string> values)
        {
            // Get message from other process
            using (var sr = new StreamReader(pipeRead))
            {
                string temp;

                // Wait for 'sync message' from the other process
                do
                {
                    temp = sr.ReadLine();
                } while (temp == null || !temp.StartsWith("SYNC"));

                // Read until 'end message' from the server
                while ((temp = sr.ReadLine()) != null && !temp.StartsWith("END"))
                {
                    values.Add(temp);
                }
            }
        }
    }
}
