using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Zza.Data;
using Zza.Entities;

namespace PizzaServices
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PizzaService : IPizzaService, IDisposable
    {
        readonly ZzaDbContext _Context = new ZzaDbContext();

        public List<Product> GetProducts()
        {
            return _Context.Products.ToList();
        }

        public List<Customer> GetCustomers()
        {
            return _Context.Customers.ToList();
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SubmitOrder(Order order)
        {
            _Context.Orders.Add(order);
            order.OrderItems.ForEach(oi => _Context.OrderItems.Add(oi));
            _Context.SaveChanges();
        }

        public void Dispose()
        {
            // Dispose the DB connection 
            // WCF automatically dispose the dbContext of the service that it is hosting, if it implements IDisposable
            _Context.Dispose();
        }
    }
}
