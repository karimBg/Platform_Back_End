using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAuthProj.Data;
using BackendAuthProj.Repository;
using BackEndAuthProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BackendAuthProj.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly IJobRepository _RepositoryData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Job Job { get; set; }

        public IEnumerable<SelectListItem> Department { get; set; }

        public EditModel(IJobRepository repositoryData, 
                         IHtmlHelper htmlHelper)
        {
            _RepositoryData = repositoryData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? jobId)
        {
            Department = htmlHelper.GetEnumSelectList<Department>();
            if(jobId.HasValue) {
                Job = _RepositoryData.GetElementById(jobId.Value);

            } else {
                Job = new Job();
            }
            if(Job == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                Department = htmlHelper.GetEnumSelectList<Department>();
                return Page();
            }

            if(Job.Id > 0) {
                _RepositoryData.Update(Job);
            } else {
                _RepositoryData.Create(Job);
            }
            _RepositoryData.Commit();
            return RedirectToPage("./Details", new { jobId = Job.Id });
        }
    }
}