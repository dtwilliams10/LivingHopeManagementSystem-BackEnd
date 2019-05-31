using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LHMSAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LHMSAPI.Models
{
    public class UsersRepository
    {

        private readonly IMongoCollection<User> _users = null;

        public UsersRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase("LHMS");
            _users = database.GetCollection<User>("users");
        }
       public async Task AddUser(User user)
        {
            try 
            {
             await _users.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                return await _users.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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