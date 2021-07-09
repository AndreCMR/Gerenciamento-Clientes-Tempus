using GerenciamentoClientes.Dominio.Models;
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

        public List<RendimentoFamiliar> Executar(DateTime dataInicio, DateTime dataFinal)
        {
            var classeRendimento = _contexto.Cliente
                .Where(p => p.DataCadastro >= dataInicio && p.DataCadastro <= dataFinal)
                .Select(d => d.RendaFamiliar)
                .ToList().GroupBy(new ClassesRendimentoClienteUtils().ClassesRendimentoDescricao)
                .ToDictionary(k => k.Key, v => v.Count());


            var resultado = classeRendimento.Select(f => new RendimentoFamiliar
            {
                Classe = f.Key,
                Quantidade = f.Value
            })
              .OrderBy(x => x.Classe == "Classe C")
              .ThenBy(x => x.Classe == "Classe B")
              .ThenBy(x => x.Classe == "Classe A").ToList();


            return resultado;
        }




    }

    
}
