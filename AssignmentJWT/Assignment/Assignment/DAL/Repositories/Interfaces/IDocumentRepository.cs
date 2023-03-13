using Assignment.DAL.Entities;

namespace Assignment.DAL.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        public Task<int> AddDocument(Document document);
        public Task<int> SoftDeleteDocument(Document document);
        public Task<Document> GetDocumentByObjectCode(string objectCode);


    }
}
