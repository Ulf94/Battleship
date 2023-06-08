namespace Battleships.Interfaces;

using Battleships.Models;

public interface IUserService
{
    public User CreateUser(string userType);
    public Point Shoot(string user);
}
