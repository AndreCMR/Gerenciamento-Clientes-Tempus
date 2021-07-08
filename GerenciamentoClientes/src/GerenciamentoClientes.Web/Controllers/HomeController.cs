using GerenciamentoClientes.Historias.RelatorioHistoria;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Web.Controllers
{
    public class HomeController : Controller
    {    
        public async Task<IActionResult> Index([FromServices] GerarRelatorioPorIdadeCliente gerarRelatorioPorIdadeCliente)
        {
          ViewData["TotalPorIdade"] =  await gerarRelatorioPorIdadeCliente.Executar();

            return View();
        }
      
    }
}
