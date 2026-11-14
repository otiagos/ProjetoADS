using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestao.Data;
using Gestao.Models;

namespace Gestao.Pages.CadastrarTutor
{
    public class CreateModel : PageModel
    {
        private readonly GestaoContext _context;
        private readonly Services.TutorService _tutorService;

        public CreateModel(GestaoContext context, Services.TutorService tutorService)
        {
            _context = context;
            _tutorService = tutorService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tutor Tutor { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var tutor = await _tutorService.BuscarPorCpfAsync(Tutor.CpfTutor);
            if (tutor != null)
            {
                ModelState.AddModelError("Tutor.CpfTutor", "CPF já está cadastrado");
                return Page();
            }

            _context.Tutor.Add(Tutor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
