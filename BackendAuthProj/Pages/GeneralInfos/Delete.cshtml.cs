using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BackEndAuthProj.Models;
using BackendAuthProj.Data;
using BackendAuthProj.Repository;

namespace BackendAuthProj.Pages.GeneralInfos
{
    public class DeleteModel : PageModel
    {
        private readonly IInfoRepository _infoRepository;

        [BindProperty]
        public GeneralInfo GeneralInfo { get; set; }

        public DeleteModel(IInfoRepository infoRepository)
        {
            this._infoRepository = infoRepository;
        }

        public IActionResult OnGet(int infoId)
        {
            GeneralInfo = _infoRepository.GetElementById(infoId);
            if(GeneralInfo == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int infoId)
        {
            var deletedInfo = _infoRepository.Delete(infoId);
            _infoRepository.Commit();
            if(deletedInfo == null) {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"General Info with id: { deletedInfo.Id } Deleted!";
            return RedirectToPage("./Index");
        }
    }
}
