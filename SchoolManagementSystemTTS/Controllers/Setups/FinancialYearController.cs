using Microsoft.AspNet.Identity;
using SchoolManagementSystemTTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SchoolManagementSystemTTS.Controllers.Setups
{
	public class FinancialYearController : Controller
	{
		private TTS_SMSEntities db = new TTS_SMSEntities();
		// GET: FinancialYear
		public ActionResult FYList()
		{

			return View(db.Financial_vw.ToList());
		}

		public ActionResult CreateFY()
		{
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc");
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateFY( FinancialYear Fy)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Fy.ADDEDDATE = DateTime.Now;
					Fy.ADDEDBY = User.Identity.GetUserId();
					db.FinancialYears.Add(Fy);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					 
				}
				return RedirectToAction("FYList");
			}
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc", Fy.CAMPID);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", Fy.INSTID);
			return View(Fy);
		}


		public ActionResult EditFY(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			FinancialYear Fy = db.FinancialYears.Find(id);
			if (Fy == null)
			{
				return HttpNotFound();
			}
			ViewBag.CAMPID = new SelectList(db.Campus.Where(x => x.Instid == Fy.INSTID), "Campid", "Campdesc", Fy.CAMPID);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", Fy.INSTID);
			return View(Fy);
		}




	}
}