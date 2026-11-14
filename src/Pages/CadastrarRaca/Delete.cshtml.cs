using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestao.Data;
using Gestao.Models;

namespace Gestao.Pages.CadastrarRaca
{
    public class DeleteModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public DeleteModel(Gestao.Data.GestaoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Raca Raca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raca = await _context.Raca.FirstOrDefaultAsync(m => m.Id == id);

            if (raca is not null)
            {
                Raca = raca;

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

            var raca = await _context.Raca.FindAsync(id);
            if (raca != null)
            {
                Raca = raca;
                _context.Raca.Remove(Raca);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
