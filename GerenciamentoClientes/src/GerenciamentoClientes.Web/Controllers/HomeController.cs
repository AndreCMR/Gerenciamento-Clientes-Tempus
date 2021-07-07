using GerenciamentoClientes.Historias.ClienteHistoria;
using GerenciamentoClientes.Historias.ClienteHistoria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Web.Controllers
{
    public class HomeController : Controller
    {    
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
