using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestao.Data;
using Gestao.Models;

namespace Gestao.Pages.CadastrarRaca
{
    public class EditModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public EditModel(Gestao.Data.GestaoContext context)
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

            var raca =  await _context.Raca.FirstOrDefaultAsync(m => m.Id == id);
            if (raca == null)
            {
                return NotFound();
            }
            Raca = raca;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Raca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacaExists(Raca.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RacaExists(int id)
        {
            return _context.Raca.Any(e => e.Id == id);
        }
    }
}
