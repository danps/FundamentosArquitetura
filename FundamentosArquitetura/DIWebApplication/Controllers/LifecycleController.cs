using DIWebApplication.Cases;
using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class LifecycleController : Controller
    {
        public OperacaoService OperacaoService { get; }
        public OperacaoService OperacaoService2 { get; }

        public LifecycleController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            OperacaoService = operacaoService;
            OperacaoService2 = operacaoService2;
        }

        public IActionResult Index()
        {
            var str = new object[] 
            {
                "Primeira instância: ",
                OperacaoService.Transient.OperacaoId,
                OperacaoService.Scoped.OperacaoId,
                OperacaoService.Singleton.OperacaoId,
                OperacaoService.SingletonInstance.OperacaoId,


                "Segunda instância: ",
                OperacaoService2.Transient.OperacaoId,
                OperacaoService2.Scoped.OperacaoId,
                OperacaoService2.Singleton.OperacaoId,
                OperacaoService2.SingletonInstance.OperacaoId
            };
            ViewData["Message"] = str;
            return View();
        }
    }
}