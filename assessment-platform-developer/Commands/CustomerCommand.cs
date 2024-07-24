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
    public interface ICustomerCommand
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }

    public class CustomerCommand : ICustomerCommand
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        public CustomerCommand(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }

        public void AddCustomer(Customer customer)
        {
            _customerCommandRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerCommandRepository.Update(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerCommandRepository.Delete(id);
        }
    }
}