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
    public class DetailsModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public DetailsModel(Gestao.Data.GestaoContext context)
        {
            _context = context;
        }

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
    }
}
