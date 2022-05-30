using Microsoft.AspNetCore.Mvc;

namespace GetStartedASPNET.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string H(string? mode, double? x, double? y)
        {
            Func<int, string> t = x => x.ToString();

            if (mode == null || x == null || y == null) return "Brtuh";

            #pragma warning disable CS8601 // Possible null reference assignment.
            Dictionary<string, string> results = new Dictionary<string, string>
            {
                ["add"] = (x + y).ToString(),
                ["sub"] = (x - y).ToString(),
                ["mul"] = (x * y).ToString(),
                ["div"] = (x / y).ToString(),
                ["mod"] = (x % y).ToString(),
            };
            #pragma warning restore CS8601 // Possible null reference assignment.

            return results[mode];
        }
    }
}
