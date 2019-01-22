using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Pusaka.DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pusaka.DataService.Interfaces
{
    public interface ISchoolService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        Task<ISchoolService> Initialize(ILogger log, IServiceProvider container);

        /// <summary>
        /// Interface - METHOD : GET School List
        /// </summary>
        /// <param name="log"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        Task<ICollection<School>> GetSchools(School parameter);

        /// <summary>
        /// Interface - METHOD : GET School Detail
        /// </summary>
        /// <param name="log"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        Task<School> GetSchoolDetail(long id);

        /// <summary>
        /// Interface - METHOD : POST School 
        /// </summary>
        /// <param name="School">School Body</param>
        /// <returns></returns>
        Task<School> InsertSchool(School parameter);

        /// <summary>
        /// Interface - METHOD : PUT School 
        /// </summary>
        /// <param name="id">School Id</param>
        /// <param name="school">School Body</param>
        /// <returns></returns>
        Task<School> UpdateSchool(long id, School parameter);

        /// <summary>
        /// Interface - METHOD : DELETE School 
        /// </summary>
        /// <param name="id">School Id</param>
        /// <returns></returns>
        Task<School> DeleteSchool(long id);
    }
}
