
using PicCard.Identity.Api.Services;

namespace PicCard.Identity.Api.Controllers;

[Route("Identity/")]
[ApiController]
public class IdentityController : Controller
{
    private const string StoreName = "identity_store";

    private readonly DaprClient _daprClient;
    private readonly IDateTimeProvider _dateTime;

    public IdentityController(DaprClient daprClient, IDateTimeProvider dateTime)
    {
        this._daprClient = daprClient;
        _dateTime = dateTime;
    }


    [HttpPost("/register")]
    public async Task<IActionResult> Register(RegisterDto model, CancellationToken token)
    {
        //TODO: validate model

        var existingUser = await _daprClient.GetStateAsync<Entities.Identity>(StoreName,
            model.Email.ToLower(),
            cancellationToken: token);

        if (existingUser is not null)
        {
            return BadRequest("User with this email already exists.");
        }

        var user = new Entities.Identity(model.Email, model.Password, new List<string> {"User"}, _dateTime.Now, null);

        await _daprClient.SaveStateAsync(StoreName, model.Email.ToLower(), user, cancellationToken: token);

        return Ok("User created successfully.");
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login(LoginDto model, CancellationToken token)
    {
        //TODO: validate model

        var existingUser = await _daprClient.GetStateAsync<Entities.Identity>(StoreName,
            model.Email.ToLower(),
            cancellationToken: token);

        if (existingUser is null)
        {
            return BadRequest("User not exists.");
        }

        if (existingUser.Password != model.Password)
        {
            return BadRequest("Password is not correct.");
        }

        existingUser = existingUser with {LastLogin = _dateTime.Now };
        await _daprClient.SaveStateAsync(StoreName, model.Email.ToLower(), existingUser, cancellationToken: token);

        return Ok("Logged in successfully.");
    }
}

public record RegisterDto(string Email, string Password, string RepeatPassword);

public record LoginDto(string Email, string Password);