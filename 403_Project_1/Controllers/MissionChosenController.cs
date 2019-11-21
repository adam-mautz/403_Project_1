using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _403_Project_1.Controllers
{
    public class MissionChosenController : Controller
    {
        // GET: MissionChosen
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult MissionChosen(string Mission)
        {
            if (Mission.Equals("TLM"))
                ViewBag.messageString = "Texas Lubbock";
            else if (Mission.Equals("NCCM"))
                ViewBag.messageString = "North Carolina Charlotte";
            else if (Mission.Equals("TBM"))
                ViewBag.messageString = "Thailand Bangkok";
            else if (Mission.Equals("ASFM"))
                ViewBag.messageString = "Argentina Santa Fe";

            return View("MissionChosen");
        }
    }
}