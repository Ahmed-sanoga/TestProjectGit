using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.DOTs;
using SuperheroAPI.Entites;
using SuperheroAPI.Repositories;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepsitories _repository;

        public CustomersController(ICustomersRepsitories repository)
        {
            _repository = repository;
        }
        [HttpGet]

        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            var customers = await _repository.GetCustomersAsync();
            return Ok(customers);

        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customers = await _repository.GetCustomerById(id);
            if (customers == null)
                return NotFound("Card not found");

            return Ok(customers);

        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(CustomerDto customer)
        {

            await _repository.AddCustomer(customer);
            return Ok(await _repository.GetCustomersAsync());
        }

        [HttpPut]

        public async Task<ActionResult> UpdateCustomer(Customer customer)

        {
            var existing = await _repository.GetCustomerById(customer.Id);
            if (existing == null)
                return NotFound("Customer not found");

            await _repository.UpdateCustomer(customer);
            return Ok("Customer updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customer = await _repository.GetCustomerById(id);
            if (customer == null)
                return NotFound("Customer not found");

            await _repository.DeleteCustomer(customer);
            return Ok("Customer deleted successfully");
        }
    }
}
