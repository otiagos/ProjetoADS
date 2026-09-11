using System.ComponentModel.DataAnnotations;

namespace Gestao.Models.Validacoes;

public class CpfValidoAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        var cpf = value as string;
        if (string.IsNullOrWhiteSpace(cpf))
            return ValidationResult.Success;

        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
            return new ValidationResult(ErrorMessage ?? "CPF inválido");

        int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var parcial = cpf[..9];
        var soma = parcial.Select((c, i) => (c - '0') * mult1[i]).Sum();
        var resto = soma % 11;
        var digito1 = resto < 2 ? 0 : 11 - resto;

        parcial += digito1;
        soma = parcial.Select((c, i) => (c - '0') * mult2[i]).Sum();

        resto = soma % 11;
        var digito2 = resto < 2 ? 0 : 11 - resto;

        return cpf.EndsWith($"{digito1}{digito2}")
            ? ValidationResult.Success
            : new ValidationResult(ErrorMessage ?? "CPF inválido");
    }
}
