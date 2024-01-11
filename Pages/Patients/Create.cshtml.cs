using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;
        [BindProperty]
        public Patient Patient { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }


        public CreateModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            

            if (Patient.HashedPassword != ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Password and confirmation do not match.");
                return Page();
            }

            _context.Patient.Add(Patient);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Patients/Index");
        }
    }
}
