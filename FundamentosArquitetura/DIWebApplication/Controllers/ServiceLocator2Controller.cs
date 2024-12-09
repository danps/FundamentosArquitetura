using DIWebApplication.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class ServiceLocator2Controller : Controller
    {
        public IActionResult Index([FromServices] IServiceProvider serviceProvider)
        {
            // Retorna null se não estiver registrado
            serviceProvider.GetRequiredService<IClienteServices>().AdicionarCliente(new Cliente());

            return View();
        }
    }
}