using AssignmentXML.DAL.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml;

namespace AssignmentXML.Services.Implementations
{
    public class jsonService
    {
        private readonly IXmlRepository _repository;
        public jsonService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IXmlRepository>();
        }

        public static string XmlToJson(string xml)
        {
            xml = @"<Invoice>\r\n    <Timestamp>1/1/2017 00:01</Timestamp>\r\n    <CustNumber>12345</CustNumber>\r\n    <AcctNumber>54321</AcctNumber>\r\n</Invoice>\";
            var doc = XDocument.Parse(xml);
            return JsonConvert.SerializeXNode(doc);
        }
    }
}
