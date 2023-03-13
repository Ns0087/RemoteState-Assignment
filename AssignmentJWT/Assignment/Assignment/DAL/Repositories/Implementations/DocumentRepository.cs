using Assignment.DAL.DBContext;
using Assignment.DAL.Entities;
using Assignment.Models.RequestViewModels;
using Microsoft.EntityFrameworkCore;
using PuppeteerSharp.Media;
using PuppeteerSharp;
using System.Text;
using Assignment.DAL.Repositories.Interfaces;


namespace Assignment.DAL.Repositories.Implementations
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public DocumentRepository(ApplicationDBContext serviceProvider)
        {
            _dBContext = serviceProvider;
        }

        public async Task<Document> GetDocumentByObjectCode(string objectCode)
        {
            var document = await _dBContext.Documents.FirstOrDefaultAsync(doc => doc.ObjectCode == objectCode && doc.IsDeleted == false);
            return document;
        }

        public async Task<int> AddDocument(Document document)
        {
            int result = 0;
            if (document != null)
            {
                try
                {
                    await _dBContext.Documents.AddAsync(document);
                    result = await _dBContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {

                    throw;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

            return result;
        }

        public async Task<int> SoftDeleteDocument(Document document)
        {
            int result = 0;
            try
            {
                if (document != null)
                {
                    document.IsDeleted = true;
                    result = await _dBContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return result;
        }
    }
}
