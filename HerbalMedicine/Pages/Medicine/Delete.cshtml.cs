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
    public class DeleteModel : PageModel
    {
        private readonly HerbalMedicine.Data.HerbalMedicineContext _context;

        public DeleteModel(HerbalMedicine.Data.HerbalMedicineContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Herbal == null)
            {
                return NotFound();
            }
            var herbal = await _context.Herbal.FindAsync(id);

            if (herbal != null)
            {
                Herbal = herbal;
                _context.Herbal.Remove(Herbal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
