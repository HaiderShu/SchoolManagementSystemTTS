using Microsoft.AspNet.Identity;
using SchoolManagementSystemTTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemTTS.Controllers
{
    public class AdmissionController : Controller
    {
		private TTS_SMSEntities db = new TTS_SMSEntities();
		// GET: Admission
		public ActionResult AdmissionList()
        {
            return View(db.Admission_vw.ToList());
        }
				public ActionResult AdmissionForm()
        {
            return View();
        }

        [HttpPost]
		public ActionResult AdmissionForm(Admission_mst adm, HttpPostedFileBase file)
		{
			string path;
			Random r = new Random();
			if (ModelState.IsValid)
			{
				if(file != null) {
					 path = uploadimgfile(file, r.Next().ToString(), "~/assets/StudentImage/", 5000);
				}
				else
				{
					path = "~/assets/StudentImage/no-image.jpg";
				}
				int maxAdmsId = db.Admission_mst.Select(x => x.Adms_ID).DefaultIfEmpty(0).Max();
				Admission_mst admst = new Admission_mst();
				admst.Adms_ID = 1+maxAdmsId;
				admst.INSTID = adm.INSTID;
				admst.CAMPID = adm.CAMPID;
				admst.FORM_NO = adm.FORM_NO;
				admst.SESSION_YEAR = adm.SESSION_YEAR;
				admst.SUBMITTED_DT = DateTime.Now;
				admst.FIRST_NAME = adm.FIRST_NAME;
				admst.MIDDLE_NAME = adm.MIDDLE_NAME;
				admst.LAST_NAME = adm.LAST_NAME;
				admst.DATE_OF_BIRTH = adm.DATE_OF_BIRTH;
				admst.RELIGION = adm.RELIGION;
				admst.OCCUPATION = adm.OCCUPATION;
				admst.DOMICILE = adm.DOMICILE;
				admst.GENDER = adm.GENDER;
				admst.IDENTIFICATION_MARK = adm.IDENTIFICATION_MARK;
				admst.USER_IMG = path;
				admst.ACAD_STATUS = adm.ACAD_STATUS;
				admst.ADDRESS1 = adm.ADDRESS1;
				admst.Cityid = adm.Cityid;
				admst.Countid = adm.Countid;
				admst.Stateid = adm.Stateid;
				admst.FTHR_FNAME = adm.FTHR_FNAME;
				admst.FTHR_MNAME = adm.FTHR_MNAME;
				admst.FTHR_LNAME = adm.FTHR_LNAME;
				admst.STD_CNIC = adm.STD_CNIC;
				admst.FTHR_CNIC = adm.FTHR_CNIC;
				admst.APPLIED_FOR_CLASS = adm.APPLIED_FOR_CLASS;
				admst.PHONE = adm.PHONE;
				admst.REMARKS = adm.REMARKS;
				admst.ADDEDBY = User.Identity.GetUserId();
				admst.ADDEDDATE = DateTime.Now;
				admst.UPDATEDATE = null;
				admst.UPDATEDBY = null;
				try
				{
					db.Admission_mst.Add(admst);
					db.SaveChanges();
					TempData["success"] = "Inserted Successfully";
				}
				catch (Exception ex)
				{
					TempData["failed"] = "Inserted Failed";
				}
				
			}
			else
			{

			}
			return View();
		}



		[HttpGet]
		public ActionResult updateAdmissionForm(int? id)
		{
	
				Admission_mst Model = db.Admission_mst.Where(x => x.Adms_ID == id).FirstOrDefault();
		 
	
			return View(Model);
		}



		[HttpPost]
		public ActionResult updateAdmissionForm(Admission_mst Adms, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{
				string path;
				Random r = new Random();

				if (file != null)
				{
					path = uploadimgfile(file, r.Next().ToString(), "~/assets/StudentImage/", 5000);
				}
				else
				{
					path = Adms.USER_IMG;
				}
				Adms.UPDATEDATE = DateTime.Now;
				Adms.UPDATEDBY = User.Identity.GetUserId();
				Adms.USER_IMG = path;

				try
				{
					db.Entry(Adms).State = EntityState.Modified;
					db.SaveChanges();
					TempData["success"] = "Updated Successfully";
					return RedirectToAction("AdmissionList");
				}
				catch (Exception ex)
				{
					TempData["failed"] = "Updated Failed";
				}
			}
			else
			{

			}

			return View(Adms);
		}













		public string uploadimgfile(HttpPostedFileBase file, string ran1, string locpath, int fsize)
		{
			string path = "-1";
			if (file != null && file.ContentLength > 0)
			{
				string extension = Path.GetExtension(file.FileName);
				int filesize = file.ContentLength / 1024;
				if (filesize <= fsize)
				{
					try
					{
						path = Path.Combine(Server.MapPath(locpath), ran1 + extension.ToLower());
						file.SaveAs(path);
						path = locpath + ran1 + extension.ToLower();
						ran1 = "";

					}
					catch (Exception)
					{
						path = "-1";
					}

				}
				else
				{
					path = "-2";

				}
			}

			return path;
		}
	}



}