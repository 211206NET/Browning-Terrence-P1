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

    public Store GetStoreById(int Id)
    {
        return _dl.GetStoreById(Id);
    }
    public Customer GetCustomerById(int Id)
    {
        return _dl.GetCustomerById(Id);
    }

    //      public void AddLineItem(LineItem newLI, int orderID)
    //     {
    //         _dl.AddLineItem(newLI, orderID);
    //     }
    public void AddOrder(Order orderToAdd)
    {
        _dl.AddOrder(orderToAdd);
    }
    public List<Order> GetAllOrders(int CID)
    {
        return _dl.GetAllOrders(CID);
    }
    
        //     public int GetCustomerID(string username)
        //     {
        //         return _dl.GetCustomerID(username);
        //     }
        //     public List<Inventory> GetStoreInventory()
        //     {
        //         return _dl.GetStoreInventory();
        //     }
        //     public void RemoveProduct(int prodID)
        //     {
        //         _dl.RemoveProduct(prodID);
        //     }
        //     public void RestockStoreInventory(int prodID, int quantity)
        //     {
        //         _dl.RestockStoreInventory(prodID, quantity);
        //     }
        //    public List<Order> GetAllStoreOrders()
        //     {
        //        return _dl.GetAllStoreOrders();
        //     }
        //     public int GetProductID(string productname)
        //     {
        //         return _dl.GetProductID(productname);
        //     }
        //     public void AddProductToInventory(int prodID, Inventory inventToAdd)
        //     {
        //         _dl.AddProductToInventory(prodID, inventToAdd);
        //     }
    }
   