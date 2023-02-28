using AssignmentXML.DAL.Entities;

namespace AssignmentXML.DAL.Repository.Interfaces
{
    public interface IXmlRepository
    {
        public Task<XmlTemplate> GetXmlByCode(string code);
    }
}
