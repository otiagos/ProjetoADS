using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestao.Data;
using Gestao.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Pages.CadastrarGato
{
    public class CreateModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public CreateModel(Gestao.Data.GestaoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDropdowns();
            return Page();
        }

        [BindProperty]
        public Gato Gato { get; set; } = default!;
	
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns();
                return Page();
            }

            var cpfLimpo = new string(Gato.CpfTutor!.Where(char.IsDigit).ToArray());
            var tutor = await _context.Tutor.FirstOrDefaultAsync(t => t.CpfTutor == cpfLimpo);

            if (tutor == null)
            {
                ModelState.AddModelError("Gato.CpfTutor", "CPF do tutor inexistente");
            }

            Gato.IdTutor = tutor!.Id;

            _context.Gato.Add(Gato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void PopulateDropdowns()
        {
            ViewData["IdRaca"] = new SelectList(_context.Raca, "Id", "DescricaoRaca");
        }
    }
}
