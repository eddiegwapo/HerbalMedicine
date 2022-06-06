using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HerbalMedicine.Data;
using HerbalMedicine.Models;

namespace HerbalMedicine.Pages.Medicine
{
    public class EditModel : PageModel
    {
        private readonly HerbalMedicine.Data.HerbalMedicineContext _context;

        public EditModel(HerbalMedicine.Data.HerbalMedicineContext context)
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

            var herbal =  await _context.Herbal.FirstOrDefaultAsync(m => m.ID == id);
            if (herbal == null)
            {
                return NotFound();
            }
            Herbal = herbal;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Herbal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerbalExists(Herbal.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HerbalExists(int id)
        {
          return (_context.Herbal?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
