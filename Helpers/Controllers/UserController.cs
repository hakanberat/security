using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("/submit")]
    public IActionResult Submit([FromForm] string username, [FromForm] string email)
    {
        var repo = new UserRepository();
        repo.AddUser(username, email);
        return Ok("User saved securely.");
    }
}
