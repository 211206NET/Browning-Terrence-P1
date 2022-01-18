namespace StoreBL;
public class SFBL : IBL
{
    private IRepo _dl;
    public SFBL(IRepo repo)
    {
        _dl = repo;
    }

    /// <summary>
    /// Gets all stores
    /// </summary>
    /// <returns>list of all stores</returns>
    public List<Store> GetAllStores()
    {
         return _dl.GetAllStores();
    }
    public List<Customer> GetAllCustomers()
    {
        return _dl.GetAllCustomers();
    }
    public void AddCustomer(Customer customerToAdd)
    {
        _dl.AddCustomer(customerToAdd);
    }

    /// <summary>
    /// Adds a new store to the list        
    /// </summary>
    /// <param name="storeToAdd">store object to add</param>
    public void AddStore(Store storeToAdd)
    {
        _dl.AddStore(storeToAdd);
    }
     public void AddProduct(Product ProductToAdd)
    {
        _dl.AddProduct(ProductToAdd);
    }       
    public List<Product> GetAllProducts()
    {
        return _dl.GetAllProducts();
    }  
    
 }
   