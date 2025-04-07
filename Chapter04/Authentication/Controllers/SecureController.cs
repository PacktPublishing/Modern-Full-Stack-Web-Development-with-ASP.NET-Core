using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[Authorize]
public class SecureController : ControllerBase
{
    public IActionResult GetSecureData() => Ok("This is a secure endpoint and you have been authenticated.");
}
