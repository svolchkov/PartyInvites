using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
		//public string Index()
		//{
		//    return "Hello World";
		//}
		public ViewResult Index()
		{
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour > 12 ? "Good afternoon" : "Good morning";
			return View("MyView");
		}

        [HttpGet]
        public ViewResult RSVPResponse()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RSVPResponse(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
