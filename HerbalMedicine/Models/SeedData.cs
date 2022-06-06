
using Microsoft.EntityFrameworkCore;
using HerbalMedicine.Data;

namespace HerbalMedicine.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HerbalMedicineContext(
                 serviceProvider.GetRequiredService<
                     DbContextOptions<HerbalMedicineContext>>()))
            {
                if (context == null || context.Herbal == null)
                {
                    throw new ArgumentNullException("Null HerbalMedicineContext");
                }

                // Look for any movies.
                if (context.Herbal.Any())
                {
                    return;   // DB has been seeded
                }

                context.Herbal.AddRange(
                    new Herbal
                    {
                        HerbalName = "Oregano(Origanum or Wild Marjoram)",
                        Description = "Oregano is usually grown as a small evergreen subshrub in mild climates. Its compact oval leaves are arranged oppositely and are covered with glandular trichomes (plant hairs). The young stems are typically square and hairy and become woody with age. The flowers are small and borne in clusters; they range in colour from white to pink or pale purple. All varieties contain essential oil, the principal components of which are thymol and carvacrol.",
                        Validity = "cold medicine and cough",
                        LevelofDevelopment = 100,
                    },
                    
                     new Herbal
                     {
                         HerbalName = "moringa",
                         Description = "fast-growing, deciduous tree that can reach a height of 10–12 m (32–40 ft) and trunk diameter of 45 cm (1.5 ft). The bark has a whitish-grey colour and is surrounded by thick cork. Young shoots have purplish or greenish-white, hairy bark.",
                         Validity = "cold medicine and cough",
                         LevelofDevelopment = 100,
                     },
                     new Herbal
                     {
                         HerbalName = "Aloe vera",
                         Description = "Aloe vera, a member of the lily family, is a spiky, succulent, perennial plant. It is indigenous to eastern and southern Africa, but has been spread throughout many of the warmer regions of the world, and is also popularly grown indoors. There are about 300 identified species, but Aloe vera  is the most popular for medical applications. It has also been known as Aloe vulgaris  and Aloe barbadensis. The plant has yellow flowers and triangular, fleshy leaves with serrated edges that arise from a central base and may grow to nearly 2 ft (0.6 m) long. Each leaf is composed of three layers. A clear gel, that is the part of the plant used for topical application is contained within the cells of the generous inner portion. Anthraquinones, which exert a marked laxative effect, are contained in the bitter yellow sap of the middle leaf layer. The fibrous outer part of the leaf serves a protective function.",
                         Validity = "burnt skin, sores, eczema, and skin allergies.",
                         LevelofDevelopment = 100,
                     },

                      new Herbal
                      {
                          HerbalName = "Katakataka",
                          Description = "erect, more or less branched, smooth, succulent herb, 0.4 to 1.4 meters in height. Leaves are simple or pinnately compound, with the leaflets elliptic, usually about 10 centimeters long, thick, succulent, and scalloped margins.",
                           Validity = "For relief of eye styes, heat the katakataka leaf and place it over the affected eye area for 1 minute at least 3 times every day.For headache relief,heat katakataka leaves and place on your forehead for around 10 minutes.To relieve backache or joint pains, heat the leaves and place them on the affected area until the throbbing or aching is alleviated. In treating sprains, burns and infections, pound fresh katakataka leaves and apply to the affected area.With its antiviral characteristics, Katakataka leaves are sometimes boiled to make a warm drink for those with flu or colds. For sore feet, soak your feet in warm water with katakataka leaves",
                          LevelofDevelopment = 100
                      }

                    );

                context.SaveChanges();
            }
        }
    }
}
