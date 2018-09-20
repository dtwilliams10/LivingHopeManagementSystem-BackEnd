using System.Collections.Generic;
using System.Threading.Tasks;

namespace LHMSAPI.Models
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        
        Task<User> GetUser(string id);

        Task AddUser(User user);

        Task<bool> RemoveUser(string id);

        Task<bool> UpdateUserSummary(string id, string summary);

        Task<bool> UpdateUserName(string id, string name);

        Task<bool> UpdateUserAge(string id, string age);
    }
}