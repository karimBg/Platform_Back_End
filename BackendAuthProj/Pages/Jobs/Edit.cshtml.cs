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
        private readonly IRepositoryData _RepositoryData;
        private readonly IHtmlHelper htmlHelper;
        private readonly UserManager<UserDb> _userManager;
        private readonly SignInManager<UserDb> _signInManager;

        [BindProperty]
        public Job Job { get; set; }

        public IEnumerable<SelectListItem> Department { get; set; }

        public EditModel(IRepositoryData repositoryData, 
                         IHtmlHelper htmlHelper,
                         UserManager<UserDb> userManager,
                         SignInManager<UserDb> signInManager)
        {
            _RepositoryData = repositoryData;
            this.htmlHelper = htmlHelper;
            this._userManager = userManager;
            this._signInManager = signInManager;
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