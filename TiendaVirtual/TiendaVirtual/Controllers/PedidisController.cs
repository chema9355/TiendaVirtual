using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Controllers
{
    public class PedidisController : Controller
    {
        // GET: Pedidis
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pedidis/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedidis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidis/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedidis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedidis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
