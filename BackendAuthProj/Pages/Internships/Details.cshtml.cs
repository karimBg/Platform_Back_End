using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackEndAuthProj.Models;
using BackendAuthProj.Data;

namespace BackendAuthProj.Pages.Internships
{
    public class DetailsModel : PageModel
    {
        private readonly BackendAuthProj.Data.AppDbContext _context;

        public DetailsModel(BackendAuthProj.Data.AppDbContext context)
        {
            _context = context;
        }

        public Internship Internship { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Internship = await _context.Internships.FirstOrDefaultAsync(m => m.Id == id);

            if (Internship == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
