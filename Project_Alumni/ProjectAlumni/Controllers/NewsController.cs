﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectAlumni.Models;

namespace ProjectAlumni.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: News
        [AllowAnonymous]
        public ActionResult Index()
        {
            var news = db.news.Include(n => n.AspNetUser);
            return View(news.ToList());
        }

        [AllowAnonymous]
        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }


        // GET: News/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            ViewBag.users_userid = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "newsid,title,text,users_userid,date")] news news)
        {
            if (ModelState.IsValid)
            {
                //Get the user id of the current user and add it to the News item
                string username = User.Identity.Name.ToString();
                var userid = db.AspNetUsers.SqlQuery("SELECT * FROM AspNetUsers WHERE UserName = " + "'" + username + "'").ToList();
                AspNetUser user = userid[0];
                news.users_userid = user.Id;

                //Get the current data and add it to the News item
                news.date = DateTime.Now;

                

                db.news.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.users_userid = new SelectList(db.AspNetUsers, "Id", "Email", news.users_userid);
            return View(news);
        }

        // GET: News/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.users_userid = new SelectList(db.AspNetUsers, "Id", "Email", news.users_userid);
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "newsid,title,text,users_userid,date")] news news)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.users_userid = new SelectList(db.AspNetUsers, "Id", "Email", news.users_userid);
            return View(news);
        }

        // GET: News/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            news news = db.news.Find(id);
            db.news.Remove(news);
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
