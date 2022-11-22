using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Spikes.AspNetCore.ODataRouting.Constants;
using Spikes.AspNetCore.ODataRouting.Models.ModuleBase;

namespace Spikes.AspNetCore.ODataRouting.Controllers.PluginA.REST
{
    /// <summary>
    /// Example of Standard non-ODATA
    /// Controller.
    /// </summary>
    /// <remarks>
    /// Sexy description of the Controller
    /// <code>
    /// <![CDATA[
    /// var foo = bar;
    /// ]]>
    /// </code>
    /// </remarks>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Some more descriptive text...
        /// </summary>
        /// <remarks>
        /// Sexy description of the Controller:
        /// <para>
        /// <code>
        /// <![CDATA[
        /// var foo = bar;
        /// ]]>
        /// </code>
        /// </para>
        /// </remarks>
        /// <returns></returns>
        /// <devnotes>
        /// By default Comments On Controllers are NOT
        /// included by Swashbuckle. unless you follw:
        /// https://stackoverflow.com/questions/50511071/how-to-define-controller-descriptions-in-asp-net-core-swagger-swashbuckle-aspne
        /// </devnotes>
        [EnableQuery(PageSize = 100)]
        [HttpGet(Name = "GetWeatherForecast")]
        [ApiExplorerSettings(GroupName = AppAPIConstants.OpenAPI.Generation.Areas.ModuleA.Rest.ID)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}