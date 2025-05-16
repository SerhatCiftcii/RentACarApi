using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Persistence.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetByIdUserAsync(int id); //
        Task CreateUserAsync(User model);
        Task UpdateUserAsync(User model); 
        Task DeleteUserAsync(User model); //service tarafında id ile yaptım.
        Task<User> CheckUser(string email, string password);
    }
}
