using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestao.Data;
using Gestao.Models;

namespace Gestao.Pages.CadastrarTutor
{
    public class DeleteModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public DeleteModel(Gestao.Data.GestaoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tutor Tutor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutor.FirstOrDefaultAsync(m => m.Id == id);

            if (tutor is not null)
            {
                Tutor = tutor;

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

            var tutor = await _context.Tutor.FindAsync(id);
            if (tutor != null)
            {
                Tutor = tutor;
                _context.Tutor.Remove(Tutor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
