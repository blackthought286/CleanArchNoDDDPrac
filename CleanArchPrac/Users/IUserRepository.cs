namespace CleanArchPrac.Users;

public interface IUserRepository
{
    Task Insert(User user);
    Task<bool> Exists(string email);
}