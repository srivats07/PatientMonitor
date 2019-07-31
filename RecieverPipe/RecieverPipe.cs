using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Net.Mime;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace RecieverPipe
{
<<<<<<< HEAD:RecieverPipe/Program.cs
    public class Program
=======
    class RecieverPipe
>>>>>>> 0599f1cd6a37b2f82dfc7d0f4373a01a9934a903:RecieverPipe/RecieverPipe.cs
    {
        static void Main(string[] args)
        {
            JArrayCreator();
        }

<<<<<<< HEAD:RecieverPipe/Program.cs
        public static JArray JArrayCreator()
        {
            string path =
                Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
                @"\SenderPipe\bin\Debug\SenderPipe.exe";

            JArray result = new JArray();
=======
            var result = new List<string>();
            
>>>>>>> 0599f1cd6a37b2f82dfc7d0f4373a01a9934a903:RecieverPipe/RecieverPipe.cs
            // Create separate process
            var anotherProcess = new Process
            {
                StartInfo =
                {
                    FileName = path,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }
            };

            // Create 2 anonymous pipes (read and write) for duplex communications (each pipe is one-way)
            using (var pipeRead = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable))
            using (var pipeWrite = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            {
                //if (pipeRead == null && pipeWrite == null)
                //    //return;

                // Pass to the other process handles to the 2 pipes


                anotherProcess.StartInfo.Arguments =
                    pipeRead.GetClientHandleAsString() + " " + pipeWrite.GetClientHandleAsString();

                anotherProcess.Start();


                pipeRead.DisposeLocalCopyOfClientHandle();
                pipeWrite.DisposeLocalCopyOfClientHandle();

                try
                {
                    sender(pipeWrite);

                    reciever(pipeRead, result);
                }
                catch (Exception ex)
                {
                    //TODO Exception handling/logging
                    throw;
                }
                finally
                {
                    anotherProcess.WaitForExit();
                    anotherProcess.Close();
                }

                //if (result.Count > 0)
                //for (int i = 0; i < result.Count; i++)
                //{
                //    Console.WriteLine(result[i]);
                //}


                // Console.ReadLine();
            }

            return result;
        }

        public static void reciever(AnonymousPipeServerStream pipeRead, JArray result)
        {
            // Get message from the other process
            using (var sr = new StreamReader(pipeRead))
            {
                string temp;

                // Wait for 'sync message' from the other process
                do
                {
                    temp = sr.ReadLine();
                } while (temp == null || !temp.StartsWith("SYNC"));

                // Read until 'end message' from the other process
                while ((temp = sr.ReadLine()) != null && !temp.StartsWith("END"))
                {
                    result.Add(temp);
                }

                //sr.Dispose();
            }
        }

        public static void sender(AnonymousPipeServerStream pipeWrite)
        {
            using (var sw = new StreamWriter(pipeWrite))
            {
                // Send a 'sync message' and wait for the other process to receive it
                sw.Write("SYNC");
                pipeWrite.WaitForPipeDrain();

                sw.Write("END");
                //sw.Dispose();
            }
        }
    }
}
