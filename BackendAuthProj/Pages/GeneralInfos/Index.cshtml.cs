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
using Microsoft.AspNetCore.Authorization;

namespace BackendAuthProj.Pages.GeneralInfos
{
    public class IndexModel : PageModel
    {
        private readonly IInfoRepository _infoRepository;

        public IList<GeneralInfo> Infos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(IInfoRepository infoRepository)
        {
            this._infoRepository = infoRepository;
        }

        public IActionResult OnGet()
        {
            Infos = _infoRepository.GetElementByLocation(SearchTerm).ToList();
            return Page();
        }
    }
}
