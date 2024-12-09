using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ChatController : Controller
{
    public IActionResult Chat()
    {
        return View();
    }
}
