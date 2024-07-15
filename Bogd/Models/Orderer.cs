using Microsoft.Identity.Client;

namespace Bogd.Models;

public class Orderer
{
    public Orderer(string fio, string pathToAvaImg, List<Order> order)
    {
        fio = FIO;
        pathToAvaImg = PathToAvaIMG;
        order = Order;
    }
    public int Id { get; set; }
    
    public string FIO { get; set; }

    public string PathToAvaIMG { get; set; }

    public List<Order> Order { get; set; } = new();
}