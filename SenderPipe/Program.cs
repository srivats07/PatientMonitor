using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using JsonGenerator;

namespace SenderPipe
{
    class Program
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

                StringBuilder content = new StringBuilder(100);

                Generator generator = new Generator();


                content = generator.FileHandler();

                sw.WriteLine(content);


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
