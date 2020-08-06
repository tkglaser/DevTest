using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business.Mapping
{
    public static class CustomerExtensions
    {
        public static CustomerModel ToModel(this Customer dbModel)
        {
            return new CustomerModel
            {
                CustomerId = dbModel.CustomerId,
                Name = dbModel.Name,
                Type = dbModel.Type
            };
        }

        public static Customer ToDbModel(this BaseCustomerModel model)
        {
            return new Customer
            {
                Name = model.Name,
                Type = model.Type
            };
        }
    }
}