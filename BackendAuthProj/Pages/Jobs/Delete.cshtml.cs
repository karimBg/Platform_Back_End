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
    public class DeleteModel : PageModel
    {
        private readonly IJobRepository _jobRepository;

        public Job Job { get; set; }

        public DeleteModel(IJobRepository jobRepository)
        {
            this._jobRepository = jobRepository;
        }

        public IActionResult OnGet(int jobId)
        {
            Job = _jobRepository.GetElementById(jobId);
            if(Job == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int jobId)
        {
            var deletedJob = _jobRepository.Delete(jobId);
            _jobRepository.Commit();
            if(deletedJob == null) {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"Job Offer: { deletedJob.Title } Deleted!";
            return RedirectToPage("./List");
        }
    }
}