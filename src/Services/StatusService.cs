using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Models;

namespace LHMS.SystemReports.Services
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
                command.CommandText = "SELECT version()";
                DbDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        StatusResponse rows = new() { status = reader.GetString(0) };
                        status.Add(rows.status);
                    }
                }
                reader.Dispose();
            }

            catch (System.Net.Sockets.SocketException Ex)
            {
                Serilog.Log.Error(Ex, "An error ocurred connecting with the database: {Ex}");
                return Ex.Message.ToString();
            }

            finally
            {
                conn.Close();
            }
            return status[0];
        }
    }
}