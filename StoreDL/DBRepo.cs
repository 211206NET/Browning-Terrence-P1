using Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
namespace StoreDL;
using System.Data;
using Serilog;
 public class DBRepo : IRepo
{
    private string _connectionString;
    public DBRepo(String connectionString)
    {
        _connectionString = connectionString;
    }

/// <summary>
/// Returns all customers from _allCustomers List
/// </summary>
/// <typeparam name="Customer">new customer object to add</typeparam>
/// <returns>all customers in the list</returns>
private static List<Customer> _allCustomers = new List<Customer>(); 
public List<Customer> GetAllCustomers() 
{
    List<Customer> allCustom = new List<Customer>();
    using SqlConnection connection = new SqlConnection(_connectionString);
        string CustomSelect = $"Select * From Customer ";
        DataSet CustomSet = new DataSet();
        using SqlDataAdapter CustomAdapter = new SqlDataAdapter(CustomSelect, connection);
        CustomAdapter.Fill(CustomSet, "Customer");
        DataTable CustomTable = CustomSet.Tables["Customer"];
        if(CustomTable!= null){
            foreach(DataRow row in CustomTable.Rows)
            {

                Customer Custom = new Customer(row);
                allCustom.Add(Custom);
            }
        }
        return allCustom;
    }
/// <summary>
/// Add a new customer to the list
/// </summary>
/// <param name="customerToAdd">new customer object to add</param>
public void AddCustomer(Customer customerToAdd)
{ 
    ///Establishing new connection
    using SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();
    ///Our insert command to add a user
    string sqlCmd = "INSERT INTO Customer (Id, UserName, PassWord, Email) VALUES (@Id, @UserName, @PassWord, @Email)"; 
    using SqlCommand cmdAddUser= new SqlCommand(sqlCmd, connection);
    ///Adding paramaters
    cmdAddUser.Parameters.AddWithValue("@Id", customerToAdd.Id);
    cmdAddUser.Parameters.AddWithValue("@UserName", customerToAdd.Username);
    cmdAddUser.Parameters.AddWithValue("@PassWord", customerToAdd.Password);
    cmdAddUser.Parameters.AddWithValue("@Email", customerToAdd.Email);        
    ///Executing command
    cmdAddUser.ExecuteNonQuery();
    connection.Close();
    
    Log.Information("Customer added{Id}{Username}{Password}{Email}",customerToAdd.Id,customerToAdd.Username,customerToAdd.Password,customerToAdd.Email);
}
/// <summary>
/// Returns all stores from allStores List
/// </summary>
/// <returns>all stores in the list</returns>
private static List<Store> _allStores = new List<Store>();
public List<Store> GetAllStores() 
{
    List<Store> allSto = new List<Store>();
    using SqlConnection connection = new SqlConnection(_connectionString);
        string StoSelect = $"Select * From Store ";
        DataSet StoSet = new DataSet();
        using SqlDataAdapter StoAdapter = new SqlDataAdapter(StoSelect, connection);
        StoAdapter.Fill(StoSet, "Store");
        DataTable StoTable = StoSet.Tables["Store"];
        if(StoTable!= null){
            foreach(DataRow row in StoTable.Rows)
            {

                Store Sto = new Store(row);
                allSto.Add(Sto);
            }
        }
    return allSto;
}
/// <summary>
/// Adds a new store to the list
/// </summary>
/// <param name="storeToAdd">new store object to add</param>
public void AddStore(Store storeToAdd)
{
    ///Establishing new connection
    using SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();
    ///Our insert command to add a user
    string sqlCmd = "INSERT INTO Store (Id, Name, Address) VALUES (@Id, @Name, @Address)"; 
    using SqlCommand cmdAddUser= new SqlCommand(sqlCmd, connection);
    ///Adding paramaters
    cmdAddUser.Parameters.AddWithValue("@Id", storeToAdd.Id);
    cmdAddUser.Parameters.AddWithValue("@Name", storeToAdd.Name);
    cmdAddUser.Parameters.AddWithValue("@Address", storeToAdd.Address);   
    ///Executing command
    cmdAddUser.ExecuteNonQuery();
    connection.Close();

    Log.Information("Store added{Id}{name}{Address}",storeToAdd.Id,storeToAdd.Name,storeToAdd.Address);

  }

/// <summary>
/// Adds a new product to the list
/// </summary>
/// <param name="productToAdd">new product object to add</param>
public void AddProduct(Product productToAdd)
{
    ///Establishing new connection
    using SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();
    ///Our insert command to add a user
    string sqlCmd = "INSERT INTO Product (Id, ProductName, Description, Price) VALUES (@Id, @ProductName, @Description, @Price)"; 
    using SqlCommand cmdAddUser= new SqlCommand(sqlCmd, connection);
    ///Adding paramaters
    cmdAddUser.Parameters.AddWithValue("@Id", productToAdd.Id);
    cmdAddUser.Parameters.AddWithValue("@ProductName", productToAdd.ProductName);
    cmdAddUser.Parameters.AddWithValue("@Description", productToAdd.Description);  
    cmdAddUser.Parameters.AddWithValue("@Price", productToAdd.Price); 
    ///Executing command
    cmdAddUser.ExecuteNonQuery();
    connection.Close();

    Log.Information("Product added{Id}{name}{description}{price}",productToAdd.Id,productToAdd.ProductName,productToAdd.Description,productToAdd.Price);

  }
    /// <summary>
    /// Adds a new order to the list
    /// </summary>
    /// <param name="orderToAdd">new store object to add</param>
    public void AddOrder(Order orderToAdd)
    {
        ///Establishing new connection
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        ///Our insert command to add a user
        string sqlCmd = "INSERT INTO Order (CustomerId, OrderId, StoreId, Total) VALUES (@CustomerId, @OrderNumber, @StoreId, @Total)";
        using SqlCommand cmdAddUser = new SqlCommand(sqlCmd, connection);
        ///Adding paramaters
        cmdAddUser.Parameters.AddWithValue("@CustomerId", orderToAdd.CustomerId);
        cmdAddUser.Parameters.AddWithValue("@OrderId", orderToAdd.OrderId);
        cmdAddUser.Parameters.AddWithValue("@StoreId", orderToAdd.StoreId);
        cmdAddUser.Parameters.AddWithValue("@Total", orderToAdd.Total);
        ///Executing command
        cmdAddUser.ExecuteNonQuery();
        connection.Close();

        Log.Information("Order added{CustomerId}{OrderNumber}{StoreId}{Total}", orderToAdd.CustomerId, orderToAdd.OrderId, orderToAdd.StoreId, orderToAdd.Total);

    }
    public List<Product> GetAllProducts()
  {
    List<Product> allProd = new List<Product>();
    using SqlConnection connection = new SqlConnection(_connectionString);
        string ProdSelect = $"Select * From Product ";
        DataSet ProdSet = new DataSet();
        using SqlDataAdapter ProdAdapter = new SqlDataAdapter(ProdSelect, connection);
        ProdAdapter.Fill(ProdSet, "Product");
        DataTable ProdTable = ProdSet.Tables["Product"];
        if(ProdTable!= null){
            foreach(DataRow row in ProdTable.Rows)
            {

                Product prod = new Product(row);
                allProd.Add(prod);
            }
        }
        return  allProd;
   }
    /// <summary>
    /// Finds all the orders placed from individuals
    /// </summary>
    /// <param name="CID"></param>
    /// <returns>all orders placed by that user</returns>
   public List<Order> GetAllOrders(int CID)
    {
        List<Order> allOrders = new List<Order>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string OrdSelect = $"SELECT * FROM Orders WHERE CustomerId = {CID}";
            using(SqlCommand cmd = new SqlCommand(OrdSelect, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.OrderId = reader.GetInt32(0);
                        CID = reader.GetInt32(1);
                        order.StoreId = reader.GetInt32(2);
                        order.Total = reader.GetInt32(3);
                        order.OrderDate = reader.GetDateTime(4);

                        allOrders.Add(order);
                    }
                }
            }
            connection.Close();
        }
        return allOrders;
    }
    public Store GetStoreById(int Id)
    {
         string query = "Select * From Store Where Id = @stoId";
         using SqlConnection connection = new SqlConnection(_connectionString);
         connection.Open();
         using SqlCommand cmd = new SqlCommand(query, connection);
         SqlParameter param = new SqlParameter("@stoId", Id);
         cmd.Parameters.Add(param);

         using SqlDataReader reader = cmd.ExecuteReader();
         Store store = new Store();
           if (reader.Read())
            {
              store.Id = reader.GetInt32(0);
              store.Name = reader.GetString(1);
              store.Address = reader.GetString(2);
            }
            connection.Close();
            return store;
        }
    public Customer GetCustomerById(int Id)
    {
        string query = "Select * From Customer Where Id = @custoId";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@custoId", Id);
        cmd.Parameters.Add(param);
        
        using SqlDataReader reader = cmd.ExecuteReader();
        Customer customer = new Customer();
        if (reader.Read())
        {          
            customer.Id = reader.GetInt32(0);
            customer.Username = reader.GetString(1);
            customer.Password = reader.GetString(2);
            customer.Email = reader.GetString(3);
        }
        connection.Close();
        return customer;
    }
    public Product GetProductById(int Id)
    {
        string query = "Select * From Product Where Id = @prodId";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@prodId", Id);
        cmd.Parameters.Add(param);

        using SqlDataReader reader = cmd.ExecuteReader();
        Product product = new Product();
        if (reader.Read())
        {
            product.Id = reader.GetInt32(0);
            product.ProductName = reader.GetString(1);
            product.Description = reader.GetString(2);
        }
        connection.Close();
        return product;
    }

    public List<Order> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public Order GetOrderById(int Id)
    {
        throw new NotImplementedException();
    }
}

 
  
