namespace Bogd.Models;

public class Order
{
    public Order(string name, string describe, string address, DateTime createdDateTime, DateTime orderDateTime,int ordererId,
        Orderer orderer)
    {
        name = Name;
        describe = Describe;
        address = Address;
        createdDateTime = DateTime.Now;
        orderDateTime = OrderDateTime;
        ordererId = OrdererId;
        orderer = Orderer;
    }
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Describe { get; set; }

    public string Address { get; set; }
    
    public DateTime CreatedDateTime { get; set; }
    
    public DateTime OrderDateTime { get; set; }
    
    public int OrdererId { get; set; }
    public Orderer? Orderer { get; set; }
}