using Metro.Models;

namespace Metro.Services;

public interface IDataService
{
    IEnumerable<User> GetUsers();
    IEnumerable<Product> GetProducts();
    IEnumerable<Order> GetOrders();
    void AddUser(User user);
    void AddProduct(Product product);
    void DeleteUser(int id);
    void DeleteProduct(int id);
}
