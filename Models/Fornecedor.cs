using System.ComponentModel.DataAnnotations;

namespace Gestao.Models;

public class Fornecedor : Pessoa
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    // Criar validação para CNPJ, assim como foi feito com o CPF
    [Display(Name = "CNPJ:")]
    public string cnpj { get; set; }
    
    [Display(Name = "Endereço:")]
    public string? endereco { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Telefone:")]
    public string? telefone { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido")]
    [Display(Name = "E-mail:")]
    public string? email { get; set; }
    
    // Criar uma coleção de Insumo para Fornecedor, uma vez que fornecedor fornece insumos
}