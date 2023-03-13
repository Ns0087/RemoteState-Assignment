using Assignment.Models.RequestViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using Assignment.Services.Implementations;
using Assignment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IEPolicyKitDocumentGenerationService _services;

        public AssignmentController(IServiceProvider serviceProvider)
        {
            _services = serviceProvider.GetRequiredService<IEPolicyKitDocumentGenerationService>();
        }

        // POST api/<AssignmentController>
        [HttpPost]
        public async Task<string> Post(DetailsModel details)
        {
            if (await _services.EPolicyKitDocumentGenerationServiceAsync(details) > 0)
                return "Success";
            else
                return "Please try again later!!";
        }
    }
}
