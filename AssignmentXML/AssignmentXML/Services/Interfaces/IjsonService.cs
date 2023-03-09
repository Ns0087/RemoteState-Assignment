using AssignmentXML.Models.ResponseViewModels;

namespace AssignmentXML.Services.Interfaces
{
    public interface IJsonDeserializeService
    {
        public Task<string> XmlToJsonString();

        public Task<User> JsonSetter(string json);
    }
}
