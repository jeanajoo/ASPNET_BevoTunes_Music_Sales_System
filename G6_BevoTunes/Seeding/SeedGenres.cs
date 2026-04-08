using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Seeding
{
    public static class SeedGenres
    {
        public static void SeedAllGenres(AppDbContext db)
        {
            // check to see if all the genres have already been added
            if (db.Genres.Count() == 16)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Genre record count is already 16!");
                throw ex;
            }
            Int32 intGenresAdded = 0;
            try
            {
                //Create a list of languages
                List<Genre> Genres = new List<Genre>();

                Genre g1 = new Genre() { GenreId = 4001, GenreName = "pop" };
                Genres.Add(g1);

                Genre g2 = new Genre() { GenreId = 4002, GenreName = "hip-hop" };
                Genres.Add(g2);

                Genre g3 = new Genre() { GenreId = 4003, GenreName = "arabic" };
                Genres.Add(g3);

                Genre g4 = new Genre() { GenreId = 4004, GenreName = "brazilian" };
                Genres.Add(g4);

                Genre g5 = new Genre() { GenreId = 4005, GenreName = "electronic" };
                Genres.Add(g5);

                Genre g6 = new Genre() { GenreId = 4006, GenreName = "gaming" };
                Genres.Add(g6);

                Genre g7 = new Genre() { GenreId = 4007, GenreName = "latin" };
                Genres.Add(g7);

                Genre g8 = new Genre() { GenreId = 4008, GenreName = "rock" };
                Genres.Add(g8);

                Genre g9 = new Genre() { GenreId = 4009, GenreName = "reggae" };
                Genres.Add(g9);

                Genre g10 = new Genre() { GenreId = 4010, GenreName = "r&b" };
                Genres.Add(g10);

                Genre g11 = new Genre() { GenreId = 4011, GenreName = "afrobeats" };
                Genres.Add(g11);

                Genre g12 = new Genre() { GenreId = 4012, GenreName = "ambient" };
                Genres.Add(g12);

                Genre g13 = new Genre() { GenreId = 4013, GenreName = "soca" };
                Genres.Add(g13);

                Genre g14 = new Genre() { GenreId = 4014, GenreName = "lofi" };
                Genres.Add(g14);

                Genre g15 = new Genre() { GenreId = 4015, GenreName = "world" };
                Genres.Add(g15);

                Genre g16 = new Genre() { GenreId = 4016, GenreName = "classroom" };
                Genres.Add(g16);

                foreach (Genre genreToAdd in Genres)
                {
                    Genre dbGenre = db.Genres.FirstOrDefault(g => g.GenreName == genreToAdd.GenreName);
                    if (dbGenre == null)
                    {
                        db.Genres.Add(genreToAdd);
                        db.SaveChanges();
                        intGenresAdded += 1;
                    }
                }
            }
            catch
            {
                String msg = "Genres Added: " + intGenresAdded.ToString();
                throw new InvalidOperationException(msg);
            }
        }
    }
}
