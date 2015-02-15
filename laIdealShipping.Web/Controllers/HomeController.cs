using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laIdealShipping.Entities;
using laIdealShipping.Web.DataContexts;
using System.Data.Entity;
using System.Net;

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
            var model = from s in _db.Shippings
                        select s;

            return View(model);
        }

        [Authorize]
        public ActionResult ShippingCreate()
        {
            Shipping model = new Shipping
            {
                nextShippingDate = DateTime.Now,
                salida = false,
                Status = 0

            };
            return View(model);
        }

        // POST Shipping/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShippingCreate([Bind(Include = "Id,nextShippingDate,salida,Status")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                _db.Shippings.Add(shipping);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipping);
        }

        //GET: Shipping Edit
        public ActionResult ShippingEdit(int? Id)
        {
            //var model = _db.Shippings.Single(s => s.Id = Id);

            if ( Id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = _db.Shippings.Find(Id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        //HTTP:POST Shipping/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShippingEdit(int Id, [Bind(Include="Id,nextShippingDate,salida,Status")] Shipping shipping)
        {
            var model = _db.Shippings.Single(s => s.Id == Id);

            //if (ModelState.IsValid)
            if (TryUpdateModel(model))
            {
                var attachedEntry = _db.Entry(model);
                attachedEntry.CurrentValues.SetValues(model);

                //_db.Entry(shipping).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipping);

        }

        // GET: Shipping/Delete
        public ActionResult ShippingDelete(int? Id)
        {
            if ( Id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = _db.Shippings.Find(Id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        //POST: Shipping/Confirm Delete
        [HttpPost, ActionName("ShippingDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ShippingDeleteConfirm(int Id)
        {
            Shipping shipping = _db.Shippings.Find(Id);
            _db.Shippings.Remove(shipping);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
                          select s.nextShippingDate).Max();
            //)ToList().SingleOrDefault(); // .Single();
            ViewData["nextDepartureDate"] = result.ToShortDateString();
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