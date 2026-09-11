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
    public class DetailsModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public DetailsModel(Gestao.Data.GestaoContext context)
        {
            _context = context;
        }

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
    }
}
