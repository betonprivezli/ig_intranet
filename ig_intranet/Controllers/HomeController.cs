using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnumSample.Models;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace EnumSample.Controllers
{
    public class HomeController : Controller
    {
        private MyDataContext db = new MyDataContext();
        
        public ActionResult Start_1c_web(string id)
        {
            ViewBag.Identity_Name = Request.LogonUserIdentity.Name;
            ViewBag.id = id;
            ViewBag.User_imp = "";
            ViewBag.User_imp_p = "";
            if (id == null)
            {

            }else if(id == "1c_imp")
            {
                //var usr = db.UsersImp.Where(p => p.User_in_Domen == "v.yurin");


                ViewBag.UsersImp = db.UsersImp.ToArray();
                
                
                foreach (var item in ViewBag.UsersImp)
                {
                    if (item.Domen + "\\" + item.User_in_Domen == ViewBag.Identity_Name)
                    {
                        ViewBag.User_imp = item.User_FIO_Aunt;
                        ViewBag.User_imp_p = item.User_UID;
                        break;
                    }
                }
            }else if(id == "1c_real")
            {

            }

            ViewBag.UsersImp = "";
            return View();
        }
        // GET: /Home/
        public ActionResult Index(string id)
        {
            //IQueryable<UsersImp> users = db3.UsersImp;
            /*ViewBag.test = "";
            ViewBag.test = ViewBag.test + "1 " + Environment.UserDomainName;// Environment.UserName;
            ViewBag.test = ViewBag.test + "2 " + User.Identity.Name;
            ViewBag.test = ViewBag.test + "3 " + Environment.UserName;
            ViewBag.test = ViewBag.test + "4 " + Request.LogonUserIdentity.Name;
            ViewBag.test = ViewBag.test + "5 "+System.Security.Principal.WindowsIdentity.GetCurrent().Name;*/

            ViewBag.Title = "Inline main page";
            char[] charSeparators = new char[] { '\\' };
            ViewBag.Identity_Name_arr = Request.LogonUserIdentity.Name.Split(charSeparators, StringSplitOptions.None);
            ViewBag.Identity_UserName = "";
            /*if (ViewBag.Identity_Name_arr.Length == 2) {
                ViewBag.Identity_UserName = ViewBag.Identity_Name_arr[1];                
            }
            */
            ViewBag.Identity_Name = Request.LogonUserIdentity.Name;            
            if (id == "StartPage")
            {
                return Redirect("/");
            }            
            return View();
            //return View(db2.UsersDo.ToList());
            //return View(db.MyDatas.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
