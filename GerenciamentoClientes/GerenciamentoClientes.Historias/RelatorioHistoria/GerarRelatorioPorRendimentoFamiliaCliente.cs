using GerenciamentoClientes.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Historias.RelatorioHistoria
{
    public class GerarRelatorioPorRendimentoFamiliaCliente
    {
        private readonly GerenciamentoClienteContexto _contexto;

        public GerarRelatorioPorRendimentoFamiliaCliente(GerenciamentoClienteContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Executar()
        {
            var clientes = await _contexto.Cliente.Where(cliente => cliente.RendaFamiliar > 0).ToListAsync();

            var classeA = clientes.Count(r => r.RendaFamiliar <= 980);

            var classeB = clientes.Count(r => r.RendaFamiliar > 980 && r.RendaFamiliar <= 2500);

            var classeC = clientes.Count(r => r.RendaFamiliar > 2500);
        }


    }
}
