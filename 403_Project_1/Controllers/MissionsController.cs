using _403_Project_1.DAL;
using _403_Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _403_Project_1.Controllers
{


    public class MissionsController : Controller
    {
        private MissionContext db = new MissionContext();

        public static Missions globalMission = new Missions();

        // GET: Missions
        public ActionResult Index()
        {
            Missions myMissions = new Missions();
            myMissions.lstMissions = db.missions.ToList();

            return View(myMissions);
        }

        [HttpPost]
        public ActionResult Index(Missions model)
        {
            Missions newMission = new Missions();
        
            newMission = db.missions.Find(model.MISSION_ID);
            globalMission = newMission;

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            ViewBag.Mission = globalMission.MISSION_ID;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            var currentCustomer =
                db.Database.SqlQuery<Users>(
            "Select * " +
            "FROM Users " +
            "WHERE USER_EMAIL = '" + username + "' AND " +
            "PASSWORD = '" + password + "'");

            var results = db.Database.SqlQuery<Users>(
            "Select * " +
            "FROM Users " +
            "WHERE USER_EMAIL = '" + username + "' AND " +
            "PASSWORD = '" + password + "'");
            int Id = 0;
            foreach (var item in results)
            {
                var id = item.USER_ID;
                Id = id;
            }

            Missions newMission = globalMission;

            if (currentCustomer.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                return RedirectToAction("Index", "MissionQuestions", new { missionID = globalMission.MISSION_ID, id = Id});
            }

            else
            {
                return View();
            }
        }





    }
}