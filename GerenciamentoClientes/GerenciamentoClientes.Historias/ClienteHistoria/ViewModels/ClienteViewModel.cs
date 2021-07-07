using GerenciamentoClientes.Dominio.Models;
using System;

namespace GerenciamentoClientes.Historias.ClienteHistoria.ViewModels
{
    public class ClienteViewModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get;  set; }

        public string CPF { get;  set; }

        public DateTime DataNascimento { get;  set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public decimal RendaFamiliar { get;  set; }

        public static implicit operator Cliente(ClienteViewModel clienteViewModel)
        {
            return new Cliente(id: clienteViewModel.Id, nome: clienteViewModel.Nome, cpf: clienteViewModel.CPF, dataNascimento: clienteViewModel.DataNascimento, dataCadastro: clienteViewModel.DataCadastro, rendaFamiliar: clienteViewModel.RendaFamiliar);
        }
    }
}
