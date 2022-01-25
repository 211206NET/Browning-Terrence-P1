namespace StoreBL;

public interface IBL
{
    List<Customer> GetAllCustomers();
    List<Store> GetAllStores();
    List<Product> GetAllProducts();
    List<Order> GetAllOrders();
    // List<Inventory> GetStoreInventory();

    //List<Order> GetAllStoreOrders();
    void AddCustomer(Customer customerToAdd);
    void AddStore(Store storeToAdd);
    void AddProduct(Product productToAdd);
    void AddOrder(Order orderToAdd);

    Customer GetCustomerById(int Id);
    Store GetStoreById(int Id);
    Product GetProductById(int Id);
    Order GetOrderById(int Id);

    public bool CustomerLogin(string Username, string Password);
    public Customer GetCustomerUsername(string username);
    bool IsDuplicate(Store store);
    // void AddLineItem(LineItem newLI, int orderID);   

    // void RemoveProduct(int prodID);
    // void RestockStoreInventory(int prodID, int quantity);
    // void AddProductToInventory(int prodID, Inventory inventToAdd);
    // int GetCustomerID(string username);
    // int GetProductID(string productname);


}