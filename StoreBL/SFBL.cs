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
    public List<Product> GetAllProducts()
    {
        return _dl.GetAllProducts();
    }
    public List<Order> GetAllOrders()
    {
        return _dl.GetAllOrders();
    }
    public void AddCustomer(Customer customerToAdd)
    {
        _dl.AddCustomer(customerToAdd);
    }
    public void AddStore(Store storeToAdd)
    {
        if (!_dl.IsDuplicate(storeToAdd))
        {
            _dl.AddStore(storeToAdd);
        }
        else throw new DuplicateRecordException("A store with same name, and address already exists!");
    }
    public void AddProduct(Product ProductToAdd)
    {
        _dl.AddProduct(ProductToAdd);
    }
    public void AddOrder(Order orderToAdd)
    {
        _dl.AddOrder(orderToAdd);
    }

    public Store GetStoreById(int Id)
    {
        return _dl.GetStoreById(Id);
    }
    public Customer GetCustomerById(int Id)
    {
        return _dl.GetCustomerById(Id);
    }
    public Product GetProductById(int Id)
    {
        return _dl.GetProductById(Id);
    }
    public Order GetOrderById(int Id)
    {
        return _dl.GetOrderById(Id);
    }

    public bool IsDuplicate(Store store)
    {
        throw new DuplicateRecordException();
    }

    public bool CustomerLogin(string Username, string Password)
    {
        return _dl.CustomerLogin(Username, Password);
    }

    public Customer GetCustomerUsername(string username)
    {
        return _dl.GetCustomerUsername(username);
    }


    //      public void AddLineItem(LineItem newLI, int orderID)
    //     {
    //         _dl.AddLineItem(newLI, orderID);
    //     }

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
