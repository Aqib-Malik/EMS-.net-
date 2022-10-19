using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EMS.filtration
{
    [Route("filter")]
    public class MoviesController : Controller
    {
        private readonly IActionResult service;

        public MoviesController(IActionResult service)
        {
            this.service = service;
        }

        [HttpGet(Name = "GetMovies")]
        public IActionResult Get(FilteringParams filteringParams)
        {
            var model = service.Getemp(filteringParams);

            var outputModel = new empOutputModel
            {
                Count = model.Count,
                Items = model.Select(m => ToempInfo(m)).ToList(),
            };
            return Ok(outputModel);
        }
    }
}
