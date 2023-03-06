using AssignmentXML.Models.ResponseViewModels;

namespace AssignmentXML.Services.Interfaces
{
    public interface IjsonService
    {
        public Task<string> XmlToJson();
        public Task<string> JsonResponse();


    }
}
