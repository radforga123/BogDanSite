namespace Bogd.Contracts.Order;

public record GetOrderRequest(string? Search, string? Sort, string? SortOrder);