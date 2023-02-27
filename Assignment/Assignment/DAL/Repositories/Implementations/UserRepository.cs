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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dBContext;

        public UserRepository(ApplicationDBContext serviceProvider)
        {
            _dBContext = serviceProvider;
        }

        public async Task<User> GetUserByDetailsAsync(DetailsModel details)
        {
            var user = await _dBContext.Users.FirstOrDefaultAsync(user => user.ProductCode == details.ProductCode && user.PolicyNumber == details.PolicyNumber);
            return user;

        }

    }
}
