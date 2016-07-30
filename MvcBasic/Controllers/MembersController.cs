using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBasic.Models;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;

namespace MvcBasic.Controllers
{
    public class MembersController : Controller
    {
        private MvcBasicContext db = new MvcBasicContext();

        // GET: Members
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Birth,Married,Memo")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Birth,Married,Memo")] Member member)
        {
            if (ModelState.IsValid)
            {
                Debug.Print("-------------------------");
                Debug.Print("-------------------------");
                Debug.Print("-------------------------");

                if (false)
                {
                    Member test = db.Members.Find(member.Id);
                    {
                        Debug.Print("name = " + test.Name);
                    }
                }

                Debug.Print("----STATE0----");
                DbEntityEntry<Member> ent = db.Entry(member);
                ent.State = EntityState.Modified;
                db.SaveChanges();
                Debug.Print("--------------");

                if (false)
                {
                    // jikken
                    Member test = db.Members.Find(member.Id);
                    Debug.Print("name = " + test.Name);

                    Debug.Print("----STATE1----");
                    db.Entry(member).State = EntityState.Modified;
                    Debug.Print("--------------");

                    Debug.Print("----STATE2----");
                    DbEntityEntry<Member> t = db.Entry(member);
                    t.State = EntityState.Modified;
                    Debug.Print("--------------");

                    DbEntityEntry<Member> test2 = db.Entry(member);
                    Debug.Print("name2 = " + test2.Entity.Name);

                    test2.State = EntityState.Modified;
                    db.SaveChanges();

                    Debug.Print("name' = " + test.Name);
                    Debug.Print("name2' = " + test2.Entity.Name);

                    Member test3 = db.Members.Find(member.Id);
                    Debug.Print("name3 = " + test3.Name);
                }

                // update
                //db.Entry(member).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
