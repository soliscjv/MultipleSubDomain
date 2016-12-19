using SampleApp.Models;
using SampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            vm.Subdomains = db.Implementations.ToList();
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateSubdomain(Implementation subdomain)
        {
            db.Implementations.Add(subdomain);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail()
        {
            Implementation subdomain = new Implementation();
            string sub = Request.Url.ToString().Remove(0, 7).Remove(Request.Url.ToString().Remove(0, 7).IndexOf(".")).ToLower();
            subdomain = db.Implementations.Where(x => x.ImplementationName.ToLower() == sub).SingleOrDefault();
            return View(subdomain);
        }
    }
}