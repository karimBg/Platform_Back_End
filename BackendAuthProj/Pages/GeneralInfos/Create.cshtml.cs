using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BackEndAuthProj.Models;
using BackendAuthProj.Data;
using BackendAuthProj.Repository;

namespace BackendAuthProj.Pages.GeneralInfos
{
    public class CreateModel : PageModel
    {
        private readonly IInfoRepository _infoRepository;

        [BindProperty]
        public GeneralInfo GeneralInfo { get; set; }

        public CreateModel(IInfoRepository infoRepository)
        {
            this._infoRepository = infoRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid) {
                _infoRepository.Create(GeneralInfo);
                _infoRepository.Commit();
                return RedirectToPage("./Details", new { InfoId = GeneralInfo.Id });
            }
            TempData["Message"] = "Information Saved!";
            return Page();
        }
    }
}