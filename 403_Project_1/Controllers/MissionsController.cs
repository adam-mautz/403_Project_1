using _403_Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403_Project_1.Controllers
{
    public class MissionsController : Controller
    {
        // GET: Missions
        public ActionResult Index()
        {
            List<SelectListItem> lstMission = new List<SelectListItem>();
            lstMission.Add(new SelectListItem {Text = "Texas Lubbock", Value = "TLM"});
            lstMission.Add(new SelectListItem {Text = "North Carolina Charlotte", Value = "NCCM" });
            lstMission.Add(new SelectListItem {Text = "Thailand Bankok", Value = "TBM" });
            lstMission.Add(new SelectListItem {Text = "Argentina Santa Fe", Value = "ASFM" });
            ViewBag.Missions = lstMission;
            return View();
        }
    }
}