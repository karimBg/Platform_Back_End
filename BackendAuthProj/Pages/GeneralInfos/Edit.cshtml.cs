using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackEndAuthProj.Models;
using BackendAuthProj.Data;
using BackendAuthProj.Repository;

namespace BackendAuthProj.Pages.GeneralInfos
{
    public class EditModel : PageModel
    {
        private readonly IInfoRepository _infoRepository;

        [BindProperty]
        public GeneralInfo GeneralInfo { get; set; }

        public EditModel(IInfoRepository infoRepository)
        {
            this._infoRepository = infoRepository;
        }

        public IActionResult OnGet(int InfoId)
        {
            GeneralInfo = _infoRepository.GetElementById(InfoId);
            if (GeneralInfo == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid) {
                _infoRepository.Update(GeneralInfo);
                _infoRepository.Commit();
                return RedirectToPage("./Details", new { infoId = GeneralInfo.Id });
            }
            return Page();
        }
    }
}
