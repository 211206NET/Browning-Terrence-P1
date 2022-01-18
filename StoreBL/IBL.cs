namespace StoreBL;

public interface IBL
{
    List<Customer> GetAllCustomers();
    List<Store> GetAllStores();
    List<Product> GetAllProducts();
    void AddCustomer(Customer customerToAdd);
    void AddStore(Store storeToAdd);
    void AddProduct(Product productToAdd);
    
}