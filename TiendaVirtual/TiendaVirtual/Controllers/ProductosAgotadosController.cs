using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Controllers
{
    public class ProductosAgotadosController : Controller
    {
        private TiendaVirtualEntities tiendaVirtualEntities = new TiendaVirtualEntities();
        // GET: ProductosAgotados
        public ActionResult Index()
        {
            return View(tiendaVirtualEntities.ProductosAgotados.ToList());
        }
    }
}