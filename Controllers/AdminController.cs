using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrgSoft.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}