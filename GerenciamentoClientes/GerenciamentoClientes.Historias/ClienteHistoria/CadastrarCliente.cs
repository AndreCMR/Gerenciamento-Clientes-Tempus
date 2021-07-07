using GerenciamentoClientes.Dominio.Models;
using GerenciamentoClientes.Historias.ClienteHistoria.ViewModels;
using GerenciamentoClientes.Infra.Contexto;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Historias.ClienteHistoria
{
   public class CadastrarCliente
    {
        private readonly GerenciamentoClienteContexto _contexto;

        public CadastrarCliente(GerenciamentoClienteContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task Executar(ClienteViewModel clienteViewModel)
        {
            Cliente cliente = clienteViewModel;

            await _contexto.AddAsync(cliente);

            await _contexto.SaveChangesAsync();
        }
    }
}
