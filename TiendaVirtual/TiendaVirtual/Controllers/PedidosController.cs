using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Controllers
{
    public class PedidosController : Controller
    {
        private TiendaVirtualEntities tiendaVirtualEntities = new TiendaVirtualEntities();

        // GET: Pedidos
        public ActionResult Index()
        {
            return View(tiendaVirtualEntities.Pedidos.ToList());
        }
    }
}