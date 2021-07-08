using GerenciamentoClientes.Historias.ClienteHistoria;
using GerenciamentoClientes.Historias.ClienteHistoria.Validators;
using GerenciamentoClientes.Historias.ClienteHistoria.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Web.Controllers
{
    public class ClientesController : Controller
    {

        public async Task<IActionResult> Index([FromServices]ListarClientes listarClientes)
        {
            var list = await listarClientes.Executar();
            return View(list);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromServices] CadastrarCliente cadastrarCliente, [FromServices] VerificarCpfCliente verificarCpfCliente, ClienteViewModel clienteViewModel)
        {
            if (!clienteViewModel.CPF.ValidaCPF())
            {
                ModelState.AddModelError("CPF", "CPF inválido.");

                return View(clienteViewModel);
            }

            if (ModelState.IsValid)
            {

                if (verificarCpfCliente.Executar(clienteViewModel.CPF))
                {
                    ModelState.AddModelError("CPF", "CPF já cadastrado");

                    return View(clienteViewModel);
                }

                await cadastrarCliente.Executar(clienteViewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(clienteViewModel);
        }


    }
}
