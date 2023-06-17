using LHMS.SystemReports.Helpers;
using LHMS.SystemReports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LHMS.SystemReports.Services
{
    public interface ISystemNameService
    {
        Task<List<SystemName>> GetAllSystemNames();
        Task<SystemName> GetSystemNameById(int Id);
    }

    public class SystemNameService : ISystemNameService
    {
        private readonly DatabaseContext _context;

        public SystemNameService(DatabaseContext context)
        {
            _context = context;
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<List<SystemName>> GetAllSystemNames()
        {
            try
            {
                return await _context.SystemNames.AsQueryable<SystemName>().ToListAsync();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error("Error in System Name Service: {@ex}", ex);
                throw new AppException();
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<SystemName> GetSystemNameById(int Id)
        {
            return await _context.SystemNames.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}