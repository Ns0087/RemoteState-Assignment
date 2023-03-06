using AssignmentXML.Models.ResponseViewModels;
using AssignmentXML.Services.Implementations;
using AssignmentXML.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentXML.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IjsonService _jsonService;

        public AssignmentController(IServiceProvider serviceProvider)
        {
            _jsonService = serviceProvider.GetRequiredService<IjsonService>();
        }

        [HttpGet]
        public async Task<string> xmlToJson()
        {
            return await _jsonService.XmlToJson();
        }
    }
}
