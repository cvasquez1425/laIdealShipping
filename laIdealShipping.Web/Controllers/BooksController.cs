using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using laIdealShipping.Entities;
using laIdealShipping.Web.DataContexts;

namespace laIdealShipping.Web.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private laIdealShippingsDb db = new laIdealShippingsDb();

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
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
