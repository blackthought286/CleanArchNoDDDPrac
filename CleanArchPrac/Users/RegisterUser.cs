namespace CleanArchPrac.Users;

public sealed class RegisterUser(IUserRepository userRepository, IPasswordHasher passwordHasher)
{
    public record Request(string Email, string FirstName, string LastName, string Password);
    
    public async Task<User> HandleUser(Request request)
    {
        if (await userRepository.Exists(request.Email))
        {
            throw new Exception($"Email {request.Email} already exists");
        }
        
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PasswordHash = passwordHasher.Hash(request.Password)
        };

        await userRepository.Insert(user);
        
        return user;
    }
}