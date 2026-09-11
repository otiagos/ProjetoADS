using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestao.Models;

public class Gato : Animal
{
	[Display(Name = "CPF Tutor:")]
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string? CpfTutor { get; set; }

	[Display(Name = "Nome:")]
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public string? Nome { get; set; }

	[Display(Name = "Idade:")]
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public int Idade { get; set; }

	[Display(Name = "Data de Nascimento:")]
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	[DataType(DataType.Date)]
	public DateTime DataNascimento { get; set; }
	
	[Display(Name = "Raça:")]
	[Range(1, int.MaxValue, ErrorMessage = "Selecione uma raça")]
	public int IdRaca { get; set; }

	[ValidateNever]
	public Raca Raca { get; set; } = null!;
}
