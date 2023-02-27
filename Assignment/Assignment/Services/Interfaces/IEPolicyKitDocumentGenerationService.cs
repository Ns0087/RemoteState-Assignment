using Assignment.Models.RequestViewModels;

namespace Assignment.Services.Interfaces
{
    public interface IEPolicyKitDocumentGenerationService
    {
        public Task<int> EPolicyKitDocumentGenerationServiceAsync(DetailsModel details);
    }
}
