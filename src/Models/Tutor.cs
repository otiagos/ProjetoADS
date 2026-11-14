using System.ComponentModel.DataAnnotations;
using Gestao.Models.Validacoes;

namespace Gestao.Models;

public class Tutor : Pessoa
{
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	[CpfValido(ErrorMessage = "CPF inválido")]
	[Display(Name = "CPF Tutor")]
	public string? CpfTutor { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	[Display(Name = "Telefone")]
	public string? Telefone { get; set; }

	[Display(Name = "Endereço")]
	public string? Endereco { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	[Display(Name = "Data de Nascimento")]
	[DataType(DataType.Date)]
	public DateTime DataNascimento { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	[EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido")]
	[Display(Name = "E-mail")]
	public string? Email { get; set; }

	public ICollection<Animal> Animais { get; set; } = new List<Animal>();
}
