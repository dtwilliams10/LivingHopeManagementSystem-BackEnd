using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace LHMSAPI.Models
{
    public class DatabaseContext : DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");

        public string GetDatabaseStatus()
        {
            string status = "";
            return status;
        }
    }
}