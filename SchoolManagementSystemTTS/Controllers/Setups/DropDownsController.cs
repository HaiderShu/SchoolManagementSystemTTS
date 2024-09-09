using SchoolManagementSystemTTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemTTS.Controllers.Setups
{
    public class DropDownsController : Controller
    {
		private TTS_SMSEntities db = new TTS_SMSEntities();
		// GET: DropDowns
		[HttpPost]
		public JsonResult GetCampus(int id)
		{

			var data = db.Campus.Where(x => x.Instid == id).ToList();
			var list = new SelectList(data, "Campid", "Campshortdesc");
			var dropdown = "<option value =''>-----Select-----</ option >";

			foreach (var item in data)
			{
				dropdown += "<option value='" + item.Campid + "'>" + @item.Campdesc + "</option>";
			}
			return Json(dropdown, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult GetClasses(int campus, int institiute)
		{
			var data = db.Classes.Where(x => x.INSTID == institiute).Where(x => x.CAMPID == campus).ToList();
			var list = new SelectList(data, "Campid", "Campshortdesc");


			var dropdown = "<option value =''> -----Select-----</ option >";

			foreach (var item in data)
			{
				dropdown += "<option value='" + item.Classid + "'>" + @item.Classdescription + "</option>";
			}
			return Json(dropdown, JsonRequestBehavior.AllowGet);
		}


		[HttpPost]
		public JsonResult Getprog(int campus, int institiute)
		{
			var data = db.Programs.Where(x => x.INSTID == institiute).Where(x => x.CAMPID == campus).ToList();
			var list = new SelectList(data, "Campid", "Campshortdesc");


			var dropdown = "<option value =''> -----Select-----</ option >";

			foreach (var item in data)
			{
				dropdown += "<option value='" + item.Progid + "'>" + @item.ProgDesc + "</option>";
			}
			return Json(dropdown, JsonRequestBehavior.AllowGet);
		}




		[HttpPost]
		public JsonResult GetFy(int campus, int institiute)
		{
			var data = db.FinancialYears.Where(x => x.INSTID == institiute).Where(x => x.CAMPID == campus).ToList();
			var list = new SelectList(data, "Campid", "Campshortdesc");


			var dropdown = "<option value =''> -----Select-----</ option >";

			foreach (var item in data)
			{
				dropdown += "<option value='" + item.FINCID + "'>" + @item.DESCRIPTION + "</option>";
			}
			return Json(dropdown, JsonRequestBehavior.AllowGet);
		}



		//[HttpPost]
		//public JsonResult GetSection(int campus, int institiute)
		//{
		//	var data = db.Sections.Where(x => x.INSTID == institiute).Where(x => x.CAMPID == campus).ToList();
		//	var list = new SelectList(data, "Campid", "Campshortdesc");


		//	var dropdown = "<option value =''> -----Select-----</ option >";

		//	foreach (var item in data)
		//	{
		//		dropdown += "<option value='" + item.SectionId + "'>" + @item.Section_name + "</option>";
		//	}
		//	return Json(dropdown, JsonRequestBehavior.AllowGet);
		//}

	}
}