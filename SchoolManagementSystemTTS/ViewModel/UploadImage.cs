using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using SchoolManagementSystemWebApplication.Models;
using SchoolManagementSystemWebApplication.ViewModel;

namespace SchoolManagementSystemWebApplication.ViewModel
{
    public class UploadImage  
    {
        public string uploadimgfile(HttpPostedFileBase file, string locpath, int fsize)
        {
            Random random = new Random();  
            string ran1 = random.Next(100000,900000000).ToString();
            string path = "-1";
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                int filesize = file.ContentLength / 1024;
                if (filesize <= fsize)
                {
                    try
                    {   
                        path = Path.Combine(HttpContext.Current.Server.MapPath(locpath), ran1 + extension.ToLower());
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