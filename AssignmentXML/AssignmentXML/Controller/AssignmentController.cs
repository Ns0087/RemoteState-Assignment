using AssignmentXML.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentXML.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly jsonService _jsonService;

        public AssignmentController(IServiceProvider serviceProvider)
        {
            _jsonService = serviceProvider.GetRequiredService<jsonService>();
        }

        [HttpGet]
        public string xmlToJson()
        {
            return _jsonService.XmlToJson();
        }
    }
}
