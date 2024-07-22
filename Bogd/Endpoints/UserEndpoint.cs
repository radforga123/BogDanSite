using System.Validation;
using Bogd.Contracts.User;
using Bogd.Services;

namespace Bogd.Endpoints;

public static class UserEndpoint
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        app.MapPost("login", Login);
        return app;
    }

    private static async Task<IResult> Register(RegisterUserRequest request,UserService userService)
    {

        await userService.Register(request.UserName,request.Email, request.Password);
        return Results.Ok();
    }
    
    public static async Task<IResult> Login(UserService userService)
    {
        return Results.Ok();
    }
}