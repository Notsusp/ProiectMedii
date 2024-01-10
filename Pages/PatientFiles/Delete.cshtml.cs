using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.PatientFiles
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DeleteModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PatientFile PatientFile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientfile = await _context.PatientFile.FirstOrDefaultAsync(m => m.Id == id);

            if (patientfile == null)
            {
                return NotFound();
            }
            else
            {
                PatientFile = patientfile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientfile = await _context.PatientFile.FindAsync(id);
            if (patientfile != null)
            {
                PatientFile = patientfile;
                _context.PatientFile.Remove(PatientFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
