using AssignmentXML.Models.ResponseViewModels;
using AssignmentXML.Services.Implementations;
using AssignmentXML.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AssignmentXML.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IJsonDeserializeService _jsonService;

        public AssignmentController(IServiceProvider serviceProvider)
        {
            _jsonService = serviceProvider.GetRequiredService<IJsonDeserializeService>();
        }

        [HttpGet]
        public async Task<object> xmlToJson()
        {
            var json = await _jsonService.XmlToJsonString();
            var responseBody = await _jsonService.JsonSetter(json);

            try
            {
                //return Ok(responseBody.Info);

                JsonModel jsonResponse = new JsonModel()
                {
                    TimeStamp = DateTime.Now,
                    Message = "success",
                    Code = "200",
                    Body = responseBody
                };

                //var jsonString = JsonConvert.SerializeObject(jsonResponse);
                //var response = JObject.Parse(jsonString);

                Console.WriteLine(jsonResponse.Body);

                return jsonResponse;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


    }
}
