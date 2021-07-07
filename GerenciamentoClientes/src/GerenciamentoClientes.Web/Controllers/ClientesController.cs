using GerenciamentoClientes.Historias.ClienteHistoria;
using GerenciamentoClientes.Historias.ClienteHistoria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly CadastrarCliente _cadastrarCliente;
        private readonly ListarClientes _listarClientes;


        public ClientesController(CadastrarCliente cadastrarCliente, ListarClientes listarClientes)
        {
            _cadastrarCliente = cadastrarCliente;
            _listarClientes = listarClientes;
        }

        public IActionResult Index()
        {       
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                await _cadastrarCliente.Executar(clienteViewModel);

                return View(clienteViewModel);
            }            

            return View(clienteViewModel);
        }
    }
}
