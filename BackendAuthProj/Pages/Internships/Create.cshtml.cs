using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BackEndAuthProj.Models;
using BackendAuthProj.Data;

namespace BackendAuthProj.Pages.Internships
{
    public class CreateModel : PageModel
    {
        private readonly BackendAuthProj.Data.AppDbContext _context;

        public CreateModel(BackendAuthProj.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Internship Internship { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Internships.Add(Internship);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}