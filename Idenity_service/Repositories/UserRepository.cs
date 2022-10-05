using Idenity_service.Data;
using Idenity_service.Interfaces;
using Idenity_service.Models;
using Microsoft.EntityFrameworkCore;

namespace Idenity_service.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ServiceDbContext dbContext;

        public UserRepository(ServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserModel> LoginAsync(LoginViewModel viewModel)
        {

            var v = viewModel.Email;

            var d = v;

            var result = await dbContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(viewModel.Email.ToLower()));
            return result;
        }
    }
}
