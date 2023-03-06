using AssignmentXML.DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml;
using AssignmentXML.Services.Interfaces;
using AssignmentXML.Models.ResponseViewModels;
using Microsoft.Extensions.Primitives;

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

        public async Task<string> JsonResponse()
        {
            var json = await XmlToJson();

            if(json != null)
            {
                JsonModel jsonResponse = new JsonModel()
                {
                    TimeStamp = DateTime.Now,
                    Message = "success",
                    Code = "200",
                    Body = jsonSetter(json)
                };

                string jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(jsonResponse, Newtonsoft.Json.Formatting.Indented);

                return jsonSetter(json);
            }

            return null;
        }

        private static string jsonSetter(string json)
        {
            string result = null;
            if(json != null)
            {
                result = json.Replace("\"ADDITIONAL_FIELDS\"", "userDetails");
                result = result.Replace("ZPRDTYP", "ProductType");
                result = result.Replace("RSTERM", "RiskTerm");
                result = result.Replace("PMTERM", "PremiumTerm");
                result = result.Replace("PAYMMETH", "PaymentMethod");
                result = result.Replace("PAYFREQ", "PaymentFrequency");
                result = result.Replace("RCDDATE", "RiskCommencementDate");
                result = result.Replace("LASEX", "LifeAssuredGender");
                result = result.Replace("LADOB", "LifeAssuredDateOfBirth");
                result = result.Replace("LACRTBL", "LifeAssuredComponentCode");
                result = result.Replace("LAINSPR", "LifeAssuredInstallmentPremium");
            }

            return result;
        }
    }
}
