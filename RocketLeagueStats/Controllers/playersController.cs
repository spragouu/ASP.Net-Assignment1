﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RocketLeagueStats.Models;

namespace RocketLeagueStats.Controllers
{
    public class playersController : Controller
    {
        private RocketLeagueStatsModel db = new RocketLeagueStatsModel();

        // GET: players
        public ActionResult Index()
        {
            var players = db.players.Include(p => p.team);
            return View(players.ToList());
        }

        // GET: players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player player = db.players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: players/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.teamid = new SelectList(db.teams, "teamid", "name");
            return View();
        }

        // POST: players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "playerid,teamid,name,goals,assists,saves,shots")] player player)
        {
            if (ModelState.IsValid)
            {
                db.players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teamid = new SelectList(db.teams, "teamid", "name", player.teamid);
            return View(player);
        }

        // GET: players/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player player = db.players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.teamid = new SelectList(db.teams, "teamid", "name", player.teamid);
            return View(player);
        }

        // POST: players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "playerid,teamid,name,goals,assists,saves,shots")] player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teamid = new SelectList(db.teams, "teamid", "name", player.teamid);
            return View(player);
        }

        // GET: players/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            player player = db.players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            player player = db.players.Find(id);
            db.players.Remove(player);
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
