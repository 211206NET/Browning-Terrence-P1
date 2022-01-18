namespace Models;
using System.Data;
public class Order
{

    public Order(){}

    public Order(DataRow row){
        OrderId = (int) row["OrderID"];
        CustomerId = (int) row["CustomerID"];
        StoreId = (int) row["storeID"];
        Total = (decimal)row["Total"];
        OrderDate =(string)row["OrderDate"];
    }
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int StoreId { get; set; }
    public List<LineItem> LineItems { get; set; }
    public string OrderDate { get; set; }   //You can also use DateTime data type for this
    public decimal Total { get; set; }
    // public decimal CalculateTotal() {
    //     //a method that would go through each lineitem in LineItems property
    //     //and sets the total property of the particular order object
    //     decimal total = 0;
    //     if(this.LineItems?.Count > 0)
    //     {
    //         foreach(LineItem lineitem in this.LineItems)
    //         {
    //             //multiply the product's price by how many we're buying
    //             //total += lineitem.Item.Price * lineitem.Quantity;
    //         }
    //     }
    //     this.Total = total;
    //     return total;
    }