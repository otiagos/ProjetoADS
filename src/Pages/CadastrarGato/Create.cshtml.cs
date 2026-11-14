using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestao.Data;
using Gestao.Models;
using Gestao.Services;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Pages.CadastrarGato
{
    public class CreateModel : PageModel
    {
        private readonly GestaoContext _context;
        private readonly TutorService _tutorService;
        
        public CreateModel(GestaoContext context, TutorService tutorService)
        {
            _context = context;
            _tutorService = tutorService;
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

            var tutor = await _tutorService.BuscarPorCpfAsync(Gato.CpfTutor);
            if (tutor == null)
            {
                ModelState.AddModelError("Gato.CpfTutor", "Tutor não cadastrado com o CPF informado");
                PopulateDropdowns();
                return Page();
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
