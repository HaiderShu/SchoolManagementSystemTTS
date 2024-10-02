using Microsoft.AspNet.Identity;
using SchoolManagementSystemTTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemTTS.Controllers.Finance
{
    public class AccountHeadController : Controller
    {
		TTS_SMSEntities db = new TTS_SMSEntities();
		// GET: AccountHead




		public ActionResult AccountHeadlist()
        {
            return View();
        }
		
		
		public ActionResult AddAccountHead()
        {
            return View();
        }

        [HttpPost]
		public ActionResult AddAccountHead(Account_Head Acc)
		{
			if (ModelState.IsValid)
			{
				try
				{
					Acc.ADDEDDATE = DateTime.Now;
					Acc.ADDEDBY = User.Identity.GetUserId();
					Acc.Status = 1;
					db.Account_Head.Add(Acc);
					db.SaveChanges();
					TempData["success"] = "Inserted Successfully";
					return RedirectToAction("AccountHeadlist");
				}
				catch (Exception ex)
				{
					TempData["failed"] = "Inserted Failed";
					return View(Acc);
				}
			}
			
			return View(Acc);
		}



		[HttpGet]
		public ActionResult EditAccountHead(int id)
		{
			var model = db.Account_Head.Find(id);
			return View(model);
		}



		[HttpPost]
		public ActionResult EditAccountHead(Account_Head acc)
		{
			if (ModelState.IsValid)
			{
				try
				{
					acc.UPDATEDBY = User.Identity.GetUserId();
					acc.UPDATEDATE = DateTime.Now;

					db.Entry(acc).State = EntityState.Modified;
					db.SaveChanges();
					TempData["success"] = "Updated Successfully";

				}
				catch (Exception ex)
				{
					TempData["failed"] = "Updation Failed";
					return View(acc);
				}
			}
			return View(acc);
		}






	}
}