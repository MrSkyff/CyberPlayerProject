using Idenity_service.Models;

namespace Idenity_service.Interfaces
{
    public interface IUser
    {
        Task<UserModel> LoginAsync(LoginViewModel viewModel);
    }
}
