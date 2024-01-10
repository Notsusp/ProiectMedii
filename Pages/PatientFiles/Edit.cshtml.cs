using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.PatientFiles
{
    public class EditModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public EditModel(ProiectMedii.Data.ProiectMediiContext context)
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

            var patientfile =  await _context.PatientFile.FirstOrDefaultAsync(m => m.Id == id);
            if (patientfile == null)
            {
                return NotFound();
            }
            PatientFile = patientfile;
           ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PatientFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientFileExists(PatientFile.Id))
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

        private bool PatientFileExists(int id)
        {
            return _context.PatientFile.Any(e => e.Id == id);
        }
    }
}
