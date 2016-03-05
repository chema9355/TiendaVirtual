using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Models.ModelBinding
{
    public class CarritoBinding : IModelBinder
    {
        private const string SessionKey = "key";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Carrito carrito = (controllerContext.HttpContext.Session != null) ?
                    (controllerContext.HttpContext.Session[SessionKey] as Carrito) :
                    null;

            if (carrito == null)
            {
                carrito = new Carrito();
                controllerContext.HttpContext.Session[SessionKey] = carrito;
            }
            
            return carrito;
        }
    }
}