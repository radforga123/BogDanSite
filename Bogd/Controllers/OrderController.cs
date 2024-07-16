using Bogd.Contexts;
using Bogd.Contracts.Order;
using Bogd.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bogd.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController
{
    public readonly OrderContext _dbContext;

    public OrderController(OrderContext orderContext)
    {
        _dbContext = orderContext;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateOrderRequest request, CancellationToken ct)
    {
        var order = new Order(request.Name, request.Describe, request.Address, request.CreatedDateTime);
        await _dbContext.Orders.AddAsync(order,ct);
        await _dbContext.SaveChangesAsync(ct);
        return null;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return null;
    }
}