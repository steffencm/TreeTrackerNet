﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreeTrackerNet.Models;

namespace TreeTrackerNet.Controllers
{
    public class TreeObservationsController : Controller
    {
        private TreeDBContext db = new TreeDBContext();

        // GET: TreeObservations
        public ActionResult Index(int? treeId)
        {
            var treeObservations = from observation in db.TreeObservations
                                   select observation;
            
            if(treeId != null)
            {
                ViewBag.TreeName = db.Trees.Find(treeId).Name;
                ViewBag.TreeId = treeId;
                treeObservations = treeObservations.Where(x => x.TreeID == treeId);
            }
            else
            {
                return HttpNotFound();
            }
            return View(treeObservations.ToList());
        }

        // GET: TreeObservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreeObservation treeObservation = db.TreeObservations.Find(id);
            if (treeObservation == null)
            {
                return HttpNotFound();
            }
            return View(treeObservation);
        }

        // GET: TreeObservations/Create
        public ActionResult Create(int? treeId)
        {
            ViewBag.TreeID = treeId;
            return View();
        }

        // POST: TreeObservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TreeID,DateObserver,Watered,Fertalized,TrunkMeasurement,Notes")] TreeObservation treeObservation)
        {
            if (ModelState.IsValid)
            {
                db.TreeObservations.Add(treeObservation);
                db.SaveChanges();
                return RedirectToAction("Index", new { treeId = treeObservation.TreeID });
            }

            ViewBag.TreeID = treeObservation.TreeID;
            return View(treeObservation);
        }

        // GET: TreeObservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreeObservation treeObservation = db.TreeObservations.Find(id);
            if (treeObservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.TreeID = new SelectList(db.Trees, "ID", "Name", treeObservation.TreeID);
            return View(treeObservation);
        }

        // POST: TreeObservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TreeID,DateObserver,Watered,Fertalized,TrunkMeasurement,Notes")] TreeObservation treeObservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treeObservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { treeId= treeObservation.TreeID });
            }
            ViewBag.TreeID = new SelectList(db.Trees, "ID", "Name", treeObservation.TreeID);
            return View(treeObservation);
        }

        // GET: TreeObservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreeObservation treeObservation = db.TreeObservations.Find(id);
            if (treeObservation == null)
            {
                return HttpNotFound();
            }
            return View(treeObservation);
        }

        // POST: TreeObservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreeObservation treeObservation = db.TreeObservations.Find(id);
            db.TreeObservations.Remove(treeObservation);
            db.SaveChanges();
            return RedirectToAction("Index", new { treeId = treeObservation.TreeID });
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
