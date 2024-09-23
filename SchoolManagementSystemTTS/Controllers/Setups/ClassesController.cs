using SchoolManagementSystemTTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SchoolManagementSystemTTS.Controllers.Setups
{
    public class ClassesController : Controller
    {
		private TTS_SMSEntities db = new TTS_SMSEntities();
		// GET: Classes
		public ActionResult ClassesList()
		{
		 
			return View(db.Class_vw.ToList());
		}

		public ActionResult AddClasses()
		{
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc");
			ViewBag.Progid = new SelectList(db.Programs, "Progid", "ProgDesc");
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddClasses(Class model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					model.ActvStatus = "1";
					model.AddedDate = DateTime.Now;
					db.Classes.Add(model);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					return RedirectToAction("AddClasses");
					
				}
				return RedirectToAction("ClassesList");
			}
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc", model.CAMPID);
			ViewBag.Progid = new SelectList(db.Programs, "Progid", "ProgDesc", model.Progid);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", model.INSTID);
			return View(model);
		}



		public ActionResult EditClasses(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Class @class = db.Classes.Find(id);
			if (@class == null)
			{
				return HttpNotFound();
			}
			ViewBag.CAMPID = new SelectList(db.Campus.Where(x => x.Instid == @class.INSTID), "Campid", "Campdesc", @class.CAMPID);
			ViewBag.Progid = new SelectList(db.Programs.Where(x => x.INSTID == @class.INSTID && x.CAMPID == @class.CAMPID), "Progid", "ProgDesc", @class.Progid);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", @class.INSTID);
			return View(@class);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditClasses(Class @class)
		{
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc", @class.CAMPID);
			ViewBag.Progid = new SelectList(db.Programs, "Progid", "ProgDesc", @class.Progid);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", @class.INSTID);
			if (ModelState.IsValid)
			{
				try
				{
					db.Entry(@class).State = EntityState.Modified;
					db.SaveChanges();
				 
				}
				catch (Exception ex)
				{
					 
				}
			 
			}
		
			return View(@class);
		}




	}
}