using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Repositories
{
    public interface ICustomerQueryRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(int id);
    }
    public class CustomerQueryRepository: ICustomerQueryRepository
    {
            // Assuming you have a DbContext named 'context'
            private readonly List<Customer> customers = new List<Customer>();
            //private readonly QueryDBContext _dbContext;
        //public CustomerQueryRepository(QueryDBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
            public IEnumerable<Customer> GetAll()
            {
                return customers;
            }

            public Customer Get(int id)
            {
                return customers.FirstOrDefault(c => c.ID == id);
            }
        }
}