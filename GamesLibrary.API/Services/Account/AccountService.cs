using GamesLibrary.API.Entities;
using GamesLibrary.Shared.User;
using Microsoft.AspNetCore.Identity;

namespace GamesLibrary.API.Services.Account;

public class AccountService : IAccountService
{
    private readonly GamesDbContext dbContext;
    private readonly IPasswordHasher<User> passwordHasher;

    public AccountService(GamesDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        this.dbContext = dbContext;
        this.passwordHasher = passwordHasher;
    }


    public void RegisterUser(UserRegisterRequest registerUser)
    {
        var newUser = new User()
        {
            Name = registerUser.Name,
            Surname = registerUser.Surname,
            UserName = registerUser.Username,
            Email = registerUser.Email,
            DateOfBirth = registerUser.DateOfBirth,
            RoleId = 2
        };

        newUser.HashedPassword = passwordHasher.HashPassword(newUser, registerUser.Password);

        dbContext.Users.Add(newUser);
        dbContext.SaveChanges();
    }
}
