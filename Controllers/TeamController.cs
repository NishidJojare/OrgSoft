using OrgSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace OrgSoft.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult TeamIndex()
        {
            return View();
        }
        public ActionResult SaveTeam(TeamModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }
                return Json(new { Message = new TeamModel().SaveTeam(fb, model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { model = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetTeamList()
        {
            try
            {
                return Json(new { Message = (new TeamModel().GetTeamList()) },JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteTeam(int Id)
        {
            try
            {
                return Json(new { Message = (new TeamModel().DeleteTeam(Id)) },JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditTeam(int Id)
        {
            try
            {
                return Json(new { model = (new TeamModel().EditTeam(Id)) },JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}