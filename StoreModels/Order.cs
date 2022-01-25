namespace Models;
using System.Data;
public class Order
{
    public DateTime OrderDate { get; set; }  //You can also use DateTime data type for this

    public Order()
    {
    }
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
    public int StoreId { get; set; }
    public decimal Total { get; set; }
    public List<LineItem> LineItems { get; set; }
   


    // public decimal CalculateTotal() {
    //     //a method that would go through each lineitem in LineItems property
    //     //and sets the total property of the particular order object
    //     decimal total1 = 0;
    //     decimal total = 0;
    //     if(this.LineItems?.Count > 0)
    //     {
    //         foreach(LineItem lineitem in this.LineItems)
    //         {
    //             //multiply the product's price by how many we're buying
    //             total1 += lineitem.Item.Price * lineitem.Quantity;
    //             total += total1;
    //         }
    //     }
    //     this.Total = total;
    //     return Total;
    // }

    public void ToDataRow(ref DataRow row)
    {

        row["CustomerId"] = this.CustomerId;
        row["OrderId"] = this.OrderId;       
        row["StoreId"] = this.StoreId;
        row["Total"] = this.Total;
        row["OrderDate"] = this.OrderDate;
    }


public Order(DataRow row)
{
    OrderId = (int)row["OrderId"];
    CustomerId = (int)row["CustomerId"];
    StoreId = (int)row["StoreId"];
    Total = (decimal)row["Total"];
    //OrderDate = row["orderdate"].ToString();
}
// public int OrderId { get; set; }
// public int CustomerId { get; set; }
// public int StoreId { get; set; }
// public List<LineItem> LineItems { get; set; }
// public decimal Total { get; set; }
// // public decimal CalculateTotal() {
// //     //a method that would go through each lineitem in LineItems property
// //     //and sets the total property of the particular order object
// //     decimal total = 0;
// //     if(this.LineItems?.Count > 0)
// //     {
// //         foreach(LineItem lineitem in this.LineItems)
// //         {
// //             //multiply the product's price by how many we're buying
// //             //total += lineitem.Item.Price * lineitem.Quantity;
// //         }
// //     }
// //     this.Total = total;
// //     return total;
 }