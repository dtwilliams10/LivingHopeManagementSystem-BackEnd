using System;
using System.Collections.Generic;
using System.Linq;
using LHMSAPI.Entities;
using LHMSAPI.Helpers;
using LHMSAPI.Models;

namespace LHMSAPI.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private DatabaseContext _context;

        public UserService(DatabaseContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            User user = _context.Users.SingleOrDefault(x => x.username == username);

            if(user == null)
                return null;

            if(!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt))
                return null;

            return user;
        }

        public User Create(User user, string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            throw new AppException("Password is required");

            if(_context.Users.Any(x=>x.username == user.username))
                throw new AppException("Username \"" + user.username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            User user = _context.Users.Find(id);
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User userParam, string password = null)
        {
            User user = _context.Users.Find(userParam.id);

            if(user == null)
                throw new AppException("User not found");

            if(!string.IsNullOrWhiteSpace(userParam.username) && userParam.username != user.username)
            {
                if(_context.Users.Any(x => x.username == userParam.username))
                    throw new AppException("Username " + userParam.username + " is already taken");

                user.username = userParam.username;
            }

            if(!string.IsNullOrWhiteSpace(userParam.firstName))
                user.firstName = userParam.firstName;

            if(!string.IsNullOrWhiteSpace(userParam.lastName))
                user.lastName = userParam.lastName;

            if(!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.passwordHash = passwordHash;
                user.passwordSalt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if(password == null) throw new ArgumentNullException("password");
            if(string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if(password == null) throw new ArgumentNullException("password");
            if(string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if(storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if(storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (System.Security.Cryptography.HMACSHA512 hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i< computedHash.Length; i++)
                {
                    if(computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
    }
}