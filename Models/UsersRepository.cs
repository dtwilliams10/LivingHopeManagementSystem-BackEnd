using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LHMSAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LHMSAPI.Models
{
    public class UsersRepository : IUsersRepository
    {

        private readonly DatabaseContext _context = null;

        public UsersRepository(IOptions<Settings> settings)
        {
            _context = new DatabaseContext(settings);
        }
       public async Task AddUser(User user)
        {
            try 
            {
             await _context.Users.InsertOneAsync(user);
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
                return await _context.Users.Find(_ => true).ToListAsync();
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

        Task IUsersRepository.AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

    }

}