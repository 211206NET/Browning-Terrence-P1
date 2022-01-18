namespace Models;
using System.Data;
public class Customer {
    public Customer(){}

        public Customer(DataRow row){
            Id = (int)row["Id"];
            Username = row["Username"].ToString();           
            Password = row["Password"].ToString();
            Email = row["Email"].ToString();



        }
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
}