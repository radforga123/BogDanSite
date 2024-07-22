using System.Linq.Expressions;
using Bogd.Contexts;
using Bogd.Contracts.Order;
using Bogd.DTOs;
using Bogd.Models;
using Microsoft.AspNetCore.Http.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        var order = new Order(request.Name, request.Describe, request.Address, request.OrderDateTime, request.OrdererId);
        await _dbContext.Orders.AddAsync(order,ct);
        await _dbContext.SaveChangesAsync(ct);

        return Ok();

    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]GetOrderRequest request, CancellationToken ct)
    {

            var orderQuery =  _dbContext.Orders
                .Where(n => string.IsNullOrWhiteSpace(request.Search) ||
                            n.Name.ToLower().Contains(request.Search.ToLower()));

        
        Expression<Func<Order,object>> selectorKey =  request.Sort?.ToLower() switch
        {
            "createddatetime" => order => order.CreatedDateTime,
            "name" => order => order.Name,
            "address" => order => order.Address,
            "orderdatetime" => order => order.OrderDateTime,
            _ => order => order.Id
        };
        orderQuery = request.SortOrder == "desc" 
            ? orderQuery.OrderByDescending(selectorKey) 
            : orderQuery.OrderBy(selectorKey);

        var orderDtos = await orderQuery
            .Select(n => new OrderDto(n.Id, n.Name, n.Describe, n.Address, n.CreatedDateTime, n.OrderDateTime, n.OrdererId,n.Orderer))
            .ToListAsync(cancellationToken: ct);

        return  Ok(new GetOrderResponse(orderDtos));
    }


}