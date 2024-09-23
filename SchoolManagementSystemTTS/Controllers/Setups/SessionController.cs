using Microsoft.AspNet.Identity;
using SchoolManagementSystemTTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SchoolManagementSystemTTS.Controllers.Setups
{
	public class SessionController : Controller
	{
		private TTS_SMSEntities db = new TTS_SMSEntities();
		// GET: FinancialYear
		public ActionResult SessionList()
		{

			return View(db.Session_vw.ToList());
		}

		public ActionResult CreateSession()
		{
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc");
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateSession( Session Fy)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Fy.ADDEDDATE = DateTime.Now;
					Fy.ADDEDBY = User.Identity.GetUserId();
					db.Sessions.Add(Fy);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					 
				}
				return RedirectToAction("SessionList");
			}
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc", Fy.CAMPID);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", Fy.INSTID);
			return View(Fy);
		}


		public ActionResult EditSession(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Session Fy = db.Sessions.Find(id);
			if (Fy == null)
			{
				return HttpNotFound();
			}
			ViewBag.CAMPID = new SelectList(db.Campus.Where(x => x.Instid == Fy.INSTID), "Campid", "Campdesc", Fy.CAMPID);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", Fy.INSTID);
			return View(Fy);
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditSession(Session Fy)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Fy.UPDATEDBY =  User.Identity.GetUserId();
					Fy.UPDATEDDT = DateTime.Now;
					
					db.Entry(Fy).State = EntityState.Modified;
					db.SaveChanges();
					 
				}
				catch (Exception ex)
				{
					return View(Fy);
				}

				return RedirectToAction("SessionList");
			}
			ViewBag.CAMPID = new SelectList(db.Campus.Where(x => x.Instid == Fy.INSTID), "Campid", "Campdesc", Fy.CAMPID);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", Fy.INSTID);
			return View(Fy);
		}



	}
}