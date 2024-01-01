using System.Net;
using CA3.DataModels;
using CA3.UI.Pages;
using static System.Net.WebRequestMethods;

namespace CA3.UI.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly HttpClient _httpClient;

		public CustomerService(HttpClient httpClient)
		{
			this._httpClient = httpClient;
		}

		public async Task<IEnumerable<Customer>> getCustomers()
		{
			return await this._httpClient.GetFromJsonAsync<Customer[]>("api/Customers");
		}

		public async Task<HttpResponseMessage> CreateCustomer(Customer customer)
		{
			var response = await this._httpClient.PostAsJsonAsync<Customer>("api/Customers", customer);
			return response;
		}

		public async Task<Customer?> GetCustomerById(int id)
		{
			return await this._httpClient.GetFromJsonAsync<Customer>($"api/Customers/{id}");
		}

		public async Task<HttpResponseMessage> UpdateCustomer(int id, Customer customer)
		{
			var response = await this._httpClient.PutAsJsonAsync($"api/Customers/{id}", customer);
			return response;
		}

		public async Task<HttpResponseMessage> DeleteCustomer(int id)
		{
			var response = await this._httpClient.DeleteAsync($"api/Customers/{id}"); ;
			return response;
		}

		public async Task<Order?> GetOrderById(int id)
		{
			return await this._httpClient.GetFromJsonAsync<Order>($"api/Orders/{id}");
		}

		public async Task<HttpResponseMessage> CreateOrder(Order order)
		{
			var response = await this._httpClient.PostAsJsonAsync<Order>("api/Orders", order);


			return response;
		}

		public async Task<HttpResponseMessage> UpdateOrder(int id, Order order)
		{
			var response = await this._httpClient.PutAsJsonAsync($"api/Orders/{id}", order);
			if (response.StatusCode == HttpStatusCode.NoContent)
			{
				foreach (var orderItem in order.OrderItems)
				{
					this._httpClient.DeleteAsync($"api/OrderItems/{orderItem.OrderItemId}");
					this._httpClient.PostAsJsonAsync($"api/OrderItems", orderItem);
				}

			}
			return response;
		}

		public async Task<HttpResponseMessage> DeleteOrder(Order order)
		{
			foreach (var orderItem in order.OrderItems)
			{
				this._httpClient.DeleteAsync($"api/OrderItems/{orderItem.OrderItemId}");

			}

			var response = await this._httpClient.DeleteAsync($"api/Orders/{order.OrderId}");

			return response;
		}
	}
}
