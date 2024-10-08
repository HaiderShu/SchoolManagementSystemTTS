﻿using Microsoft.AspNet.Identity;
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
    public class ProgramsController : Controller
    {
		private TTS_SMSEntities db = new TTS_SMSEntities();
		// GET: Programs
		public ActionResult ProgramList()
		{
			var data = db.Program_vw.ToList();

			return View(data);
		}

		public ActionResult Addprogram()
		{
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc");
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Addprogram(Program program)
		{
			if (ModelState.IsValid)
			{
				program.Addedby = User.Identity.GetUserId();
				program.AddedDate = DateTime.Now;
				try
				{
					program.ActvStatus = "1";
					program.AddedDate = DateTime.Now;
					db.Programs.Add(program);
					db.SaveChanges();
					return RedirectToAction("ProgramList");
				}
				catch (Exception ex)
				{
				 
				}
				
			}

			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc", program.CAMPID);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", program.INSTID);
			return View(program);
		}


		public ActionResult EditProgram(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var program = db.Programs.Find(id);
			if (program == null)
			{
				return HttpNotFound();
			}
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc", program.CAMPID);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", program.INSTID);
			return View(program);
		}


		[HttpPost]
		public ActionResult EditProgram(Program program)
		{
			try
			{
				db.Entry(program).State = EntityState.Modified;
				db.SaveChanges();
				 
			}
			catch (Exception ex)
			{
				return View(program);
			}
			ViewBag.CAMPID = new SelectList(db.Campus, "Campid", "Campdesc", program.CAMPID);
			ViewBag.INSTID = new SelectList(db.Institutions, "Instid", "Instdesc", program.INSTID);
			return RedirectToAction("ProgramList");
		}


	}
}