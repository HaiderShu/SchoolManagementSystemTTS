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
    public class InstituteController : Controller
    {
		private TTS_SMSEntities db = new TTS_SMSEntities();

		// GET: Institute
		public ActionResult InstituteList()
        {
            var data = db.Institution_vw.ToList();
            return View(data);
        }
        
        public ActionResult Createinstitute()
        {
			ViewBag.Cityid = new SelectList(db.Cities, "Id", "Name");
			ViewBag.Countid = new SelectList(db.Countries, "Id", "Name");
			ViewBag.Stateid = new SelectList(db.States, "Id", "Name");
			return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Createinstitute(Institution institution)
		{
		 
			try
			{
				institution.Addedby = User.Identity.GetUserId();
				institution.AddedDate = DateTime.Now;
				db.Institutions.Add(institution);
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				 
			}

			return RedirectToAction("InstituteList");
		 
		}

		public ActionResult EditInstitute(int? id)
		{
			Institution institution = db.Institutions.Where(o => o.Instid == id).FirstOrDefault();
			if (institution == null)
			{
				return HttpNotFound();
			}
			ViewBag.Cityid = new SelectList(db.Cities, "Id", "Name", institution.Cityid);
			ViewBag.Countid = new SelectList(db.Countries, "Id", "Name", institution.Countid);
			ViewBag.Stateid = new SelectList(db.States, "Id", "Name", institution.Stateid);
			return View(institution);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditInstitute( Institution institution)
		{
			//if (ModelState.IsValid)
			//{
			try
			{
				institution.Updatedt = DateTime.Now;
				institution.Updatedby = User.Identity.GetUserId();
				db.Entry(institution).State = EntityState.Modified;
				db.SaveChanges();
				 
			}
			catch (Exception ex)
			{ 
			};
			//}
			//ViewBag.Cityid = new SelectList(db.Cities, "Id", "Name", institution.Cityid);
			//ViewBag.Countid = new SelectList(db.Countries, "Id", "Name", institution.Countid);
			//ViewBag.Stateid = new SelectList(db.States, "Id", "Name", institution.Stateid);
			//return View(institution);
			return RedirectToAction("InstituteList");
		}


	}
}