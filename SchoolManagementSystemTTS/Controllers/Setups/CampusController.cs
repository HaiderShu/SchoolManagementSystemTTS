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
    public class CampusController : Controller
    {
		private TTS_SMSEntities db = new TTS_SMSEntities();
	
		// GET: Campus
		public ActionResult Campuslist()
		{
		
			return View(db.Campus_vw.ToList());
		}



		public ActionResult Addcampus()
		{
			ViewBag.Cityid = new SelectList(db.Cities, "Id", "Name");
			ViewBag.Countid = new SelectList(db.Countries, "Id", "Name");
			ViewBag.Instid = new SelectList(db.Institutions, "Instid", "Instdesc");
			ViewBag.Stateid = new SelectList(db.States, "Id", "Name");
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Addcampus(Campu campu)
		{
		
			campu.Addedby = User.Identity.GetUserId();
			campu.AddedDate = DateTime.Now;
			campu.ActvStatus = "A";
			db.Campus.Add(campu);
			db.SaveChanges();
			return RedirectToAction("Campuslist");
			
		}


		public ActionResult EditCampus(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Campu campu = db.Campus.Where(O => O.Campid == id).FirstOrDefault();
			if (campu == null)
			{
				return HttpNotFound();
			}
			ViewBag.Cityid = new SelectList(db.Cities, "Id", "Name", campu.Cityid);
			ViewBag.Countid = new SelectList(db.Countries, "Id", "Name", campu.Countid);
			ViewBag.Instid = new SelectList(db.Institutions, "Instid", "Instdesc", campu.Instid);
			ViewBag.Stateid = new SelectList(db.States, "Id", "Name", campu.Stateid);
			return View(campu);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditCampus(Campu campu)
		{
			//if (ModelState.IsValid)

			//{
			campu.Updatedt = DateTime.Now;
			campu.Updatedby = User.Identity.GetUserId();
			try
			{
				db.Entry(campu).State = EntityState.Modified;
				db.SaveChanges();
			 
			}
			catch (Exception ex)
			{
				 
			}
			ViewBag.Cityid = new SelectList(db.Cities, "Id", "Name", campu.Cityid);
			ViewBag.Countid = new SelectList(db.Countries, "Id", "Name", campu.Countid);
			ViewBag.Instid = new SelectList(db.Institutions, "Instid", "Instdesc", campu.Instid);
			ViewBag.Stateid = new SelectList(db.States, "Id", "Name", campu.Stateid);
			return RedirectToAction("Campuslist");
			//}
			
			//return View(campu);
		}

	}
}