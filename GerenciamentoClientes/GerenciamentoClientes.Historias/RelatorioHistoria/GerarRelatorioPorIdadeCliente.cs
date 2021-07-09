using GerenciamentoClientes.Historias.ClienteHistoria.ViewModels;
using GerenciamentoClientes.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoClientes.Historias.RelatorioHistoria
{
    public class GerarRelatorioPorIdadeCliente
    {
        private readonly GerenciamentoClienteContexto _contexto;

        public GerarRelatorioPorIdadeCliente(GerenciamentoClienteContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> Executar(DateTime dataInicio, DateTime dataFinal)
        {           

            var mediaRendaFamiliar = await _contexto.Cliente.AverageAsync(p => p.RendaFamiliar);

            var clientes = await _contexto.Cliente
                .Where(p => p.DataCadastro >= dataInicio && p.DataCadastro <= dataFinal)
                .Where(cliente => cliente.RendaFamiliar > mediaRendaFamiliar)
                .ToListAsync();

            var total = clientes.Count(cliente => CalculaIdade(cliente.DataNascimento) >= 18);

            return total;
        }

        private int CalculaIdade(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;

            if(DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;

        }

    }
}
