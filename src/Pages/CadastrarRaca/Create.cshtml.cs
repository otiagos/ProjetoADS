using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestao.Data;
using Gestao.Models;

namespace Gestao.Pages.CadastrarRaca
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
            return Page();
        }

        [BindProperty]
        public Raca Raca { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Raca.Add(Raca);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
