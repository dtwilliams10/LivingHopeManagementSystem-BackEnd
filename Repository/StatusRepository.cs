using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using LHMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using LHMSAPI.Helpers;

namespace LHMSAPI.Repository
{
    public class StatusRepository
    {
        private readonly DatabaseContext _context;

        public StatusRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<string> GetDatabaseStatus()
        {
            List<string> status = new List<string>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using(var command = conn.CreateCommand())
                {
                    string query = "SELECT version();";
                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if(reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                        var rows = new Status {status = reader.GetString(0)};
                        status.Add(rows.status);
                        }
                    }
                    reader.Dispose();
                }
            }

            catch(System.Net.Sockets.SocketException ex)
            {
             Console.WriteLine(ex);
             //TODO: Updated this to return a 500 error rather than a 200.
             return "An error ocurred connecting with the database. Please contact an administrator.";
            }

            finally
            {
                conn.Close();
            }
            return status[0];
        }
    }
}
