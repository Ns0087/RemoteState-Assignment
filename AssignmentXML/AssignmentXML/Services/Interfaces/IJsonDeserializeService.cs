using AssignmentXML.Models.ResponseViewModels;

namespace AssignmentXML.Services.Interfaces
{
    public interface IJsonDeserializeService
    {
        public Task<string> XmlToJsonStringAsync();

        public Task<User> JsonSetterAsync(string json);
    }
}
