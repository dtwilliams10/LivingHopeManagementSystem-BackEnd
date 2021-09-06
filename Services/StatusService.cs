using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LHMSAPI.Helpers;
using WebApi.Entities;

namespace LHMSAPI.Services
{
    public interface IStatusService
    {
        Task<string> getDatabaseStatus();
    }

    public class StatusService : IStatusService
    {
        private readonly DatabaseContext _context;

        public StatusService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<string> getDatabaseStatus()
        {
            List<string> status = new List<string>();
            DbConnection conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using DbCommand command = conn.CreateCommand();
                string query = "SELECT version();";
                command.CommandText = query;
                DbDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        Status rows = new Status { status = reader.GetString(0) };
                        status.Add(rows.status);
                    }
                }
                reader.Dispose();
            }

            catch(System.Net.Sockets.SocketException ex)
            {
                Console.WriteLine(ex);
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