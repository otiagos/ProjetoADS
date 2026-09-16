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

namespace Gestao.Pages.CadastrarGato
{
    public class EditModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public EditModel(Gestao.Data.GestaoContext context)
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

            var gato =  await _context.Gato.FirstOrDefaultAsync(m => m.Id == id);
            if (gato == null)
            {
                return NotFound();
            }
	        PopulateDropdowns();

            Gato = gato;

            return Page();
        }

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
                ModelState.AddModelError("Gato.CpfTutor", "Não foi encontrado nenhum tutor com este CPF");
                PopulateDropdowns();
                return Page();
            }

            Gato.Id = tutor.Id;

            _context.Attach(Gato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GatoExists(Gato.Id))
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

        public async Task<JsonResult> OnGetVerificarTutorExisteAsync(string cpf)
        {
            var cpfLimpo = new string((cpf ?? "").Where(char.IsDigit).ToArray());
            var existe = _context.Tutor.AnyAsync(t => t.CpfTutor == cpfLimpo);
            return new JsonResult(new { existe });
        }

        private bool GatoExists(int id)
        {
            return _context.Gato.Any(e => e.Id == id);
        }

	    private void PopulateDropdowns()
	    {
	        ViewData["IdRaca"] = new SelectList(_context.Raca, "Id", "DescricaoRaca");
	    }
    }
}
