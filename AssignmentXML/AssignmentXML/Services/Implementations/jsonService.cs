using AssignmentXML.DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json.Serialization;
using AssignmentXML.Services.Interfaces;
using AssignmentXML.Models.ResponseViewModels;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;

namespace AssignmentXML.Services.Implementations
{

    public class JsonDeserializeService : IJsonDeserializeService
    {
        private readonly IXmlRepository _repository;
        public JsonDeserializeService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IXmlRepository>();
        }

        public async Task<string> XmlToJsonString()
        {
            string xml = await _repository.GetXmlByCode("XML101");

            if (xml != null)
            {
                var doc = XDocument.Parse(xml);
                return JsonConvert.SerializeXNode(doc, Formatting.None , omitRootObject: true);
            }

            return null;
        }

        public async Task<User> JsonSetter(string json)
        {
            if (json == null) return null;

            //var obj = JObject.Parse(json);

            var jObject = JsonConvert.DeserializeObject<User>(json);

            return jObject;
        }

    }
}
