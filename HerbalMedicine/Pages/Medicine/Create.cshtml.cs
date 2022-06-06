using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HerbalMedicine.Data;
using HerbalMedicine.Models;

namespace HerbalMedicine.Pages.Medicine
{
    public class CreateModel : PageModel
    {
        private readonly HerbalMedicine.Data.HerbalMedicineContext _context;

        public CreateModel(HerbalMedicine.Data.HerbalMedicineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Herbal Herbal { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Herbal == null || Herbal == null)
            {
                return Page();
            }

            _context.Herbal.Add(Herbal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
