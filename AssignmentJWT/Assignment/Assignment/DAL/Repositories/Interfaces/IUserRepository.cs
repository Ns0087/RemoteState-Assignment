using Assignment.Models.RequestViewModels;
using Assignment.DAL.Entities;

namespace Assignment.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUserByDetailsAsync(DetailsModel details);


    }
}
