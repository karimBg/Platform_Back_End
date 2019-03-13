using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAuthProj.Repository;
using BackEndAuthProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendAuthProj.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositoryData _RepositoryData;

        public Job Job { get; set; }

        public DetailsModel(IRepositoryData repositoryData)
        {
            _RepositoryData = repositoryData;
        }

        public IActionResult OnGet(int jobId)
        {
            Job = _RepositoryData.GetJobById(jobId);
            if(Job == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}