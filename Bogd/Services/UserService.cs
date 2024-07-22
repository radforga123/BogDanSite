namespace Bogd.Services;

public class UserService
{
   private readonly PasswordHasher _passwordHasher;
   
   public async Task Register(string userName, string email, string password)
   {
      var hashedPassword = _passwordHasher.Generate(password);
   }
}