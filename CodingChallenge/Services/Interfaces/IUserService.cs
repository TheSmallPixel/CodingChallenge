using CodingChallenge.Entities;
using CodingChallenge.Models;
using System.Collections.Generic;
namespace CodingChallenge.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
