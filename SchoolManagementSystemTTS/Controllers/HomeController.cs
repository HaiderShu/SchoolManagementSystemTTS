using SchoolManagementSystemTTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemTTS.Controllers
{

	public class HomeController : Controller
	{
		private TTS_SMSEntities db = new TTS_SMSEntities();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[HttpPost]
		public ActionResult GetStateList(int country)
		{
			List<State> statelist = db.States.Where(x => x.CountryId == country).ToList();
			ViewBag.Slist = new SelectList(statelist, "Id", "Name");
			return PartialView("FetchState");
		}


		[HttpPost]
		public ActionResult GetCityList(int state)
		{
			List<City> citylist = db.Cities.Where(x => x.StateId == state).ToList();
			ViewBag.Citylist = new SelectList(citylist, "Id", " Name");
			return PartialView("FetchCity");
		}
	}
}