using AssignmentXML.DAL.Entities;

namespace AssignmentXML.DAL.Repository.Interfaces
{
    public interface IXmlRepository
    {
        public Task<string> GetXmlByCode(string code);
    }
}
