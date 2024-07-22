namespace Bogd.Contracts.User;

public record RegisterUserRequest(string UserName, string Email, string Password);