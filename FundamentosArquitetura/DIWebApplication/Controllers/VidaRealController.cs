using DIWebApplication.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class VidaRealController : Controller
    {
        private readonly IClienteServices _clienteServices;

        public VidaRealController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        public IActionResult Index()
        { 
            _clienteServices.AdicionarCliente(new Cliente());
            return View();
        }
    }
}
