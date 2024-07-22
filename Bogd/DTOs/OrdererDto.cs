using Bogd.Models;

namespace Bogd.DTOs;

public record OrdererDto(int Id, string FIO,DateTime BirthDate ,string PathToAvaImg, List<Order> Order);