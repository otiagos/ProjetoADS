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
    public class DeleteModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public DeleteModel(Gestao.Data.GestaoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gato Gato { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gato = await _context.Gato.Include(g => g.Raca).
                FirstOrDefaultAsync(m => m.Id == id);

            if (gato is not null)
            {
                Gato = gato;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gato = await _context.Gato.FindAsync(id);
            if (gato != null)
            {
                Gato = gato;
                _context.Gato.Remove(Gato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
