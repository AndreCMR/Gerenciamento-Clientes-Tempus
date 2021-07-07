using GerenciamentoClientes.Dominio.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoClientes.Historias.ClienteHistoria.ViewModels
{
    public class ClienteViewModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [MaxLength(1500)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [DisplayName("Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Data de cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [DisplayName("Renda Familiar")]
        public decimal RendaFamiliar { get; set; }

        public static implicit operator Cliente(ClienteViewModel clienteViewModel)
        {
            return new Cliente(
                id: clienteViewModel.Id,
                nome: clienteViewModel.Nome,
                cpf: clienteViewModel.CPF,
                dataNascimento: clienteViewModel.DataNascimento,
                dataCadastro: clienteViewModel.DataCadastro,
                rendaFamiliar: clienteViewModel.RendaFamiliar);
        }

        public static implicit operator ClienteViewModel(Cliente cliente)
        {
            return new ClienteViewModel {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                DataNascimento = cliente.DataNascimento,
                DataCadastro = cliente.DataCadastro,
                RendaFamiliar = cliente.RendaFamiliar
            };
        }
    }
}



