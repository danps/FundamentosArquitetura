using System;
using DIWebApplication.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class MultiplasClassesController : Controller
    {
        private readonly Func<string, IService> _serviceAccessor;

        public MultiplasClassesController(Func<string, IService> serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = _serviceAccessor("A").Retorno();
            //return _serviceAccessor("B").Retorno();
            //return _serviceAccessor("C").Retorno();

            return View();
        }
    }
}
