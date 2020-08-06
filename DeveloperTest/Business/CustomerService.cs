using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Business.Mapping;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CustomerModel[] GetCustomers()
        {
            return context.Customers.Select(x => x.ToModel()).ToArray();
        }

        public CustomerModel GetCustomer(int customerId)
        {
            return context.Customers
                .Where(x => x.CustomerId == customerId)
                .Select(x => x.ToModel())
                .SingleOrDefault();
        }

        public CustomerModel CreateCustomer(BaseCustomerModel model)
        {
            var addedCustomer = context.Customers.Add(model.ToDbModel());

            context.SaveChanges();

            return addedCustomer.Entity.ToModel();
        }
    }
}
