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
    public class IndexModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public IndexModel(Gestao.Data.GestaoContext context)
        {
            _context = context;
        }

        public IList<Tutor> Tutor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Tutor = await _context.Tutor.ToListAsync();
        }
    }
}
