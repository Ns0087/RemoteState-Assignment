﻿using AssignmentXML.DAL.DBContext;
using AssignmentXML.DAL.Entities;
using AssignmentXML.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssignmentXML.DAL.Repository.Implementations
{
    public class XmlRepository : IXmlRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public XmlRepository(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        }
        public async Task<XmlTemplate> GetXmlByCode(string code)
        {
            var template = await _dbContext.Templates.FirstOrDefaultAsync(tmp => tmp.Code == code);
            return template;
        }
    }
}
