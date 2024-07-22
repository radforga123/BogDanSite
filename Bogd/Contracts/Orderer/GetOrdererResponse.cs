using Bogd.DTOs;

namespace Bogd.Contracts.Orderer;

public record GetOrdererResponse(List<OrdererDto> orderers);