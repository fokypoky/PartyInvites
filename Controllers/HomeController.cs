using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult RspvForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RspvForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                // TODO: сохранить ответ от гостя
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }

            return View();
        }

        public ViewResult ListResponses() => View(Repository.Responses.Where(r => r.WillAttend == true));
    }
}

