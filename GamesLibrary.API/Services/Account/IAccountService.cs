using GamesLibrary.Shared.User;

namespace GamesLibrary.API.Services.Account
{
    public interface IAccountService
    {
        void RegisterUser(UserRegisterRequest registerUser);
    }
}