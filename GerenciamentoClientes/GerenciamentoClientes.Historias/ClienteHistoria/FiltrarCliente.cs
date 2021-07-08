using GerenciamentoClientes.Dominio.Models;
using GerenciamentoClientes.Historias.ClienteHistoria.ViewModels;
using GerenciamentoClientes.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Historias.ClienteHistoria
{
    public class FiltrarCliente
    {
        private readonly GerenciamentoClienteContexto _contexto;

        public FiltrarCliente(GerenciamentoClienteContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<ClienteViewModel>> Executar(string nome)
        {
            var clientes = await _contexto.Cliente.Where(cliente => string.IsNullOrEmpty(nome) || cliente.Nome.Contains(nome)).ToListAsync();

            var clientesViewModel = clientes.Select(cliente =>
            {
                ClienteViewModel clienteViewModel = cliente;

                return clienteViewModel;
            }).ToList();

            return clientesViewModel;
        }
    }
}
