using Bogd.Models;

namespace Bogd.Contracts.Order;

public record CreateOrderRequest(string Name, string Describe, string Address, DateTime CreatedDateTime);