using DIWebApplication.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class GenericController : Controller
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public GenericController(IGenericRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        { 
            _clienteRepository.Adicionar(new Cliente());            
            return View();
        }
    }
}
