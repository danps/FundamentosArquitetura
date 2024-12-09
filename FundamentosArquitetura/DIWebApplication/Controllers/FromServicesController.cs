using DIWebApplication.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class FromServicesController : Controller
    {
        public IActionResult Index([FromServices] IClienteServices clienteServices)
        { 
            clienteServices.AdicionarCliente(new Cliente());
            
            return View();
        }
    }
}