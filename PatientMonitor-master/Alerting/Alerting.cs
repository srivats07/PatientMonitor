using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitor;

namespace Alerting
{
    class Alerting
    {
        static void Main(string[] args)
        {

            JsonGenerator objProgram = new JsonGenerator();
            objProgram.GetUserDetails();    
        }
    }
}
