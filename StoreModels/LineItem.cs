namespace Models;
using System.Data;
public class LineItem
{
    public LineItem(DataRow row){
            Id = (int)row["Id"];
            OrderId = (int)row["OrderId"];
            InventoryId = (int)row["InventoryId"];
            ProductId = (int)row["ProductId"];          
            Quantity = (int)row["Quantity"];
    }
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int InventoryId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    
}