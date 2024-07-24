using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using assessment_platform_developer.Repositories;

namespace assessment_platform_developer.Commands
{
    //public class CustomerCommand
    //{
    //}
    public interface ICustomerQuery
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
    }

    public class CustomerQuery : ICustomerQuery
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public CustomerQuery(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerQueryRepository.GetAll();
        }

        public Customer GetCustomer(int id)
        {
            return _customerQueryRepository.Get(id);
        }
    }
}