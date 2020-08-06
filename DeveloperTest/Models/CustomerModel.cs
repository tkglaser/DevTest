using DeveloperTest.Database.Enums;

namespace DeveloperTest.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public CustomerType Type { get; set; }
    }
}