using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAuthProj.Data;
using BackendAuthProj.Repository;
using BackEndAuthProj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendAuthProj.Pages.Jobs
{
    [Authorize]
    public class ListModel : PageModel
    {
        private readonly IJobRepository _repositoryData;

        public IEnumerable<Job> Jobs { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IJobRepository repositoryData)
        {
            this._repositoryData = repositoryData;
        }

        public IActionResult OnGet()
        {
            Jobs = _repositoryData.GetElementByTitle(SearchTerm);
            return Page();
        }
    }
}