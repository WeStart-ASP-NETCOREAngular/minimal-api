using MinimalApiIntro.Models;

namespace MinimalApiIntro.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerById(int id);

        Task<Customer> Create(Customer customer);   
    }
}
