using Bogd.Models;

namespace Bogd.DTOs;

public record OrderDto(int Id, string Name, string Describe, string Address,DateTime CreatedDateTime, DateTime OrderDateTime, int OrdererId, Orderer Orderer);