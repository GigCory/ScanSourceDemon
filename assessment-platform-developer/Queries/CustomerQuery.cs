using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using assessment_platform_developer.Repositories;
using assessment_platform_developer.Queries;

namespace assessment_platform_developer.Commands
{
    public interface ICustomerQuery
    {
        IEnumerable<CustomerQueryDTO> GetAllCustomers();
        CustomerQueryDTO GetCustomer(int id);
    }
    public class CustomerQuery : ICustomerQuery
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;
        public CustomerQuery(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }
        public IEnumerable<CustomerQueryDTO> GetAllCustomers()
        {
            return _customerQueryRepository.GetAll();
        }
        public CustomerQueryDTO GetCustomer(int id)
        {
            return _customerQueryRepository.Get(id);
        }
    }
}