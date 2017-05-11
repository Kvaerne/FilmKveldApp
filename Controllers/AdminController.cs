using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmKveldApp.Models;
using System.IO;


namespace FilmKveldApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult VisAlleFilmer()
        {
            try {
                using (var dbkobling = new FilmKveldDBEntities())
                   {
                    var filmliste = (from films in dbkobling.Filmer
                                   select films).ToList();
                    return View(filmliste);
                   } 
                } catch (Exception exeption)
            {
                ViewBag.Feilmelding = exeption.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult LoggInnAdmin()
        {
                return View();
        }
            
        [HttpPost]
        public ActionResult LoggInnAdmin(Brukere loggInnAdmin)
        {
            String adminBruker = "HouseSchiffer";

            if (loggInnAdmin.Brukernavn == adminBruker)
            {
                Session["LoggetInn"] = adminBruker;
                ViewBag.LoggetInn = true;
                return RedirectToAction("VisAlleFilmer");
            }
            else
            {
                ViewBag.LoggetInn = false;
            }
            return View();
        }
    }
}