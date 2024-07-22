using Bogd.DTOs;

namespace Bogd.Contracts.Order;

public record GetOrderResponse(List<OrderDto> orders);