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

namespace Gestao.Pages.CadastrarTutor
{
    public class EditModel : PageModel
    {
        private readonly Gestao.Data.GestaoContext _context;

        public EditModel(Gestao.Data.GestaoContext context)
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

            var tutor =  await _context.Tutor.FirstOrDefaultAsync(m => m.Id == id);
            if (tutor == null)
            {
                return NotFound();
            }
            Tutor = tutor;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var cpfLimpo = new string(Tutor.CpfTutor!.Where(char.IsDigit).ToArray());
            var existe = await _context.Tutor.AnyAsync(t => t.CpfTutor == cpfLimpo && t.Id != Tutor.Id);

            if (existe)
            {
                ModelState.AddModelError("Tutor.CpfTutor", "CPF já cadastrado");
                return Page();
            }

            _context.Attach(Tutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(Tutor.Id))
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

        public async Task<JsonResult> OnGetVerificarCpfDuplicadoAsync(string cpf, int id)
        {
            var cpfLimpo = new string((cpf ?? "").Where(char.IsDigit).ToArray());
            var existe = await _context.Tutor.AnyAsync(t => t.CpfTutor == cpfLimpo && t.Id != id);
            return new JsonResult(new { existe });
        }

        private bool TutorExists(int id)
        {
            return _context.Tutor.Any(e => e.Id == id);
        }
    }
}
