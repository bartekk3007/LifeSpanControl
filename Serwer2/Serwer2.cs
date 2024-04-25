using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using KSR_WCF2;

namespace Serwer2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Zadanie4 : IZadanie4
    {
        int counter = 0;

        public int Dodaj(int v)
        {
            counter += v;
            return counter;
        }

        public void Ustaw(int v)
        {
            counter = v;
        }
    }

    public class Task4Server
    {
        public static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Zadanie4));
            host.AddServiceEndpoint(typeof(IZadanie4), new NetNamedPipeBinding(), "net.pipe://localhost/ksr-wcf2-zad4");

            host.Open();
            Console.WriteLine("Host opened");
            Console.ReadKey();

            host.Close();
            Console.WriteLine("Host closed");
            Console.ReadKey();
        }
    }
}