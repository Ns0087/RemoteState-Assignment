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

            if (xml != null)
            {
                var doc = XDocument.Parse(xml);
                return JsonConvert.SerializeXNode(doc, Formatting.Indented);
            }

            return null;
        }

        public async Task<object> JsonSetter(string json)
        {
            if (json == null) return null;

            //var obj = JObject.Parse(json);

            var jObject = JsonConvert.DeserializeObject<Information>(json);


            return jObject;
        }

        //public async Task<string> JsonResponse()
        //{
        //    var json = await XmlToJson();

        //    if(json != null)
        //    {
        //        JsonModel jsonResponse = new JsonModel()
        //        {
        //            TimeStamp = DateTime.Now,
        //            Message = "success",
        //            Code = "200",
        //            Body = jsonSetter(json)
        //        };

        //        var jsonObject = JsonConvert.SerializeObject(jsonResponse, Formatting.Indented);

        //        return jsonObject;
        //    }

        //    return null;
        //}


        //private static Dictionary<string, string> Mappings()
        //{
        //    var mappings = new Dictionary<string, string>
        //    {
        //        { "ADDITIONAL_FIELDS", "userDetails" },
        //        { "ZPRDTYP", "ProductType" },
        //        { "RSTERM", "RiskTerm" },
        //        { "PMTERM", "PremiumTerm" },
        //        { "PAYMMETH", "PaymentMethod" },
        //        { "PAYFREQ", "PaymentFrequency" },
        //        { "RCDDATE", "RiskCommencementDate" },
        //        { "LASEX", "LifeAssuredGender" },
        //        { "LADOB", "LifeAssuredDateOfBirth" },
        //        { "LACRTBL", "LifeAssuredComponentCode" },
        //        { "LAINSPR", "LifeAssuredInstallmentPremium" },
        //    };

        //    return mappings;
        //}
    }
}
