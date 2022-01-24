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
        private UsersDoContext db2 = new UsersDoContext();        
        private UsersImpContext db3 = new UsersImpContext();

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
                ViewBag.UsersImp = db3.UsersImp.ToArray();
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

        // GET: /Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyData mydata = db.MyDatas.Find(id);
            if (mydata == null)
            {
                return HttpNotFound();
            }
            return View(mydata);
        }

        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Enum1,Enum2,FlagsEnum")] MyData mydata)
        {
            if (ModelState.IsValid)
            {
                db.MyDatas.Add(mydata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mydata);
        }

        // GET: /Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyData mydata = db.MyDatas.Find(id);
            if (mydata == null)
            {
                return HttpNotFound();
            }
            return View(mydata);
        }

        // POST: /Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Enum1,Enum2,FlagsEnum")] MyData mydata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mydata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mydata);
        }

        // GET: /Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyData mydata = db.MyDatas.Find(id);
            if (mydata == null)
            {
                return HttpNotFound();
            }
            return View(mydata);
        }

        // POST: /Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyData mydata = db.MyDatas.Find(id);
            db.MyDatas.Remove(mydata);
            db.SaveChanges();
            return RedirectToAction("Index");
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
