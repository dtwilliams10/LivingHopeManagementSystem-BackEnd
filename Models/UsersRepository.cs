using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LHMSAPI.Models
{
    public class UsersRepository
    {

        public UsersRepository(IConfiguration config)
        {
            throw new NotImplementedException();
        }
       public Task AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
           throw new NotImplementedException();
        }

        public Task<User> GetUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUserAge(string id, string age)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUserName(string id, string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUserSummary(string id, string summary)
        {
            throw new System.NotImplementedException();
        }

        /* Task IUsersRepository.AddUser(User user)
        {
            throw new System.NotImplementedException();
        } */

    }

}