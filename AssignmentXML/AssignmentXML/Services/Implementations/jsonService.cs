﻿using AssignmentXML.DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml;
using AssignmentXML.Services.Interfaces;
using AssignmentXML.Models.ResponseViewModels;

namespace AssignmentXML.Services.Implementations
{
    public class jsonService : IjsonService
    {
        private readonly IXmlRepository _repository;
        public jsonService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IXmlRepository>();
        }

        public async Task<string> XmlToJson()
        {
            string xml = await _repository.GetXmlByCode("XML101");

            if(xml != null)
            {
                var doc = XDocument.Parse(xml);
                return JsonConvert.SerializeXNode(doc, Newtonsoft.Json.Formatting.Indented, omitRootObject: true);
            }

            return null;
        }

        public async Task<JsonModel> JsonResponse()
        {
            var json = XmlToJson();

            if(json != null)
            {
                JsonModel jsonResponse = new JsonModel()
                {
                    TimeStamp = DateTime.Now,
                    Message = "success",
                    Code = "200",
                    Body = ""
                };

                return jsonResponse;
            }

            return new JsonModel();
        }


    }
}
