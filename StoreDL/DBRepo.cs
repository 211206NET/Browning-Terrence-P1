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
    return DBRepo._allCustomers;
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
    return DBRepo._allStores;
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
/// Adds a new store to the list
/// </summary>
/// <param name="storeToAdd">new store object to add</param>
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
  public List<Product> GetAllProducts(){
    List<Product> allProd = new List<Product>();
    using SqlConnection connection = new SqlConnection(_connectionString);
        string ProdSelect = $"Select * From Product ";
        DataSet ProdSet = new DataSet();
        using SqlDataAdapter ProdAdapter = new SqlDataAdapter(ProdSelect, connection);
        ProdAdapter.Fill(ProdSet, "Product");
        DataTable ProdTable = ProdSet.Tables["Product"];
        if(ProdTable!= null){
            foreach(DataRow row in ProdTable.Rows){

                Product prod = new Product(row);
                allProd.Add(prod);
            }
        }
        return  allProd;
   }
}  
  


