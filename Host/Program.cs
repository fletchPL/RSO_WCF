using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary1;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/MyService");
            ServiceHost selfHost = new ServiceHost(typeof(Service1), new Uri[] { baseAddress });
            try
            {
            }
            catch(Exception e)
            {

            }
        }
    }
}
