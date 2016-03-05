using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;
using TiendaVirtual.WeatherService;

namespace TiendaVirtual.Controllers
{
    public class CarritoController : Controller
    {
        private TiendaVirtualEntities tiendaVirtualEntities = new TiendaVirtualEntities();
        // GET: Carrito

        public ActionResult Index(Carrito cc)
        {
            return View(cc);

        }
        public ActionResult AddProducto(Carrito cc, int id)
        {
            Producto productolista = tiendaVirtualEntities.Productos.Find(id);

            var busqueda = cc.Where(producto => producto.Nombre == productolista.Nombre);

            if (productolista.Cantidad > 0)
            { 
                if (busqueda.Count() == 0)
                {
                    Producto productoCarrito = new Producto();
                    productoCarrito.Id = productolista.Id;
                    productoCarrito.Nombre = productolista.Nombre;
                    productoCarrito.Descripcion = productolista.Descripcion;
                    productoCarrito.Cantidad = 1;
                    productoCarrito.Precio = productolista.Precio;
                    productoCarrito.Imagen = productolista.Imagen;
                    cc.Add(productoCarrito);
                    cc.precioTotal += productoCarrito.Precio.Value;
                }
                else
                {
                    cc.Find(p => p.Nombre == productolista.Nombre).Cantidad++;
                    cc.precioTotal += cc.Find(p => p.Nombre == productolista.Nombre).Precio.Value;
                }             
            }

            TempData["precio"] = cc.precioTotal.ToString();
            return RedirectToAction("Index", "Productoes");
        }

        public ActionResult DeleteProduct(Carrito cc, int id)
        {
           var productoToDelete = cc.Find(p => p.Id == id);
           cc.precioTotal -= cc.Find(p => p.Id == id).Precio.Value;
            if (productoToDelete.Cantidad == 1)
            {               
                cc.Remove(cc.Find(p => p.Id == id));
            }
            else
            {
                cc.Find(p => p.Id == id).Cantidad--;
            }

           TempData["precio"] = cc.precioTotal.ToString();
           return RedirectToAction("Index", "Carrito");
        }

        public ActionResult ViewWeather()
        {
            GlobalWeatherSoap weather = new GlobalWeatherSoapClient("GlobalWeatherSoap");
            return View((object)weather.GetWeather("Madrid", "Spain"));
        }

        public ActionResult ConfirmPurchasing(Carrito cc)
        {
            string mensaje;
            Pedido pedido = new Pedido();
            pedido.Nombre = "Pedido " + tiendaVirtualEntities.Pedidos.Count();
            pedido.Productos = "";
            pedido.Precio = 0;

            foreach (var elem in cc)
            {
                pedido.Productos += elem.Nombre + "(" + elem.Cantidad + "), ";
              //  pedido.Precio += elem.Precio * elem.Cantidad;
            }
            pedido.Precio = cc.precioTotal;
            tiendaVirtualEntities.Pedidos.Add(pedido);
            
            foreach (Producto p in cc)
            {
                
                var busqueda = tiendaVirtualEntities.Productos.Where(producto => producto.Id == p.Id);
                foreach (Producto prod in busqueda)
                {
                    prod.Cantidad = prod.Cantidad - p.Cantidad;
                    if(prod.Cantidad == 0)
                    {
                        ProductosAgotado prodAgotado = new ProductosAgotado();
                        prodAgotado.Nombre = prod.Nombre;
                        tiendaVirtualEntities.ProductosAgotados.Add(prodAgotado);
                    }
                    else if (prod.Cantidad < 0)
                    {
                        mensaje = "NO SE HA REALIZADO LA COMPRA, NO HAY SUFICIENTE CANTIDAD DE " + prod.Nombre;
                        return View((object)mensaje);
                    }
                }
            }
            tiendaVirtualEntities.SaveChanges();
            cc.Clear();

            mensaje = "PEDIDO REALIZADO Y GUARDADO EN LA BASE DE DATOS";
            return View((object)mensaje);
        }

    }
}