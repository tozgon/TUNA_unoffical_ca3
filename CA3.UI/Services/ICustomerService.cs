using CA3.DataModels;
using System.Threading.Tasks;

namespace CA3.UI.Services
{
	public interface ICustomerService
	{
		Task<IEnumerable<Customer>> getCustomers();

		Task<HttpResponseMessage> CreateCustomer(Customer customer);

		Task<Customer?> GetCustomerById(int id);

		Task<HttpResponseMessage> UpdateCustomer(int id, Customer customer);

		Task<HttpResponseMessage> DeleteCustomer(int id);

		Task<Order?> GetOrderById(int id);

		Task<HttpResponseMessage> CreateOrder(Order order);

		Task<HttpResponseMessage> UpdateOrder(int id, Order order);

		Task<HttpResponseMessage> DeleteOrder(Order order);

	}
}
