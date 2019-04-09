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
    public class DetailsModel : PageModel
    {
        private readonly IInfoRepository _infoRepository;

        public GeneralInfo GeneralInfo { get; set; }

        [TempData]
        public string Message { get; set; }

        public DetailsModel(IInfoRepository infoRepository)
        {
            this._infoRepository = infoRepository;
        }

        public IActionResult OnGet(int InfoId)
        {
            GeneralInfo = _infoRepository.GetElementById(InfoId);
            if(GeneralInfo == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
