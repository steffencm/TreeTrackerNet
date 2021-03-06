﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreeTrackerNet.Models;

namespace TreeTrackerNet.Controllers
{
    public class TreesController : Controller
    {
        private TreeDBContext db = new TreeDBContext();

        // GET: Trees
        public ActionResult Index(string treeSpecies, string searchString)
        {

            var SpeciesList = new List<string>();

            var SpeciesQry = from d in db.Trees
                           orderby d.Species
                           select d.Species;

            SpeciesList.AddRange(SpeciesQry.Distinct());
            ViewBag.treeSpecies = new SelectList(SpeciesList);

            var trees = from tree in db.Trees
                         select tree
                         ;

            if (!String.IsNullOrEmpty(searchString))
            {
                trees = trees.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(treeSpecies))
            {
                trees = trees.Where(x => x.Species == treeSpecies);
            }

            return View(trees);
        }

        // GET: Trees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tree tree = db.Trees.Find(id);
            if (tree == null)
            {
                return HttpNotFound();
            }
            return View(tree);
        }

        // GET: Trees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Species,DateBought,AquiredFrom")] Tree tree)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count == 0)
                {
                    return View(tree);
                }
                HttpPostedFileBase file = Request.Files[0];
                var fileName = "~/Upload_Files/" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath(fileName));
                tree.ImagePath = fileName;                
                db.Trees.Add(tree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tree);
        }

        // GET: Trees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tree tree = db.Trees.Find(id);
            if (tree == null)
            {
                return HttpNotFound();
            }
            return View(tree);
        }

        // POST: Trees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Species,DateBought,AquiredFrom")] Tree tree)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(Request.Files[0].FileName))
                {
                    HttpPostedFileBase file = Request.Files[0];
                    var fileName = "~/Upload_Files/" + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath(fileName));
                    tree.ImagePath = fileName;
                }else
                {
                    tree.ImagePath = db.Trees.Find(tree.ID).ImagePath;
                }

                db.Entry(tree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tree);
        }

        // GET: Trees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tree tree = db.Trees.Find(id);
            if (tree == null)
            {
                return HttpNotFound();
            }
            return View(tree);
        }

        // POST: Trees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tree tree = db.Trees.Find(id);
            db.Trees.Remove(tree);
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
