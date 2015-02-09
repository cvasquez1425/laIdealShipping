using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laIdealShipping.Entities;
using laIdealShipping.Web.DataContexts;
using System.Data.Entity;

namespace laIdealShipping.Web.Controllers
{
    //[Authorize(Roles="admin, sales")]
    //[Authorize(Users="admin, sallen")]
    public class HomeController : Controller
    {
        private static laIdealShippingsDb _db = new laIdealShippingsDb();

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ShippingMaintenance(Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(shipping).State = EntityState.Modified;
                _db.SaveChanges();
                    return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        public ActionResult ShippingMaintenance()
        {
            return View();
        }

        [Authorize]
        public ActionResult Shipping()
        {
            return View();
        }

        // POST Shipping/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Shipping([Bind(Include = "Id,nextShippingDate,salida,Status")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                _db.Shippings.Add(shipping);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipping);
        }

        public ActionResult IndexHome()
        {
            var data = _db.Shippings.Where(s => s.salida == true)
                        .Select(s => new
                        {
                            s.nextShippingDate
                        });
            return View(data);
        }

        public ActionResult Index()
        {
            var result = (from s in _db.Shippings
                         where s.salida == true
                         select s).ToList().SingleOrDefault(); // .Single();
            return View(result);
        }


        // Testing for unauthorized users
        [Authorize]
        public ContentResult Secret()
        {
            return Content("This is a secret.....");
        }

//        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("This is NOT a Secret....");
        }

        /// <summary>
        /// testing Modal Component of Bootstrap
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexModal()
        {
            return View();
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

        public ActionResult Contacts()
        {
            return View(new Contact());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contacts([Bind(Include = "contactId,firstName,lastName,phone,email,comments,emailMeUpdate" )] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(contact);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
    }
}