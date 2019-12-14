using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _403_Project_1.DAL;
using _403_Project_1.Models;

namespace _403_Project_1.Controllers
{
    public class MissionQuestionsController : Controller
    {
        private MissionContext db = new MissionContext();
        public static Missions globalMission = new Missions();
        public static int UserID = 0;

        // GET: MissionQuestions
        [Authorize]
        public ActionResult Index(int missionID, int id)
        {
            Missions mission = db.missions.Find(missionID);

            ViewBag.Name = mission.MISSION_NAME;
            ViewBag.President = mission.PRESIDENT_NAME;
            ViewBag.Addy = mission.ADDRESS;
            ViewBag.Language = mission.LANGUAGE;
            ViewBag.CLimate = mission.CLIMATE;
            ViewBag.Religion = mission.DOMINANT_RELIGION;
            ViewBag.Symbol = mission.SYMBOL;
            ViewBag.ID = mission.MISSION_ID;

            globalMission = mission;
            UserID = id;

            var dbQuestions = 
                db.Database.SqlQuery<MissionQuestions>(
                  "SELECT * FROM MissionQuestions WHERE MISSION_ID = " + mission.MISSION_ID );


            return View(dbQuestions.ToList());
        }

        // GET: MissionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.missionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Create
        public ActionResult Create()
        {
            MissionQuestions mishQ = new MissionQuestions();
            mishQ.MISSION_ID = globalMission.MISSION_ID;
            mishQ.USER_ID = UserID;
            return View(mishQ);
        }

        // POST: MissionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QUESTION_ID,MISSION_ID,USER_ID,QUESTION,ANSWER")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                db.missionQuestions.Add(missionQuestions);
                db.SaveChanges();
                return RedirectToAction("Index", new { missionID = globalMission.MISSION_ID, id = UserID });
            }

            return View(missionQuestions);
        }

        // GET: MissionQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.missionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QUESTION_ID,MISSION_ID,USER_ID,QUESTION,ANSWER")] MissionQuestions missionQuestions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(missionQuestions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { missionID = globalMission.MISSION_ID, id = UserID });
            }
            return View(missionQuestions);
        }

        // GET: MissionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MissionQuestions missionQuestions = db.missionQuestions.Find(id);
            if (missionQuestions == null)
            {
                return HttpNotFound();
            }
            return View(missionQuestions);
        }

        // POST: MissionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MissionQuestions missionQuestions = db.missionQuestions.Find(id);
            db.missionQuestions.Remove(missionQuestions);
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
