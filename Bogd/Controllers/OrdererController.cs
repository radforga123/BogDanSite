using System.Linq.Expressions;
using Bogd.Contexts;
using Bogd.Contracts.Orderer;
using Bogd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bogd.Contexts;
using Bogd.DTOs;

namespace Bogd.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdererController : ControllerBase
{
    public readonly OrderContext _dbContext;

    public OrdererController(OrderContext orderContext)
    {
        _dbContext = orderContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrdererRequest request , CancellationToken ct)
    {
        var orderer = new Orderer(request.FIO, request.BirthDate, request.PathToAvaImg);
        await _dbContext.Orderers.AddAsync(orderer, ct);
        await _dbContext.SaveChangesAsync(ct);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetOrdererRequest request, CancellationToken ct)
    {
        
        var ordererQuery =  _dbContext.Orderers
            .Where(n => string.IsNullOrWhiteSpace(request.Search) ||
                        n.FIO.ToLower().Contains(request.Search.ToLower()));

        
        Expression<Func<Orderer,object>> selectorKey =  request.Sort?.ToLower() switch
        {
            "fio" => orderer => orderer.FIO,
            "birthdate" => orderer => orderer.BirthDate,
            "pathtoavaimg" => orderer => orderer.PathToAvaIMG,
            _ => orderer => orderer.Id
        };
        ordererQuery = request.SortOrder == "desc" 
            ? ordererQuery.OrderByDescending(selectorKey) 
            : ordererQuery.OrderBy(selectorKey);

        var ordererDtos = await ordererQuery
            .Select(n => new OrdererDto(n.Id, n.FIO, n.BirthDate, n.PathToAvaIMG, n.Order))
            .ToListAsync(cancellationToken: ct);

        return  Ok(new GetOrdererResponse(ordererDtos));
    }
    

}