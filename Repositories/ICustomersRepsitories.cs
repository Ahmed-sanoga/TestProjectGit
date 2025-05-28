using SuperheroAPI.DOTs;
using SuperheroAPI.Entites;

namespace SuperheroAPI.Repositories
{
    public interface ICustomersRepsitories
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(CustomerDto customer);

        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(Customer customer);


    }
}
