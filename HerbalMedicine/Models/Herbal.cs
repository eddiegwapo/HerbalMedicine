using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerbalMedicine.Models
{
    public class Herbal
    {
       

        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Herbal Name")]
        public string HerbalName { get; set; } = string.Empty;

        [StringLength(1000, MinimumLength = 3)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [StringLength(1000, MinimumLength = 3)]
        [Required]
        public string Validity { get; set; } = string.Empty;
        [Display(Name = "Level of Development")]
        public int LevelofDevelopment { get; set; }
    }
}
