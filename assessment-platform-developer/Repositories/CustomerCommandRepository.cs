using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Repositories
{
    public interface ICustomerCommandRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
    public class CustomerCommandRepository: ICustomerCommandRepository
    {
            // Assuming you have a DbContext named 'context'
            private readonly List<Customer> customers = new List<Customer>();
        //    private readonly QueryDBContext _dbContext;
        //public CustomerCommandRepository(QueryDBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.ID == customer.ID);
            if (existingCustomer != null)
            {
                // Update properties of existingCustomer based on the properties of customer
                // For example:
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.City = customer.City;
                existingCustomer.State = customer.State;
                existingCustomer.Address = customer.Address;
                existingCustomer.ContactEmail = customer.ContactEmail;
                existingCustomer.ContactTitle = customer.ContactTitle;
                existingCustomer.Country = customer.Country;
                existingCustomer.ContactNotes = customer.ContactNotes;
                existingCustomer.ContactPhone = customer.ContactPhone;
                // Repeat for other properties
            }
        }

        public void Delete(int id)
        {
            var customer = customers.FirstOrDefault(c => c.ID == id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
        }
    }
}