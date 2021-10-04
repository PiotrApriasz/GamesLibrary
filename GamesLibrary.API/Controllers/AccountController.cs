using GamesLibrary.API.Services.Account;
using GamesLibrary.Shared;
using GamesLibrary.Shared.User;
using Microsoft.AspNetCore.Mvc;

namespace GamesLibrary.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : Controller
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [HttpPost("register")]
    public ActionResult<BaseResponse> RegisterUser([FromBody]UserRegisterRequest registerUser)
    {
        accountService.RegisterUser(registerUser);
        return Ok(new BaseResponse()
        {
            Error = false,
            Message = "New account has been created successfully"
        });
    }
}

