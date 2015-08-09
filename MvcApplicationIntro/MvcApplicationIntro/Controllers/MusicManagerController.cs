using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcApplicationIntro.Models;

namespace MvcApplicationIntro.Controllers
{
    public class MusicManagerController : Controller
    {
        private MusicStoreDB db = new MusicStoreDB();

        // GET: MusicManager
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
            return View(albums.ToList());
        }

        // GET: MusicManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumViewModel albumViewModel = db.Albums.Find(id);
            if (albumViewModel == null)
            {
                return HttpNotFound();
            }
            return View(albumViewModel);
        }

        // GET: MusicManager/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            return View();
        }

        // POST: MusicManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price")] AlbumViewModel albumViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(albumViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", albumViewModel.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", albumViewModel.GenreId);
            return View(albumViewModel);
        }

        // GET: MusicManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumViewModel albumViewModel = db.Albums.Find(id);
            if (albumViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", albumViewModel.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", albumViewModel.GenreId);
            return View(albumViewModel);
        }

        // POST: MusicManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price")] AlbumViewModel albumViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", albumViewModel.ArtistId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", albumViewModel.GenreId);
            return View(albumViewModel);
        }

        // GET: MusicManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumViewModel albumViewModel = db.Albums.Find(id);
            if (albumViewModel == null)
            {
                return HttpNotFound();
            }
            return View(albumViewModel);
        }

        // POST: MusicManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumViewModel albumViewModel = db.Albums.Find(id);
            db.Albums.Remove(albumViewModel);
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
