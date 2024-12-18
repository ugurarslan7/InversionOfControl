using Microsoft.AspNetCore.Mvc;
using UdemyIOC.Web.Models;

namespace InversionOfControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingletonDateService _singletonDateService;

        private readonly IScopedDateService _scopedDateService;

        private readonly ITransientDateservice _transientDateservice;

        public HomeController(ITransientDateservice transientDateservice, ISingletonDateService singletonDateService, IScopedDateService scopedDateService)
        {
            _transientDateservice = transientDateservice;
            _singletonDateService = singletonDateService;
            _scopedDateService = scopedDateService;
        }

        public IActionResult Index([FromServices] ITransientDateservice transientDateservice2,
            [FromServices] IScopedDateService scopedDateService2,
            [FromServices] ISingletonDateService singletonDateService2)
        {
            ViewBag.timeSingle1 = _singletonDateService.GetDateTime.TimeOfDay.ToString();

            ViewBag.timeSingle2 = singletonDateService2.GetDateTime.TimeOfDay.ToString();

            ViewBag.timeScoped1 = _scopedDateService.GetDateTime.TimeOfDay.ToString();

            ViewBag.timeScoped2 = scopedDateService2.GetDateTime.TimeOfDay.ToString();

            ViewBag.timeT1 = _transientDateservice.GetDateTime.TimeOfDay.ToString();

            ViewBag.timeT2 = transientDateservice2.GetDateTime.TimeOfDay.ToString();
            return View();
        }
    }
}
