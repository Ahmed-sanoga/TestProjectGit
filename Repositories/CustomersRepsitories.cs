using Microsoft.EntityFrameworkCore;
using SuperheroAPI.Data;
using SuperheroAPI.DOTs;
using SuperheroAPI.Entites;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SuperheroAPI.Repositories
{
    public class CustomersRepsitories : ICustomersRepsitories
    {
        private readonly CardsDbContext _context;
        public CustomersRepsitories(CardsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.FindAsync(id);
        
        
        }

        public async Task AddCustomer(CustomerDto customer)
        {
            _context.Customers.Add(new Customer()
            {
                 FullName = customer.FullName,
                 NationalNumber = customer.NationalNumber,
            });
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
    
    }
