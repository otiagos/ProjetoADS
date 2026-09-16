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
        private readonly GestaoContext _context;
        private readonly Services.TutorService _tutorService;

        public EditModel(Gestao.Data.GestaoContext context, Services.TutorService tutorService)
        {
            _context = context;
            _tutorService = tutorService;
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

            var tutor = await _tutorService.BuscarPorCpfAsync(Gato.CpfTutor);

            if (tutor == null)
            {
                ModelState.AddModelError("Gato.CpfTutor", "Tutor não encontrado com o CPF informado");
                PopulateDropdowns();
                return Page();
            }

            Gato.IdTutor = tutor.Id;

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
            var tutor = await _tutorService.BuscarPorCpfAsync(cpf);
            return new JsonResult(new { existe = tutor != null });
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
