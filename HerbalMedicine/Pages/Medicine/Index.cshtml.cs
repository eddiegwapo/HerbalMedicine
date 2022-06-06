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
#pragma warning disable CS8618
#pragma warning disable CS8604
    public class IndexModel : PageModel
    {
        private readonly HerbalMedicine.Data.HerbalMedicineContext _context;

        public IndexModel(HerbalMedicine.Data.HerbalMedicineContext context)
        {
            _context = context;
        }

        public IList<Herbal> Herbal { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList HerbalName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Herbalname { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Herbal
                                            orderby m.HerbalName
                                            select m.HerbalName;

            var Medicine = from m in _context.Herbal
                           select m;


            if (!string.IsNullOrEmpty(SearchString))
            {
                Medicine = Medicine.Where(s => s.HerbalName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(Herbalname))

   
            {
                Medicine = Medicine.Where(x => x.HerbalName == Herbalname);
            }
           HerbalName = new SelectList(await genreQuery.Distinct().ToListAsync());
            Herbal = await Medicine.ToListAsync();
        }

            
#pragma warning restore CS8618
#pragma warning restore CS8604
    }
}
