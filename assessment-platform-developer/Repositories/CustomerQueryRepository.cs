using assessment_platform_developer.Models;
using assessment_platform_developer.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Repositories
{
    public interface ICustomerQueryRepository
    {
        IEnumerable<CustomerQueryDTO> GetAll();
        CustomerQueryDTO Get(int id);
    }
    public class CustomerQueryRepository: ICustomerQueryRepository
    {
        // Assuming you have a DbContext named 'context'
        private readonly List<CustomerQueryDTO> _customers = new List<CustomerQueryDTO>();
    public IEnumerable<CustomerQueryDTO> GetAll()
            {
                return _customers;
            }

            public CustomerQueryDTO Get(int id)
            {
                return _customers.FirstOrDefault(c => c.ID == id);
            }
        }
}