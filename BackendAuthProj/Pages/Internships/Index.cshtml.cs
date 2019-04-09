using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackEndAuthProj.Models;
using BackendAuthProj.Data;
using Microsoft.AspNetCore.Authorization;

namespace BackendAuthProj.Pages.Internships
{
    public class IndexModel : PageModel
    {
        private readonly BackendAuthProj.Data.AppDbContext _context;

        public IndexModel(BackendAuthProj.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Internship> Internship { get;set; }

        public async Task OnGetAsync()
        {
            Internship = await _context.Internships.ToListAsync();
        }
    }
}
