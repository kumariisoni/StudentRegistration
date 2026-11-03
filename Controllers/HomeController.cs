using Microsoft.AspNetCore.Mvc;

namespace StudentRegistration.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    public IActionResult Error() => View();
}
