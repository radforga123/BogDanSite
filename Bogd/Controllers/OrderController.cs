using Bogd.Contexts;
using Bogd.Contracts.Order;
using Bogd.Models;
using Microsoft.AspNetCore.Http.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bogd.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    public readonly OrderContext _dbContext;

    public OrderController(OrderContext orderContext)
    {
        _dbContext = orderContext;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken ct)
    {
        var order = new Order(request.Name, request.Describe, request.Address, request.CreatedDateTime);
        await _dbContext.Orders.AddAsync(order,ct);
        await _dbContext.SaveChangesAsync(ct);

        return Ok();

    }

    [HttpGet]
    public async Task<IActionResult> Get(GetOrderRequest request, CancellationToken ct)
    {
        var orderQuery =  _dbContext.Orders
            .Where(n => !string.IsNullOrWhiteSpace(request.Search) &&
                        n.Name.ToLower().Contains(request.Search.ToLower()));
        if (request?.SortOrder == "desc")
        {
            orderQuery = orderQuery.OrderByDescending(n=> n.CreatedDateTime);
        }
        else if (request?.SortOrder == "voz")
        {
            orderQuery = orderQuery.OrderBy(n=> n.CreatedDateTime);
        }

        var orders = await orderQuery.ToListAsync(ct);

        return Ok();
    }
}