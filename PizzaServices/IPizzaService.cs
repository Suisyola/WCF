using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Entities;

namespace PizzaServices
{
    [ServiceContract]
    public interface IPizzaService
    {
        [OperationContract]
        List<Product> GetProducts();

        [OperationContract()]
        List<Customer> GetCustomers();

        [OperationContract]
        void SubmitOrder(Order order);
    }
}
