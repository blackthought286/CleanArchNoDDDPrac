namespace CleanArchPrac.Users;

public interface IPasswordHasher
{
    string Hash(string password);
}