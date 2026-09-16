using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Gestao.Data;
using Gestao.Models;

namespace Gestao.Services;

public class TutorService
{
    private readonly GestaoContext _context;

    public TutorService(GestaoContext context)
    {
        _context = context;
    }

    public async Task<Tutor?> BuscarPorCpfAsync(string? cpf)
    {
        var cpfLimpo = Limpar(cpf);
        return await _context.Tutor.FirstOrDefaultAsync(t => t.CpfTutor == cpfLimpo);
    }

    private static string Limpar(string? cpf) => 
        new string((cpf ?? "").Where(char.IsDigit).ToArray());
}