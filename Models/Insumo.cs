using System.ComponentModel.DataAnnotations;

namespace Gestao.Models;

public abstract class Insumo
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Nome:")]
    public string? Nome { get; set; }
}