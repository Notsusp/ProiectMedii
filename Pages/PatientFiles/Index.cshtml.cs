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
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<PatientFile> PatientFile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PatientFile = await _context.PatientFile
                .Include(p => p.Patient).ToListAsync();
        }
    }
}
