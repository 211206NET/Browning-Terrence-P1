namespace StoreBL;

public interface IBL
{
    List<Customer> GetAllCustomers();
    List<Store> GetAllStores();
    List<Product> GetAllProducts();
    // List<Inventory> GetStoreInventory();
    List<Order> GetAllOrders(int CID);
    //List<Order> GetAllStoreOrders();
    void AddCustomer(Customer customerToAdd);
    void AddStore(Store storeToAdd);
    void AddProduct(Product productToAdd);
    Store GetStoreById(int Id);
    // void AddLineItem(LineItem newLI, int orderID);   
    void AddOrder(Order orderToAdd);  
    // void RemoveProduct(int prodID);
    // void RestockStoreInventory(int prodID, int quantity);
    // void AddProductToInventory(int prodID, Inventory inventToAdd);
    // int GetCustomerID(string username);
    // int GetProductID(string productname);


}