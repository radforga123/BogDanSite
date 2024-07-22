namespace Bogd.Models;

public class User
{
    public User(string userName,string email ,string passwordHash)
    {
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;

    }
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}