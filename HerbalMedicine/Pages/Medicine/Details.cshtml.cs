using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HerbalMedicine.Data;
using HerbalMedicine.Models;

namespace HerbalMedicine.Pages.Medicine
{
    public class DetailsModel : PageModel
    {
        private readonly HerbalMedicine.Data.HerbalMedicineContext _context;

        public DetailsModel(HerbalMedicine.Data.HerbalMedicineContext context)
        {
            _context = context;
        }

      public Herbal Herbal { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Herbal == null)
            {
                return NotFound();
            }

            var herbal = await _context.Herbal.FirstOrDefaultAsync(m => m.ID == id);
            if (herbal == null)
            {
                return NotFound();
            }
            else 
            {
                Herbal = herbal;
            }
            return Page();
        }
    }
}
