using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using LHMSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LHMSAPI.Repository
{
    public class SystemReportRepository
    {
        private readonly DatabaseContext _context;

        public SystemReportRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddSystemReport(SystemReport systemReport)
        {
            
        }

        void Delete(SystemReport item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SystemReport>> GetAll()
        {
            List<SystemReport> SystemReports = new List<SystemReport>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "SELECT * FROM public.\"SystemReports\";";
                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var rows = new SystemReport
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                ReportDate = reader.GetDateTime(2),
                                CreatedDate = reader.GetDateTime(3),
                                UpdatedDate = reader.GetDateTime(4),
                                SystemUpdate = reader.GetString(5),
                                PersonnelUpdates = reader.GetString(6),
                                CreativeIdeasAndEvaluations = reader.GetString(7),
                                BarriersOrChallenges = reader.GetString(8),
                                HowCanIHelpYou = reader.GetString(9),
                                PersonalGrowthAndDevelopment = reader.GetString(10),
                                Active = reader.GetBoolean(11)
                                //SystemReportStatus = (SystemStatus)reader.GetInt32(12),

                            };
                            SystemReports.Add(rows);
                        }

                    }
                    reader.Dispose();
                }
            }

            catch (System.Net.Sockets.SocketException ex)
            {
                Console.WriteLine(ex);
                //TODO: Updated this to return a 500 error rather than a 200. 
                //return "An error ocurred connecting with the database. Please contact an administrator."; 
            }

            finally
            {
                conn.Close();
            }
            return SystemReports;
        }

        public async Task<SystemReport> GetByID(int id)
        {
            SystemReport SystemReport = new SystemReport();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    string query = "SELECT * FROM public.\"SystemReports\" WHERE \"Id\" = " + id + " ;";
                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var systemReport = new SystemReport
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                ReportDate = reader.GetDateTime(2),
                                CreatedDate = reader.GetDateTime(3),
                                UpdatedDate = reader.GetDateTime(4),
                                SystemUpdate = reader.GetString(5),
                                PersonnelUpdates = reader.GetString(6),
                                CreativeIdeasAndEvaluations = reader.GetString(7),
                                BarriersOrChallenges = reader.GetString(8),
                                HowCanIHelpYou = reader.GetString(9),
                                PersonalGrowthAndDevelopment = reader.GetString(10),
                                Active = reader.GetBoolean(11)
                            };
                            SystemReport = systemReport;
                        }
                    }
                    reader.Dispose();
                }
            }

            catch (System.Net.Sockets.SocketException ex)
            {
                Console.WriteLine(ex);
                //TODO: Updated this to return a 500 error rather than a 200. 
                //return "An error ocurred connecting with the database. Please contact an administrator."; 
            }

            finally
            {
                conn.Close();
            }
            return SystemReport;
        }

        Task<bool> RemoveSystemReport(int id)
        {
            throw new NotImplementedException();
        }

        void Update(SystemReport item)
        {
            throw new NotImplementedException();
        }
    }
}