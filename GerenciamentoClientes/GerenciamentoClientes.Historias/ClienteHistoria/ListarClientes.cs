using GerenciamentoClientes.Historias.ClienteHistoria.ViewModels;
using GerenciamentoClientes.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Historias.ClienteHistoria
{
    public class ListarClientes
    {
        private readonly GerenciamentoClienteContexto _contexto;

        public ListarClientes(GerenciamentoClienteContexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<List<ClienteViewModel>> Executar()
        {
            var clientes = await _contexto.Cliente.ToListAsync();

            var clientesViewModel = clientes.Select(cliente => {

                ClienteViewModel clienteViewModel = cliente;

                return clienteViewModel;

            }).ToList();

            return clientesViewModel;
        }
    }
}
