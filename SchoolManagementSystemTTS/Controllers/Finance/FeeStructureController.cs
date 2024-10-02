using Microsoft.AspNet.Identity;
using SchoolManagementSystemTTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystemTTS.Controllers.Finance
{
    public class FeeStructureController : Controller
    {
		private TTS_SMSEntities db = new TTS_SMSEntities();
		// GET: FeeStructure
		public ActionResult AddFeeStructure()
        {
            return View();
        }

        [HttpPost]
		public ActionResult AddFeeStructure(Fees_Structure fee)
		{
            
                try
                {

                fee.ADDEDBY = User.Identity.GetUserId().ToString();
                fee.ADDEDDATE = DateTime.Now;
                db.Fees_Structure.Add(fee);
                db.SaveChanges();

                

                }
                catch (Exception ex) { 
                
                
                }


            
			return View();
		}
	}
}