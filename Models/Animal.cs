using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Gestao.Models;

public abstract class Animal
{
	public int Id { get; set; }

	public int IdTutor { get; set; } // É uma foreign Key, para não esquecer  

	[ValidateNever]
	public Tutor Tutor { get; set; } = null!;
}
