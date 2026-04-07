using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Seeding
{
    public static class SeedPromotions
    {
        public static void SeedAllPromotions(AppDbContext db)
        {
            // check to see if all the genres have already been added
            if (db.Promotions.Count() == 9)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Promotion record count is already 9!");
                throw ex;
            }
            Int32 intPromotionsAdded = 0;
            try
            {
                //Create a list of promotion
                List<Promotion> Promotions = new List<Promotion>();

                Promotion p1 = new Promotion()
                {
                    PromotionType = PromotionType.FEATURED,
                    PromotionActive = true
                };
                p1.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Hacker"));

                Promotion p2 = new Promotion()
                {
                    PromotionType = PromotionType.FEATURED,
                    PromotionActive = false
                };
                p2.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));

                Promotion p3 = new Promotion()
                {
                    PromotionType = PromotionType.FEATURED,
                    PromotionActive = false
                };
                p3.Songs.Add(db.Songs.FirstOrDefault(s => s.SongTitle == "Without Me"));

                Promotion p4 = new Promotion()
                {
                    PromotionType = PromotionType.DISCOUNT,
                    PromotionActive = true
                };
                p4.Songs.Add(db.Songs.FirstOrDefault(s => s.SongTitle == "Another One Bites The Dust - Remastered 2011"));
                p4.DiscountPrice = 1m;

                Promotion p5 = new Promotion()
                {
                    PromotionType = PromotionType.DISCOUNT,
                    PromotionActive = true
                };
                p5.Songs.Add(db.Songs.FirstOrDefault(s => s.SongTitle == "JSON Cipher"));
                p5.DiscountPrice = 1.5m;

                Promotion p6 = new Promotion()
                {
                    PromotionType = PromotionType.DISCOUNT,
                    PromotionActive = true
                };
                p6.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Everybody Loves Ice Prince"));
                p6.DiscountPrice = 4.75m;

                Promotion p7 = new Promotion()
                {
                    PromotionType = PromotionType.DISCOUNT,
                    PromotionActive = true
                };
                p7.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "One of Wun"));
                p7.DiscountPrice = 5.25m;

                Promotion p8 = new Promotion()
                {
                    PromotionType = PromotionType.DISCOUNT,
                    PromotionActive = false
                };
                p8.Songs.Add(db.Songs.FirstOrDefault(s => s.SongTitle == "SQL Anthem"));
                p8.DiscountPrice = 10m;

                Promotion p9 = new Promotion()
                {
                    PromotionType = PromotionType.DISCOUNT,
                    PromotionActive = false
                };
                p9.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                p9.DiscountPrice = 10m;


                foreach (Promotion promotionToAdd in Promotions)
                {
                    Promotion dbPromotion = db.Promotions.FirstOrDefault();
                    if (dbPromotion == null)
                    {
                        db.Promotions.Add(dbPromotion);
                        db.SaveChanges();
                        intPromotionsAdded += 1;
                    }
                }

            }
            catch
            {
                String msg = "Promotions Added: " + intPromotionsAdded.ToString();
                throw new InvalidOperationException(msg);
            }
        }
    }
}
