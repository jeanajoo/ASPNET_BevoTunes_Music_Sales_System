using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Seeding
{
    public static class SeedReviewss
    {
        public static void SeedOrders(AppDbContext db)
        {
            // check to see if all the genres have already been added
            if (db.Reviews.Count() == 12)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Review record count is already 12!");
                throw ex;
            }
            Int32 intReviewsAdded = 0;
            try
            {
                //Create a list of credit cards
                List<Review> Reviews = new List<Review>();

                Review r1 = new Review()
                {
                    Title = "",
                    Description = "Big hook, playful delivery, and a beat that still lands; a fun throwback single.",
                    Rating = 5,
                    Status = ReviewStatus.Approve,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                };

                r1.Approver = db.Users.FirstOrDefault(u => u.FirstName == "Emily" && u.LastName == "Johnson");

                Song songItem1 = db.Songs.FirstOrDefault(s => s.SongTitle == "Ice Ice Baby");
                if (songItem1 != null)
                {
                    r1.Song = songItem1;
                }

                Album albumItem1 = db.Albums.FirstOrDefault(a => a.AlbumName == "Ice Ice Baby");
                if (albumItem1 != null)
                {
                    r1.Album = albumItem1;
                }

                Artist artistItem1 = db.Artists.FirstOrDefault(a => a.ArtistName == "Ice Ice Baby");
                if (artistItem1 != null)
                {
                    r1.Artist = artistItem1;
                }

                Reviews.Add(r1);

                Review r2 = new Review()
                {
                    Title = "",
                    Description = "Energetic remix with punchy beats; a solid update that keeps the groove fresh.",
                    Rating = 5,
                    Status = ReviewStatus.Approve,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                };

                r2.Approver = db.Users.FirstOrDefault(u => u.FirstName == "John" && u.LastName == "Smith");

                Song songItem2 = db.Songs.FirstOrDefault(s => s.SongTitle == "Bootstrap Remix");
                if (songItem2 != null)
                {
                    r2.Song = songItem2;
                }

                Album albumItem2 = db.Albums.FirstOrDefault(a => a.AlbumName == "Bootstrap Remix");
                if (albumItem2 != null)
                {
                    r2.Album = albumItem2;
                }

                Artist artistItem2 = db.Artists.FirstOrDefault(a => a.ArtistName == "Bootstrap Remix");
                if (artistItem2 != null)
                {
                    r2.Artist = artistItem2;
                }

                Reviews.Add(r2);

                Review r3 = new Review()
                {
                    Title = "",
                    Description = "Catchy and recognizable, even if it leans more on nostalgia than depth.",
                    Rating = 3,
                    Status = ReviewStatus.Approve,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                };

                r3.Approver = db.Users.FirstOrDefault(u => u.FirstName == "Michael" && u.LastName == "Williams");

                Song songItem3 = db.Songs.FirstOrDefault(s => s.SongTitle == "Ice Ice Baby");
                if (songItem3 != null)
                {
                    r3.Song = songItem3;
                }

                Album albumItem3 = db.Albums.FirstOrDefault(a => a.AlbumName == "Ice Ice Baby");
                if (albumItem3 != null)
                {
                    r3.Album = albumItem3;
                }

                Artist artistItem3 = db.Artists.FirstOrDefault(a => a.ArtistName == "Ice Ice Baby");
                if (artistItem3 != null)
                {
                    r3.Artist = artistItem3;
                }

                Reviews.Add(r3);

                Review r4 = new Review()
                {
                    Title = "",
                    Description = "Dark trap energy and cold delivery make this track feel gritty and relentless.",
                    Rating = 4,
                    Status = ReviewStatus.Reject,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia"),
                };

                r4.Approver = db.Users.FirstOrDefault(u => u.FirstName == "Stephanie" && u.LastName == "Lopez");

                Song songItem4 = db.Songs.FirstOrDefault(s => s.SongTitle == "No Heart");
                if (songItem4 != null)
                {
                    r4.Song = songItem4;
                }

                Album albumItem4 = db.Albums.FirstOrDefault(a => a.AlbumName == "No Heart");
                if (albumItem4 != null)
                {
                    r4.Album = albumItem4;
                }

                Artist artistItem4 = db.Artists.FirstOrDefault(a => a.ArtistName == "No Heart");
                if (artistItem4 != null)
                {
                    r4.Artist = artistItem4;
                }

                Reviews.Add(r4);

                Review r5 = new Review()
                {
                    Title = "",
                    Description = "Club-ready production and an easy chorus make this one reliably entertaining.",
                    Rating = 4,
                    Status = ReviewStatus.Approve,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                };

                r5.Approver = db.Users.FirstOrDefault(u => u.FirstName == "Sarah" && u.LastName == "Brown");

                Song songItem5 = db.Songs.FirstOrDefault(s => s.SongTitle == "Hot In Herre");
                if (songItem5 != null)
                {
                    r5.Song = songItem5;
                }

                Album albumItem5 = db.Albums.FirstOrDefault(a => a.AlbumName == "Hot In Herre");
                if (albumItem5 != null)
                {
                    r5.Album = albumItem5;
                }

                Artist artistItem5 = db.Artists.FirstOrDefault(a => a.ArtistName == "Hot In Herre");
                if (artistItem5 != null)
                {
                    r5.Artist = artistItem5;
                }

                Reviews.Add(r5);

                Review r6 = new Review()
                {
                    Title = "",
                    Description = "Catchy hook and confident verses; a defining trap anthem of its era.",
                    Rating = 4,
                    Status = ReviewStatus.Approve,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                };

                r6.Approver = db.Users.FirstOrDefault(u => u.FirstName == "Lauren" && u.LastName == "Wilson");

                Song songItem6 = db.Songs.FirstOrDefault(s => s.SongTitle == "Bad and Boujee (feat. Lil Uzi Vert)");
                if (songItem6 != null)
                {
                    r6.Song = songItem6;
                }

                Album albumItem6 = db.Albums.FirstOrDefault(a => a.AlbumName == "Bad and Boujee (feat. Lil Uzi Vert)");
                if (albumItem6 != null)
                {
                    r6.Album = albumItem6;
                }

                Artist artistItem6 = db.Artists.FirstOrDefault(a => a.ArtistName == "Bad and Boujee (feat. Lil Uzi Vert)");
                if (artistItem6 != null)
                {
                    r6.Artist = artistItem6;
                }

                Reviews.Add(r6);

                Review r7 = new Review()
                {
                    Title = "",
                    Description = "Iconic bassline and haunting groove; one of pop’s most unforgettable tracks.",
                    Rating = 4,
                    Status = ReviewStatus.Approve,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                };

                r7.Approver = db.Users.FirstOrDefault(u => u.FirstName == "Ashley" && u.LastName == "Davis");

                Song songItem7 = db.Songs.FirstOrDefault(s => s.SongTitle == "Billie Jean");
                if (songItem7 != null)
                {
                    r7.Song = songItem7;
                }

                Album albumItem7 = db.Albums.FirstOrDefault(a => a.AlbumName == "Billie Jean");
                if (albumItem7 != null)
                {
                    r7.Album = albumItem7;
                }

                Artist artistItem7 = db.Artists.FirstOrDefault(a => a.ArtistName == "Billie Jean");
                if (artistItem7 != null)
                {
                    r7.Artist = artistItem7;
                }

                Reviews.Add(r7);

                Review r8 = new Review()
                {
                    Title = "",
                    Description = "Sharp lyrics and playful attitude; Eminem at his most entertaining.",
                    Rating = 5,
                    Status = ReviewStatus.Approve,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                };

                r8.Approver = db.Users.FirstOrDefault(u => u.FirstName == "Lauren" && u.LastName == "Wilson");

                Song songItem8 = db.Songs.FirstOrDefault(s => s.SongTitle == "Without Me");
                if (songItem8 != null)
                {
                    r8.Song = songItem8;
                }

                Album albumItem8 = db.Albums.FirstOrDefault(a => a.AlbumName == "Without Me");
                if (albumItem8 != null)
                {
                    r8.Album = albumItem8;
                }

                Artist artistItem8 = db.Artists.FirstOrDefault(a => a.ArtistName == "Without Me");
                if (artistItem8 != null)
                {
                    r8.Artist = artistItem8;
                }

                Reviews.Add(r8);

                Review r9 = new Review()
                {
                    Title = "",
                    Description = "High-energy production packed with bold beats and flashy collaborations.",
                    Rating = 4,
                    Status = ReviewStatus.Reject,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                };

                r9.Approver = db.Users.FirstOrDefault(u => u.FirstName == "Daniel" && u.LastName == "Miller");

                Song songItem9 = db.Songs.FirstOrDefault(s => s.SongTitle == "Shock Value");
                if (songItem9 != null)
                {
                    r9.Song = songItem9;
                }

                Album albumItem9 = db.Albums.FirstOrDefault(a => a.AlbumName == "Shock Value");
                if (albumItem9 != null)
                {
                    r9.Album = albumItem9;
                }

                Artist artistItem9 = db.Artists.FirstOrDefault(a => a.ArtistName == "Shock Value");
                if (artistItem9 != null)
                {
                    r9.Artist = artistItem9;
                }

                Reviews.Add(r9);

                Review r10 = new Review()
                {
                    Title = "",
                    Description = "Fast-paced and catchy; the back-and-forth delivery keeps the song moving the whole time.",
                    Rating = 4,
                    Status = ReviewStatus.Pending,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia"),
                };

                Song songItem10 = db.Songs.FirstOrDefault(s => s.SongTitle == "Sprinter");
                if (songItem10 != null)
                {
                    r10.Song = songItem10;
                }

                Album albumItem10 = db.Albums.FirstOrDefault(a => a.AlbumName == "Sprinter");
                if (albumItem10 != null)
                {
                    r10.Album = albumItem10;
                }

                Artist artistItem10 = db.Artists.FirstOrDefault(a => a.ArtistName == "Sprinter");
                if (artistItem10 != null)
                {
                    r10.Artist = artistItem10;
                }

                Reviews.Add(r10);

                Review r11 = new Review()
                {
                    Title = "",
                    Description = "Warm groove, strong rhythm, and an easy chorus make this one an instant repeat.",
                    Rating = 5,
                    Status = ReviewStatus.Pending,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                };

                Song songItem11 = db.Songs.FirstOrDefault(s => s.SongTitle == "Could You Be Loved");
                if (songItem11 != null)
                {
                    r11.Song = songItem11;
                }

                Album albumItem11 = db.Albums.FirstOrDefault(a => a.AlbumName == "Could You Be Loved");
                if (albumItem11 != null)
                {
                    r11.Album = albumItem11;
                }

                Artist artistItem11 = db.Artists.FirstOrDefault(a => a.ArtistName == "Could You Be Loved");
                if (artistItem11 != null)
                {
                    r11.Artist = artistItem11;
                }

                Reviews.Add(r11);

                Review r12 = new Review()
                {
                    Title = "",
                    Description = "The hook is memorable, but the track feels repetitive after a few listens.",
                    Rating = 2,
                    Status = ReviewStatus.Reject,
                    Reviewer = db.Users.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                };

                r12.Approver = db.Users.FirstOrDefault(u => u.FirstName == "David" && u.LastName == "Jones");

                Song songItem12 = db.Songs.FirstOrDefault(s => s.SongTitle == "Hot In Herre");
                if (songItem12 != null)
                {
                    r12.Song = songItem12;
                }

                Album albumItem12 = db.Albums.FirstOrDefault(a => a.AlbumName == "Hot In Herre");
                if (albumItem12 != null)
                {
                    r12.Album = albumItem12;
                }

                Artist artistItem12 = db.Artists.FirstOrDefault(a => a.ArtistName == "Hot In Herre");
                if (artistItem12 != null)
                {
                    r12.Artist = artistItem12;
                }

                Reviews.Add(r12);


                foreach (Review reviewToAdd in Reviews)
                {
                    Review dbReview = db.Reviews.FirstOrDefault(r => r.Description == reviewToAdd.Description);
                    if (dbReview == null)
                    {
                        db.Reviews.Add(reviewToAdd);
                        db.SaveChanges();
                        intReviewsAdded += 1;
                    }
                }

            }
            catch
            {
                String msg = "Reviews Added: " + intReviewsAdded.ToString();
                throw new InvalidOperationException(msg);
            }
        }
    }
}
