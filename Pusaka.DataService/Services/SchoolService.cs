using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pusaka.DataService.Constants;
using Pusaka.DataService.Contexts;
using Pusaka.DataService.Interfaces;
using Pusaka.DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusaka.DataService.Services
{
    public class SchoolService : ISchoolService
    {
        public IConfiguration _config { get; set; }
        public ILogger _log { get; set; }
        public IServiceProvider _container { get; set; }
        public string _connectionString { get; set; }
        public PusakaContext _pusakaContext { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SchoolService(IConfiguration config, PusakaContext pusakaContext)
        {
            _config = config;
            _pusakaContext = pusakaContext;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<ISchoolService> Initialize(ILogger log, IServiceProvider container)
        {
            _log = log;
            _container = container;

            _connectionString = _config.GetConnectionString(ApplicationConfiguration.PusakaConnectionString);

            return await Task.FromResult(this);
        }

        /// <summary>
        /// Service - METHOD : GET School List
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// 
        public async Task<ICollection<School>> GetSchools(School parameter)
        {
            var result = await _pusakaContext.Schools
                .OrderBy(s => s.SchoolID)
                .Where(s => s.SchoolStatus == 1)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// Service - METHOD : GET School Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        public async Task<School> GetSchoolDetail(long id)
        {
            var result = await _pusakaContext.Schools
                .Where(s => s.SchoolStatus == 1 && s.SchoolID == id)
                .OrderBy(s => s.SchoolID)
                .SingleOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// 
        public async Task<School> InsertSchool(School parameter)
        {
            var result = new School();
            try
            {
                _log.LogInformation("INSERT School -- Executed");

                _pusakaContext.Schools.Add(parameter);
                await _pusakaContext.SaveChangesAsync();

                result = await _pusakaContext.Schools.LastOrDefaultAsync();

                _log.LogInformation("INSERT School -- Done");
            }
            catch (Exception ex)
            {
                _log.LogError("INSERT School - Error", ex);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// 
        public async Task<School> UpdateSchool(long id, School parameter)
        {
            var result = new School();
            try
            {
                _log.LogInformation("UPDATE School -- Executed");

                var existingEntity = _pusakaContext.Schools.FirstOrDefault(s => s.SchoolID == id);
                if (existingEntity != null)
                {
                    var entity = _pusakaContext.Set<School>().SingleOrDefault(s => s.SchoolID == id);
                    entity.SchoolType = parameter.SchoolType;
                    entity.SchoolStatus = parameter.SchoolStatus;
                    entity.ModifiedAt = DateTime.UtcNow;
                    entity.ModifiedBy = parameter.ModifiedBy;
                }

                await _pusakaContext.SaveChangesAsync();

                _log.LogInformation("UPDATE School -- Done");
            }
            catch (Exception ex)
            {
                _log.LogError("UPDATE School - Error", ex);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// 
        public async Task<School> DeleteSchool(long id)
        {
            var result = new School();
            try
            {
                _log.LogInformation("DELETE School -- Executed");

                var existingEntity = _pusakaContext.Schools.FirstOrDefault(s => s.SchoolID == id);
                if (existingEntity != null)
                {
                    var entity = _pusakaContext.Set<School>().SingleOrDefault(s => s.SchoolID == id);
                    entity.SchoolStatus = 2;
                    entity.ModifiedAt = DateTime.UtcNow;
                    // entity.ModifiedBy = parameter.ModifiedBy;
                }

                await _pusakaContext.SaveChangesAsync();

                _log.LogInformation("DELETE School -- Done");
            }
            catch (Exception ex)
            {
                _log.LogError("DELETE School - Error", ex);
            }

            return result;
        }
    }
}
