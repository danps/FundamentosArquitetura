using DIWebApplication.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class ServiceLocatorController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceLocatorController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            // Retorna null se não estiver registrado
            _serviceProvider.GetRequiredService<IClienteServices>().AdicionarCliente(new Cliente());            
            return View();
        }
    }
}