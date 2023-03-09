using AssignmentXML.Models.ResponseViewModels;
using AssignmentXML.Services.Implementations;
using AssignmentXML.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var json = await _jsonService.XmlToJson();
            var responseBody = await _jsonService.JsonSetter(json);
            try
            {
                JsonModel jsonResponse = new JsonModel()
                {
                    TimeStamp = DateTime.Now,
                    Message = "success",
                    Code = "200",
                    Body = responseBody
                };

                var jsonObject = JsonConvert.SerializeObject(jsonResponse, Formatting.Indented);

                return jsonObject;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


    }
}
