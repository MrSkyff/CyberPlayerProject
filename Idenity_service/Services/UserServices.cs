using Grpc.Core;
using Grpc.Net.Client;
using Idenity_service.Interfaces;
using Idenity_service.Models;
using Identity_service;
using System.Text.Json;

namespace Idenity_service.Services
{
    public class UserServices : Identity.IdentityBase
    {
        private readonly IUser userRepository;

        public UserServices(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public override async Task<UserProto> Login(LoginViewProto loginView, ServerCallContext serverCallContext)
        {
            LoginViewModel loginViewModel = JsonSerializer.Deserialize<LoginViewModel>(loginView.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            UserModel userModel = await userRepository.LoginAsync(loginViewModel);


            if (userModel == null)
            {
                UserProto userProto = default(UserProto)!;
                return await Task.FromResult(userProto);
            }
            else
            {
                UserProto userProto = new UserProto();
                userProto.Id = userModel.Id;
                userProto.UserName = userModel.UserName;
                userProto.FirstName = userModel.FirstName;
                userProto.LastName = userModel.LastName;
                userProto.Email = userModel.Email;
                userProto.EmailConfirmed = userModel.EmailConfirmed;
                
                return await Task.FromResult(userProto);
            }   
        }

    }
}
