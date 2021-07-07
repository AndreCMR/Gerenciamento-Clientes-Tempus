using System;

namespace GerenciamentoClientes.Dominio.Models
{
    public class Cliente
    {
        protected Cliente()
        {
             //
        }

        public Cliente(Guid id, string nome, string cpf, DateTime dataNascimento, DateTime dataCadastro, decimal rendaFamiliar)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;
            RendaFamiliar = rendaFamiliar;
        }

        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public string CPF { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public decimal RendaFamiliar { get; private set; }
    }
}
