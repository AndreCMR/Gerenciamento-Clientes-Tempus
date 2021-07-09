using GerenciamentoClientes.Historias.RelatorioHistoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly GerarRelatorioPorIdadeCliente gerarRelatorioPorIdadeCliente;
        private readonly GerarRelatorioPorRendimentoFamiliaCliente gerarRelatorioPorRendimentoFamiliaCliente;

        public HomeController(GerarRelatorioPorIdadeCliente gerarRelatorioPorIdadeCliente, GerarRelatorioPorRendimentoFamiliaCliente gerarRelatorioPorRendimentoFamiliaCliente)
        {
            this.gerarRelatorioPorIdadeCliente = gerarRelatorioPorIdadeCliente;
            this.gerarRelatorioPorRendimentoFamiliaCliente = gerarRelatorioPorRendimentoFamiliaCliente;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public async Task<IActionResult> Mes()
        {
            int diasNoMes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
            var dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, diasNoMes, 23, 59, 59);
            await CriarViewData(dataInicial, dataFinal);

            return View("Partials\\_Partial");
        }

        public async Task<IActionResult> Semana()
        {
            var dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 7);
            var dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            await CriarViewData(dataInicial, dataFinal);

            return View("Partials\\_Partial");
        }


        public async Task<IActionResult> Dia()
        {
            var dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23,59,59);
            await CriarViewData(dataInicial, dataFinal);
            return View("Partials\\_Partial");
        }


        private async Task CriarViewData(DateTime dataInicial, DateTime dataFinal)
        {
            ViewData["TotalPorIdade"] = await gerarRelatorioPorIdadeCliente.Executar(dataInicio: dataInicial, dataFinal: dataFinal);
            ViewData["ClassesRendimento"] = gerarRelatorioPorRendimentoFamiliaCliente.Executar(dataInicio: dataInicial, dataFinal: dataFinal);
        }
    }
}
