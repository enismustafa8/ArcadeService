using ArcadeService.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcadeService.DL.Interfaces;
using ArcadeService.DL.LocalDb;



namespace ArcadeService.DL.Repositories
{
    public class CustomerLocalRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            StaticDb.Customers.Add(customer);
        }

        public void DeleteCustomer(Guid id)
        {
            StaticDb.Customers.RemoveAll(c => c.Id == id);
        }

        public List<Customer> GetAllCustomers()
        {
            return StaticDb.Customers;
        }

        public Customer? GetById(Guid id)
        {
            return StaticDb.Customers
                .FirstOrDefault(c => c.Id == id);
        }
    }
}

