using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestao.Data;
using Gestao.Models;

namespace Gestao.Pages.CadastrarGato
{
    public class IndexModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public IndexModel(Gestao.Data.GestaoContext context)
        {
            _context = context;
        }

        public IList<Gato> Gato { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Gato = await _context.Gato.Include(g => g.Raca).ToListAsync();
        }
    }
}
