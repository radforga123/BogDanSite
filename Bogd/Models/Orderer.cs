using Microsoft.Identity.Client;

namespace Bogd.Models;

public class Orderer
{
    public Orderer()
    {
        
    }
    public Orderer(string fio,DateTime birthDate ,string pathToAvaImg)
    {
        FIO = fio;
        BirthDate = birthDate;
        PathToAvaIMG = pathToAvaImg;

    }
    public int Id { get; set; }
    
    public string FIO { get; set; }

    public DateTime BirthDate { get; set; }

    public string PathToAvaIMG { get; set; }

   public List<Order> Order { get; set; } = new();
}