namespace Bogd.Contracts.Orderer;

public record GetOrdererRequest(string? Search, string? Sort, string? SortOrder);