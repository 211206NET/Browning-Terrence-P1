global using Models; 
namespace StoreDL;
//What's an interface?
//Interface is a contract, in essence
//It enforces that any type that implements the interface
//must also implement all of the interface's members as public methods
//We use interface to define/enforce a certain set of behavior on a type (such as class)
//This is an example of Abstraction (one of 4 OOP Pillars)
//Other OOP Pillars are Polymorphism, Inheritance, Encapsulation (A PIE!)
//Interface only has methods

public interface IRepo
{
    //Notice, how we're lacking access modifiers
    //interface members are implicitely public
    //they also lack method body
    List<Customer> GetAllCustomers();
    List<Store> GetAllStores();
    List<Product> GetAllProducts();
   // List<Inventory> GetStoreInventory();
    List<Order> GetAllOrders(int CID);
   // List<Order> GetAllStoreOrders();
    void AddCustomer(Customer customerToAdd);
    void AddStore(Store storeToAdd);
    void AddProduct(Product productToAdd);

    Store GetStoreById(int Id);
    Customer GetCustomerById(int Id);

    // void AddLineItem(LineItem newLI, int orderID);   
    void AddOrder(Order orderToAdd);  
    // void RemoveProduct(int prodID);
    // void RestockStoreInventory(int prodID, int quantity);
    // void AddProductToInventory(int prodID, Inventory inventToAdd);
    // int GetCustomerID(string username);
    // int GetProductID(string productname);    

}
