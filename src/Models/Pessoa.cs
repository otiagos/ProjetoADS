using System.ComponentModel.DataAnnotations;

namespace Gestao.Models;

public abstract class Pessoa
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [Display(Name = "Nome:")]
    public string? Nome { get; set; }
}
