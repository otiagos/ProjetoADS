using System.ComponentModel.DataAnnotations;

namespace Gestao.Models;

public class Raca
{
	public int Id { get; set; }
	
	[Required(ErrorMessage = "O campo Raça é obrigatório")]
	[Display(Name = "Raça:")]
	public string? DescricaoRaca { get; set; }
}
