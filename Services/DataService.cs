using Metro.Models;

namespace Metro.Services;

public class DataService : IDataService
{
    private readonly List<User> _users = new()
    {
        new User { Id = 1, Username = "admin", FullName = "מנהל ראשי", Email = "admin@metro.com", Role = "מנהל", IsActive = true },
        new User { Id = 2, Username = "user1", FullName = "ישראל ישראלי", Email = "user1@metro.com", Role = "משתמש", IsActive = true },
        new User { Id = 3, Username = "manager", FullName = "שרה כהן", Email = "manager@metro.com", Role = "מנהל מחלקה", IsActive = true },
        new User { Id = 4, Username = "analyst", FullName = "דוד לוי", Email = "analyst@metro.com", Role = "אנליסט", IsActive = false },
    };

    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "מחשב נייד Dell", Category = "אלקטרוניקה", Price = 3500, Stock = 15, Description = "מחשב נייד עסקי", IsActive = true },
        new Product { Id = 2, Name = "עכבר אלחוטי", Category = "אביזרים", Price = 89, Stock = 50, Description = "עכבר Bluetooth", IsActive = true },
        new Product { Id = 3, Name = "מקלדת מכנית", Category = "אביזרים", Price = 350, Stock = 25, Description = "מקלדת גיימינג", IsActive = true },
        new Product { Id = 4, Name = "מסך 27 אינץ", Category = "אלקטרוניקה", Price = 1200, Stock = 8, Description = "מסך 4K", IsActive = true },
        new Product { Id = 5, Name = "כיסא משרדי", Category = "ריהוט", Price = 950, Stock = 12, Description = "כיסא ארגונומי", IsActive = true },
    };

    private readonly List<Order> _orders = new()
    {
        new Order { Id = 1, CustomerName = "חברת ABC", TotalAmount = 5200, Status = "הושלם", OrderDate = DateTime.Now.AddDays(-5) },
        new Order { Id = 2, CustomerName = "חברת XYZ", TotalAmount = 1800, Status = "בטיפול", OrderDate = DateTime.Now.AddDays(-2) },
        new Order { Id = 3, CustomerName = "דוד מזרחי", TotalAmount = 440, Status = "ממתין", OrderDate = DateTime.Now.AddDays(-1) },
        new Order { Id = 4, CustomerName = "חברת Tech Ltd", TotalAmount = 8900, Status = "הושלם", OrderDate = DateTime.Now.AddDays(-10) },
    };

    private int _nextUserId = 5;
    private int _nextProductId = 6;

    public IEnumerable<User> GetUsers() => _users.ToList();
    public IEnumerable<Product> GetProducts() => _products.ToList();
    public IEnumerable<Order> GetOrders() => _orders.ToList();

    public void AddUser(User user)
    {
        user.Id = _nextUserId++;
        _users.Add(user);
    }

    public void AddProduct(Product product)
    {
        product.Id = _nextProductId++;
        _products.Add(product);
    }

    public void DeleteUser(int id) => _users.RemoveAll(u => u.Id == id);
    public void DeleteProduct(int id) => _products.RemoveAll(p => p.Id == id);
}
