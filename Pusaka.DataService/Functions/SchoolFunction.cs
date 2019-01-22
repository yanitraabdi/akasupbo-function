using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Converters;
using Pusaka.DataService.Models;
using Pusaka.DataService.Interfaces;
using Pusaka.DataService.Containers;
using Pusaka.DataService.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host;

namespace Pusaka.DataService.Functions
{
    public static class SchoolFunction
    {
        /// <summary>
        /// Container Build
        /// </summary>
        private static Lazy<IServiceProvider> _container = new Lazy<IServiceProvider>(
            () => new ContainerBuilder()
                .RegisterModule(new AppCoreModule())
                .Build()
        );

        /// <summary>
        /// Container
        /// </summary>
        private static IServiceProvider Container
        {
            get
            {
                return _container.Value;
            }
        }

        [FunctionName("SchoolGet")]
        public static async Task<IActionResult> SchoolGet(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            var methodName = "SchoolGet";
            var processId = context.InvocationId.ToString();
            log.LogInformation($"C# HTTP trigger function processed a request on {processId} with command {req.Method}.");

            try
            {
                var parameter = new School();

                string requestBody = new StreamReader(req.Body).ReadToEnd();

                var converter = new ExpandoObjectConverter();
                parameter = JsonConvert.DeserializeObject<School>(requestBody, converter);

                var schoolServices = await Container.GetService<ISchoolService>().Initialize(log, Container).ConfigureAwait(false);

                var timer = Stopwatch.StartNew();
                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}");

                var result = await schoolServices.GetSchools(parameter);

                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}. Elapsed => {timer.Elapsed}");

                return (ActionResult)new OkObjectResult($"{JsonConvert.SerializeObject(result)}");
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex, $"{methodName} => {processId}");
                throw;
            }
        }

        [FunctionName("SchoolDetail")]
        public static async Task<IActionResult> SchoolDetail(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            var methodName = "SchoolDetail";
            var processId = context.InvocationId.ToString();
            log.LogInformation($"C# HTTP trigger function processed a request on {processId} with command {req.Method}.");

            try
            {
                var parameter = new School();

                string requestBody = new StreamReader(req.Body).ReadToEnd();

                var converter = new ExpandoObjectConverter();
                parameter = JsonConvert.DeserializeObject<School>(requestBody, converter);

                var schoolServices = await Container.GetService<ISchoolService>().Initialize(log, Container).ConfigureAwait(false);

                var timer = Stopwatch.StartNew();
                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}");

                var result = await schoolServices.GetSchoolDetail(parameter.SchoolID);

                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}. Elapsed => {timer.Elapsed}");

                return (ActionResult)new OkObjectResult($"{JsonConvert.SerializeObject(result)}");
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex, $"{methodName} => {processId}");
                throw;
            }
        }

        [FunctionName("SchoolInsert")]
        public static async Task<IActionResult> SchoolInsert(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            var methodName = "SchoolGet";
            var processId = context.InvocationId.ToString();
            log.LogInformation($"C# HTTP trigger function processed a request on {processId} with command {req.Method}.");

            try
            {
                var parameter = new School();

                string requestBody = new StreamReader(req.Body).ReadToEnd();

                var converter = new ExpandoObjectConverter();
                parameter = JsonConvert.DeserializeObject<School>(requestBody, converter);

                var schoolServices = await Container.GetService<ISchoolService>().Initialize(log, Container).ConfigureAwait(false);

                var timer = Stopwatch.StartNew();
                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}");

                var result = await schoolServices.InsertSchool(parameter);

                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}. Elapsed => {timer.Elapsed}");

                return (ActionResult)new OkObjectResult($"{JsonConvert.SerializeObject(result)}");
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex, $"{methodName} => {processId}");
                throw;
            }
        }

        [FunctionName("SchoolUpdate")]
        public static async Task<IActionResult> SchoolUpdate(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            var methodName = "SchoolGet";
            var processId = context.InvocationId.ToString();
            log.LogInformation($"C# HTTP trigger function processed a request on {processId} with command {req.Method}.");

            try
            {
                var parameter = new School();

                string requestBody = new StreamReader(req.Body).ReadToEnd();

                var converter = new ExpandoObjectConverter();
                parameter = JsonConvert.DeserializeObject<School>(requestBody, converter);

                var schoolServices = await Container.GetService<ISchoolService>().Initialize(log, Container).ConfigureAwait(false);

                var timer = Stopwatch.StartNew();
                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}");

                var result = await schoolServices.UpdateSchool(parameter.SchoolID, parameter);

                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}. Elapsed => {timer.Elapsed}");

                return (ActionResult)new OkObjectResult($"{JsonConvert.SerializeObject(result)}");
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex, $"{methodName} => {processId}");
                throw;
            }
        }

        [FunctionName("SchoolDelete")]
        public static async Task<IActionResult> SchoolDelete(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            var methodName = "SchoolGet";
            var processId = context.InvocationId.ToString();
            log.LogInformation($"C# HTTP trigger function processed a request on {processId} with command {req.Method}.");

            try
            {
                var parameter = new School();

                string requestBody = new StreamReader(req.Body).ReadToEnd();

                var converter = new ExpandoObjectConverter();
                parameter = JsonConvert.DeserializeObject<School>(requestBody, converter);

                var schoolServices = await Container.GetService<ISchoolService>().Initialize(log, Container).ConfigureAwait(false);

                var timer = Stopwatch.StartNew();
                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}");

                var result = await schoolServices.DeleteSchool(parameter.SchoolID);

                log.LogInformation($"Call {methodName} Service with params: {JsonConvert.SerializeObject(parameter)}. Elapsed => {timer.Elapsed}");

                return (ActionResult)new OkObjectResult($"{JsonConvert.SerializeObject(result)}");
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString(), ex, $"{methodName} => {processId}");
                throw;
            }
        }
    }
}
