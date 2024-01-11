using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public CreateModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;
        [BindProperty]
        public string PasswordConfirmation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (Doctor.HashedPassword != PasswordConfirmation)
            {
                Debug.WriteLine("This is it222222");
                ModelState.AddModelError("PasswordConfirmation", "The password and confirmation do not match.");
                return Page();
            }

            _context.Doctor.Add(Doctor);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Doctors/Index");
        }
    }
}
