using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;

        public async Task OnGetAsync(string searchName)
        {
            IQueryable<Patient> patientsQuery = _context.Patients;

            if (!string.IsNullOrEmpty(searchName))
            {
                // Filter by patient name
                patientsQuery = patientsQuery.Where(p =>
                    p.FirstName.Contains(searchName) ||
                    p.LastName.Contains(searchName));
            }

            Patient = await patientsQuery.ToListAsync();

        }
    }
}
