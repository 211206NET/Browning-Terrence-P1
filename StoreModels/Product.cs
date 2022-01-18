namespace Models;
using System.Data;
public class Product

{   
    public Product(){}
            public Product(DataRow row){
            Id = (int)row["Id"];
            ProductName = row["ProductName"].ToString();
            Description = row["Description"].ToString();
            Price = (decimal)row["Price"];

    }
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    
}