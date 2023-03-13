using Assignment.DAL.Entities;

namespace Assignment.DAL.Repositories.Interfaces
{
    public interface ITemplateRepository
    {
        public Task<IEnumerable<HtmlTemplate>> GetAllTemplatesAsync();
        public Task<HtmlTemplate> GetHtmlTemplateByCreatedUserAsync(string createdUser);

    }
}
