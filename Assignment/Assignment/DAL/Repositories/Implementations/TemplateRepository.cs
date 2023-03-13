using Assignment.DAL.DBContext;
using Assignment.DAL.Entities;
using Assignment.Models.RequestViewModels;
using Microsoft.EntityFrameworkCore;
using PuppeteerSharp.Media;
using PuppeteerSharp;
using System.Text;
using Assignment.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.DAL.Repositories.Implementations
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public TemplateRepository(ApplicationDBContext serviceProvider)
        {
            _dBContext = serviceProvider;
        }

        public async Task<IEnumerable<HtmlTemplate>> GetAllTemplatesAsync()
        {
            var list = await _dBContext.Templates.ToListAsync();
            return list;
        }

        public async Task<HtmlTemplate> GetHtmlTemplateByCreatedUserAsync(string createdUser)
        {
            var template = await _dBContext.Templates.FirstOrDefaultAsync(tmp => tmp.CreatedUser == createdUser);
            return template;
        }


    }
}
