using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Client.PizzaServices;

namespace Zza.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaServiceClient proxy = new PizzaServiceClient("BasicHttpBinding_IPizzaService");
            var products = proxy.GetProducts();
            var customers = proxy.GetCustomers();
            proxy.Close();
           
        }
    }
}
