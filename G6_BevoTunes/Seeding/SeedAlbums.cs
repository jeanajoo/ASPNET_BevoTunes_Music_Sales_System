using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Seeding
{
    public static class SeedAlbums
    {
        public static void SeedAllAlbums(AppDbContext db)
        {
            // check to see if all the genres have already been added
            if (db.Albums.Count() == 114)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Album record count is already 114!");
                throw ex;
            }
            Int32 intAlbumsAdded = 0;
            try
            {
                //Create a list of album
                List<Album> Albums = new List<Album>();

                Album a1 = new Album()
                {
                    AlbumName = "Vanilla Ice Is Back! - Hip Hop Classics",
                    AlbumPrice = 8m,
                    AlbumCover = "https://images.unsplash.com/photo-1587731556938-38755b4803a6?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YWxidW0lMjBjb3ZlcnN8ZW58MHx8MHx8fDA%3D"
                };
                a1.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Vanilla Ice"));
                a1.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Roddy Ricch"));
                a1.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a1.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a1.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Albums.Add(a1);

                Album a2 = new Album()
                {
                    AlbumName = "Shock Value",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1711054824441-064a99073a0b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8YWxidW0lMjBjb3ZlcnN8ZW58MHx8MHx8fDA%3D"
                };
                a2.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Timbaland"));
                a2.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a2.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Albums.Add(a2);

                Album a3 = new Album()
                {
                    AlbumName = "Alligator Bites Never Heal",
                    AlbumPrice = 12m,
                    AlbumCover = "https://images.unsplash.com/photo-1598909688344-fbe5e6d4c869?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YWxidW0lMjBjb3ZlcnN8ZW58MHx8MHx8fDA%3D"
                };
                a3.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Doechii"));
                a3.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a3);

                Album a4 = new Album()
                {
                    AlbumName = "Quality Control: Control The Streets Volume 2",
                    AlbumPrice = 6m,
                    AlbumCover = "https://images.unsplash.com/photo-1632667113863-24e85951b9d3?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YWxidW0lMjBjb3ZlcnN8ZW58MHx8MHx8fDA%3D"
                };
                a4.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Quality Control"));
                a4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Albums.Add(a4);

                Album a5 = new Album()
                {
                    AlbumName = "Still Rollin",
                    AlbumPrice = 15m,
                    AlbumCover = "https://images.unsplash.com/photo-1590310182704-037fe3509ada?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YWxidW0lMjBjb3ZlcnN8ZW58MHx8MHx8fDA%3D"
                };
                a5.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Shubh"));
                a5.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Fireboy DML"));
                a5.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a5.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a5.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a5);

                Album a6 = new Album()
                {
                    AlbumName = "Harder Than Ever",
                    AlbumPrice = 14m,
                    AlbumCover = "https://images.unsplash.com/photo-1761814684971-fa0e7fd606e2?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8YWxidW0lMjBjb3ZlcnN8ZW58MHx8MHx8fDA%3D"
                };
                a6.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Baby"));
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Albums.Add(a6);

                Album a7 = new Album()
                {
                    AlbumName = "My Turn (Deluxe)",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1579791237963-790a2d836a08?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a7.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Baby"));
                a7.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a7.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a7.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Albums.Add(a7);

                Album a8 = new Album()
                {
                    AlbumName = "Se Voce Nao Quer Passa a Vez",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1644855640845-ab57a047320e?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a8.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Delux"));
                a8.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a8);

                Album a9 = new Album()
                {
                    AlbumName = "Homework",
                    AlbumPrice = 9m,
                    AlbumCover = "https://images.unsplash.com/photo-1737111869062-c96a5514cc08?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a9.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Daft Punk"));
                a9.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Albums.Add(a9);

                Album a10 = new Album()
                {
                    AlbumName = "Nellyville",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1629923759854-156b88c433aa?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a10.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Nelly"));
                a10.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a10.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a10.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Albums.Add(a10);

                Album a11 = new Album()
                {
                    AlbumName = "The Trinity",
                    AlbumPrice = 22m,
                    AlbumCover = "https://images.unsplash.com/photo-1612982663544-54e9d6d2818d?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a11.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Sean Paul"));
                a11.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a11.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Albums.Add(a11);

                Album a12 = new Album()
                {
                    AlbumName = "Ela Joga na Hora",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1566424190930-2956a3735219?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a12.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Pogba"));
                a12.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a12.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Albums.Add(a12);

                Album a13 = new Album()
                {
                    AlbumName = "Artist",
                    AlbumPrice = 13m,
                    AlbumCover = "https://images.unsplash.com/photo-1614283868067-b4e06385bf93?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a13.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "A Boogie Wit da Hoodie"));
                a13.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Cazzu"));
                a13.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a13.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a13.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a13.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a13);

                Album a14 = new Album()
                {
                    AlbumName = "Lovin On Me",
                    AlbumPrice = 14m,
                    AlbumCover = "https://images.unsplash.com/photo-1693434998054-2784e49ca563?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTl8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a14.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jack Harlow"));
                a14.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gunna"));
                a14.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a14.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Albums.Add(a14);

                Album a15 = new Album()
                {
                    AlbumName = "Que Se Cuide",
                    AlbumPrice = 12m,
                    AlbumCover = "https://images.unsplash.com/photo-1517883074437-df05bd218272?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fGFsYnVtJTIwY292ZXJzfGVufDB8fDB8fHww"
                };
                a15.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Luis R Conriquez"));
                a15.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Problem Child"));
                a15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a15);

                Album a16 = new Album()
                {
                    AlbumName = "Houdini",
                    AlbumPrice = 20m,
                    AlbumCover = "https://images.unsplash.com/flagged/photo-1572392640988-ba48d1a74457?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YXJ0fGVufDB8fDB8fHww"
                };
                a16.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Eminem"));
                a16.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a16.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a16.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Albums.Add(a16);

                Album a17 = new Album()
                {
                    AlbumName = "Bootlegs And B-Sides",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1579783902614-a3fb3927b6a5?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8YXJ0fGVufDB8fDB8fHww"
                };
                a17.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Ice Cube"));
                a17.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a17);

                Album a18 = new Album()
                {
                    AlbumName = "The Game (Deluxe Remastered Version)",
                    AlbumPrice = 15m,
                    AlbumCover = "https://images.unsplash.com/photo-1547891654-e66ed7ebb968?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8YXJ0fGVufDB8fDB8fHww"
                };
                a18.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Queen"));
                a18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a18);

                Album a19 = new Album()
                {
                    AlbumName = "Confrontation",
                    AlbumPrice = 16m,
                    AlbumCover = "https://images.unsplash.com/photo-1578301978018-3005759f48f7?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8YXJ0fGVufDB8fDB8fHww"
                };
                a19.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bob Marley & The Wailers"));
                a19.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Delux"));
                a19.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a19.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a19.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a19);

                Album a20 = new Album()
                {
                    AlbumName = "Culture",
                    AlbumPrice = 8m,
                    AlbumCover = "https://images.unsplash.com/photo-1515405295579-ba7b45403062?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8YXJ0fGVufDB8fDB8fHww"
                };
                a20.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Migos"));
                a20.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a20);

                Album a21 = new Album()
                {
                    AlbumName = "Si Antes Te Hubiera Conocido",
                    AlbumPrice = 21m,
                    AlbumCover = "https://images.unsplash.com/photo-1460661419201-fd4cecdf8a8b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8YXJ0fGVufDB8fDB8fHww"
                };
                a21.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "KAROL G"));
                a21.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a21.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Albums.Add(a21);

                Album a22 = new Album()
                {
                    AlbumName = "Split Decision",
                    AlbumPrice = 13m,
                    AlbumCover = "https://images.unsplash.com/photo-1605721911519-3dfeb3be25e7?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a22.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dave"));
                a22.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "G:sson"));
                a22.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a22.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a22);

                Album a23 = new Album()
                {
                    AlbumName = "?",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1579762715118-a6f1d4b934f1?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a23.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "XXXTENTACION"));
                a23.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a23.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a23.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a23);

                Album a24 = new Album()
                {
                    AlbumName = "Thriller 25 Super Deluxe Edition",
                    AlbumPrice = 10m,
                    AlbumCover = "https://images.unsplash.com/photo-1579541814924-49fef17c5be5?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a24.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Michael Jackson"));
                a24.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Albums.Add(a24);

                Album a25 = new Album()
                {
                    AlbumName = "Lil Boat 3.5",
                    AlbumPrice = 20m,
                    AlbumCover = "https://images.unsplash.com/photo-1577083165633-14ebcdb0f658?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a25.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Yachty"));
                a25.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a25.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Albums.Add(a25);

                Album a26 = new Album()
                {
                    AlbumName = "Faz um Vuk Vuk (Teto Espelhado)",
                    AlbumPrice = 9m,
                    AlbumCover = "https://images.unsplash.com/photo-1536924940846-227afb31e2a5?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a26.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Kevin o Chris"));
                a26.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a26.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a26.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Albums.Add(a26);

                Album a27 = new Album()
                {
                    AlbumName = "ATLiens",
                    AlbumPrice = 25m,
                    AlbumCover = "https://images.unsplash.com/photo-1577084381380-3b9ea4153664?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a27.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Outkast"));
                a27.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a27.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Albums.Add(a27);

                Album a28 = new Album()
                {
                    AlbumName = "Sprinter",
                    AlbumPrice = 16m,
                    AlbumCover = "https://images.unsplash.com/photo-1548811579-017cf2a4268b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a28.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dave"));
                a28.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Albums.Add(a28);

                Album a29 = new Album()
                {
                    AlbumName = "Uprising",
                    AlbumPrice = 22m,
                    AlbumCover = "https://images.unsplash.com/photo-1482160549825-59d1b23cb208?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTl8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a29.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bob Marley & The Wailers"));
                a29.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a29.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Albums.Add(a29);

                Album a30 = new Album()
                {
                    AlbumName = "MIXTAPE PLUTO",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1533158326339-7f3cf2404354?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a30.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Future"));
                a30.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a30);

                Album a31 = new Album()
                {
                    AlbumName = "One of Wun",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1602464729960-f95937746b68?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDh8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a31.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gunna"));
                a31.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Cazzu"));
                a31.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Naira Marley"));
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Albums.Add(a31);

                Album a32 = new Album()
                {
                    AlbumName = "nadie sabe lo que va a pasar manana",
                    AlbumPrice = 15m,
                    AlbumCover = "https://images.unsplash.com/photo-1547826039-bfc35e0f1ea8?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTB8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a32.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bad Bunny"));
                a32.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a32.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a32.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a32);

                Album a33 = new Album()
                {
                    AlbumName = "Un Verano Sin Ti",
                    AlbumPrice = 14m,
                    AlbumCover = "https://images.unsplash.com/photo-1549289524-06cf8837ace5?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTF8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a33.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bad Bunny"));
                a33.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "C. Tangana"));
                a33.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "DJ Guih Da ZO"));
                a33.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "XXXTENTACION"));
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Albums.Add(a33);

                Album a34 = new Album()
                {
                    AlbumName = "Doja",
                    AlbumPrice = 15m,
                    AlbumCover = "https://images.unsplash.com/photo-1549490349-8643362247b5?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTJ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a34.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Central Cee"));
                a34.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a34.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Albums.Add(a34);

                Album a35 = new Album()
                {
                    AlbumName = "No More Drama",
                    AlbumPrice = 19m,
                    AlbumCover = "https://images.unsplash.com/photo-1513909894411-7d7e04c28ecd?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTR8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a35.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mary J. Blige"));
                a35.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a35.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Albums.Add(a35);

                Album a36 = new Album()
                {
                    AlbumName = "The Eminem Show",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1529154166925-574a0236a4f4?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTV8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a36.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Eminem"));
                a36.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a36.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a36.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a36);

                Album a37 = new Album()
                {
                    AlbumName = "Savage Mode",
                    AlbumPrice = 23m,
                    AlbumCover = "https://images.unsplash.com/photo-1582561424760-0321d75e81fa?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTZ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a37.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "21 Savage"));
                a37.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a37.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Albums.Add(a37);

                Album a38 = new Album()
                {
                    AlbumName = "The Largest",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1576495169018-bd2414046c6b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTh8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a38.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "BigXthaPlug"));
                a38.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Chip"));
                a38.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a38.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a38.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a38);

                Album a39 = new Album()
                {
                    AlbumName = "Life After Death (2014 Remastered Edition)",
                    AlbumPrice = 7m,
                    AlbumCover = "https://images.unsplash.com/photo-1622737133809-d95047b9e673?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTl8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a39.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mary J. Blige"));
                a39.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "The Notorious B.I.G."));
                a39.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a39.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a39.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a39.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Albums.Add(a39);

                Album a40 = new Album()
                {
                    AlbumName = "Capital Punishment",
                    AlbumPrice = 7m,
                    AlbumCover = "https://images.unsplash.com/photo-1522878308970-972ec5eedc0d?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjB8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a40.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Big Pun"));
                a40.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a40);

                Album a41 = new Album()
                {
                    AlbumName = "Error 93",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1579762715459-5a068c289fda?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjJ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a41.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Cazzu"));
                a41.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a41.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a41.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a41);

                Album a42 = new Album()
                {
                    AlbumName = "WHO CARES?",
                    AlbumPrice = 13m,
                    AlbumCover = "https://images.unsplash.com/photo-1581850518616-bcb8077a2336?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjN8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a42.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Rex Orange County"));
                a42.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a42.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Albums.Add(a42);

                Album a43 = new Album()
                {
                    AlbumName = "Not Like Us",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1652172264794-a83fe7c190f3?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjR8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a43.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kendrick Lamar"));
                a43.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a43.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a43.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a43);

                Album a44 = new Album()
                {
                    AlbumName = "4 Your Eyez Only",
                    AlbumPrice = 9m,
                    AlbumCover = "https://images.unsplash.com/photo-1579783928621-7a13d66a62d1?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjZ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a44.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "J. Cole"));
                a44.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a44.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Albums.Add(a44);

                Album a45 = new Album()
                {
                    AlbumName = "Parade - Music from the Motion Picture Under the Cherry Moon",
                    AlbumPrice = 20m,
                    AlbumCover = "https://images.unsplash.com/photo-1517697471339-4aa32003c11a?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Njd8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a45.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Prince"));
                a45.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a45.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Albums.Add(a45);

                Album a46 = new Album()
                {
                    AlbumName = "JUJU (feat. Shallipopi)",
                    AlbumPrice = 12m,
                    AlbumCover = "https://images.unsplash.com/photo-1558865869-c93f6f8482af?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Njh8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a46.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Smur Lee"));
                a46.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a46.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Albums.Add(a46);

                Album a47 = new Album()
                {
                    AlbumName = "Drip Harder",
                    AlbumPrice = 18m,
                    AlbumCover = "https://images.unsplash.com/photo-1575995872537-3793d29d972c?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NzB8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a47.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Baby"));
                a47.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a47.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a47.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Albums.Add(a47);

                Album a48 = new Album()
                {
                    AlbumName = "Black Sunday",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1578301978069-45264734cddc?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NzF8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a48.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Cypress Hill"));
                a48.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a48.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Albums.Add(a48);

                Album a49 = new Album()
                {
                    AlbumName = "Please Excuse Me for Being Antisocial",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1569759276108-31b8e7e43e7b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NzJ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a49.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Delux"));
                a49.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Roddy Ricch"));
                a49.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a49.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Albums.Add(a49);

                Album a50 = new Album()
                {
                    AlbumName = "Jogadinha do Paqueta",
                    AlbumPrice = 14m,
                    AlbumCover = "https://images.unsplash.com/photo-1579783902915-f0b0de2c2eb3?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NzR8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a50.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Rf"));
                a50.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a50);

                Album a51 = new Album()
                {
                    AlbumName = "Bumbum granada",
                    AlbumPrice = 18m,
                    AlbumCover = "https://images.unsplash.com/photo-1611273651216-29b4f282d36b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NzV8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a51.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC's Zaac"));
                a51.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a51);

                Album a52 = new Album()
                {
                    AlbumName = "Tchikita",
                    AlbumPrice = 8m,
                    AlbumCover = "https://images.unsplash.com/photo-1584278773680-8d940a213dcf?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NzZ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a52.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jul"));
                a52.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Perry Goldfish"));
                a52.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a52.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a52.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a52);

                Album a53 = new Album()
                {
                    AlbumName = "Normally (feat. NSG)",
                    AlbumPrice = 23m,
                    AlbumCover = "https://images.unsplash.com/photo-1556005693-00fff02f134c?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nzh8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a53.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "JAE5"));
                a53.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Albums.Add(a53);

                Album a54 = new Album()
                {
                    AlbumName = "Peru",
                    AlbumPrice = 16m,
                    AlbumCover = "https://images.unsplash.com/photo-1543857778-c4a1a3e0b2eb?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nzl8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a54.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Fireboy DML"));
                a54.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a54);

                Album a55 = new Album()
                {
                    AlbumName = "Tu Hablas Espanhol",
                    AlbumPrice = 14m,
                    AlbumCover = "https://images.unsplash.com/photo-1484589065579-248aad0d8b13?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8ODB8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a55.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Migos"));
                a55.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Delux"));
                a55.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a55.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a55);

                Album a56 = new Album()
                {
                    AlbumName = "Abo Nokthula",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1554139681-1adb48e035cb?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8ODJ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a56.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "TNK MusiQ"));
                a56.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a56.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a56);

                Album a57 = new Album()
                {
                    AlbumName = "Beyond Infinity",
                    AlbumPrice = 21m,
                    AlbumCover = "https://images.unsplash.com/photo-1529432337323-223e988a90fb?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8ODN8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a57.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Frosh"));
                a57.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a57.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a57.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Albums.Add(a57);

                Album a58 = new Album()
                {
                    AlbumName = "Local Mvp",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1580136579585-48a5311ee2f7?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8ODR8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a58.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Saint"));
                a58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Albums.Add(a58);

                Album a59 = new Album()
                {
                    AlbumName = "GOSSIP",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1578301996581-bf7caec556c0?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8ODZ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a59.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Killloane"));
                a59.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a59);

                Album a60 = new Album()
                {
                    AlbumName = "Wahala",
                    AlbumPrice = 21m,
                    AlbumCover = "https://images.unsplash.com/photo-1747863021551-592cf32359bb?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Njd8ZW58MHx8MHx8fDA%3D"
                };
                a60.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "21 Savage"));
                a60.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Naira Marley"));
                a60.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a60.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a60.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a60.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Albums.Add(a60);

                Album a61 = new Album()
                {
                    AlbumName = "Born Wit It (Bumpa Riddim)",
                    AlbumPrice = 6m,
                    AlbumCover = "https://images.unsplash.com/photo-1605721911519-3dfeb3be25e7?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a61.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alison Hinds"));
                a61.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Albums.Add(a61);

                Album a62 = new Album()
                {
                    AlbumName = "Soca Soca",
                    AlbumPrice = 16m,
                    AlbumCover = "https://images.unsplash.com/photo-1579762715118-a6f1d4b934f1?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTF8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a62.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Mazzie"));
                a62.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a62.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a62);

                Album a63 = new Album()
                {
                    AlbumName = "Everybody Loves Ice Prince",
                    AlbumPrice = 20m,
                    AlbumCover = "https://images.unsplash.com/photo-1579541814924-49fef17c5be5?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a63.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Ice Prince"));
                a63.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zinoleesky"));
                a63.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a63.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Albums.Add(a63);

                Album a64 = new Album()
                {
                    AlbumName = "Caesar",
                    AlbumPrice = 25m,
                    AlbumCover = "https://images.unsplash.com/photo-1577083165633-14ebcdb0f658?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a64.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Inventor Ace"));
                a64.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a64);

                Album a65 = new Album()
                {
                    AlbumName = "Double M, Vol. 1",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1536924940846-227afb31e2a5?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a65.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Machel Montano"));
                a65.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "low&slow"));
                a65.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a65.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a65.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a65.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a65.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Albums.Add(a65);

                Album a66 = new Album()
                {
                    AlbumName = "Shorty",
                    AlbumPrice = 16m,
                    AlbumCover = "https://images.unsplash.com/photo-1577084381380-3b9ea4153664?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fGFydHxlbnwwfHwwfHx8MA%3D%3D"
                };
                a66.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kendrick Lamar"));
                a66.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jerry Di"));
                a66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Albums.Add(a66);

                Album a67 = new Album()
                {
                    AlbumName = "Talibans II",
                    AlbumPrice = 18m,
                    AlbumCover = "https://images.unsplash.com/photo-1491466424936-e304919aada7?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Y29vbCUyMHdhbGxwYXBlcnxlbnwwfHwwfHx8MA%3D%3D"
                };
                a67.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Burna Boy"));
                a67.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Albums.Add(a67);

                Album a68 = new Album()
                {
                    AlbumName = "Chaque matin",
                    AlbumPrice = 8m,
                    AlbumCover = "https://images.unsplash.com/photo-1484950763426-56b5bf172dbb?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8Y29vbCUyMHdhbGxwYXBlcnxlbnwwfHwwfHx8MA%3D%3D"
                };
                a68.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Key Largo"));
                a68.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "HOUDI"));
                a68.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a68.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a68.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a68.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a68.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Albums.Add(a68);

                Album a69 = new Album()
                {
                    AlbumName = "EZIOKWU",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1503327431567-3ab5e6e79140?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8Y29vbCUyMHdhbGxwYXBlcnxlbnwwfHwwfHx8MA%3D%3D"
                };
                a69.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ODUMODUBLVCK"));
                a69.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a69.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Albums.Add(a69);

                Album a70 = new Album()
                {
                    AlbumName = "projection",
                    AlbumPrice = 18m,
                    AlbumCover = "https://images.unsplash.com/photo-1499678329028-101435549a4e?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8Y29vbCUyMHdhbGxwYXBlcnxlbnwwfHwwfHx8MA%3D%3D"
                };
                a70.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "love_eight"));
                a70.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a70);

                Album a71 = new Album()
                {
                    AlbumName = "LA FOLIE DES GRANDEURS",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1464983953574-0892a716854b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8Y29vbCUyMHdhbGxwYXBlcnxlbnwwfHwwfHx8MA%3D%3D"
                };
                a71.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "HOUDI"));
                a71.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a71.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Albums.Add(a71);

                Album a72 = new Album()
                {
                    AlbumName = "Chama o Coveiro",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1431440869543-efaf3388c585?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8Y29vbCUyMHdhbGxwYXBlcnxlbnwwfHwwfHx8MA%3D%3D"
                };
                a72.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Delux"));
                a72.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a72);

                Album a73 = new Album()
                {
                    AlbumName = "Talk Show",
                    AlbumPrice = 13m,
                    AlbumCover = "https://images.unsplash.com/photo-1444703686981-a3abbc4d4fe3?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8Y29vbCUyMHdhbGxwYXBlcnxlbnwwfHwwfHx8MA%3D%3D"
                };
                a73.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Humble Francis"));
                a73.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a73);

                Album a74 = new Album()
                {
                    AlbumName = "July Key",
                    AlbumPrice = 13m,
                    AlbumCover = "https://images.unsplash.com/photo-1469474968028-56623f02e42e?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OXx8Y29vbCUyMHdhbGxwYXBlcnxlbnwwfHwwfHx8MA%3D%3D"
                };
                a74.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Key Largo"));
                a74.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a74.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a74.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Albums.Add(a74);

                Album a75 = new Album()
                {
                    AlbumName = "Buga (Lo Lo Lo)",
                    AlbumPrice = 18m,
                    AlbumCover = "https://images.unsplash.com/photo-1482784160316-6eb046863ece?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTB8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a75.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kizz Daniel"));
                a75.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a75.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a75.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Albums.Add(a75);

                Album a76 = new Album()
                {
                    AlbumName = "Nunca Estoy",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1475598322381-f1b499717dda?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a76.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "C. Tangana"));
                a76.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a76.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a76.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Albums.Add(a76);

                Album a77 = new Album()
                {
                    AlbumName = "Grit & Lust",
                    AlbumPrice = 16m,
                    AlbumCover = "https://images.unsplash.com/photo-1484589065579-248aad0d8b13?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a77.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zinoleesky"));
                a77.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Albums.Add(a77);

                Album a78 = new Album()
                {
                    AlbumName = "Brut de femme",
                    AlbumPrice = 10m,
                    AlbumCover = "https://images.unsplash.com/photo-1496347646636-ea47f7d6b37b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a78.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Diam's"));
                a78.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a78.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a78.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a78);

                Album a79 = new Album()
                {
                    AlbumName = "The Very Best of The Dixie Cups: Chapel of Love",
                    AlbumPrice = 18m,
                    AlbumCover = "https://images.unsplash.com/photo-1503410759647-41040b696833?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a79.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "The Dixie Cups"));
                a79.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a79.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a79.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Albums.Add(a79);

                Album a80 = new Album()
                {
                    AlbumName = "Hey Hou",
                    AlbumPrice = 15m,
                    AlbumCover = "https://images.unsplash.com/photo-1445264918150-66a2371142a2?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a80.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Outkast"));
                a80.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "DJ Guih Da ZO"));
                a80.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a80.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a80.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a80);

                Album a81 = new Album()
                {
                    AlbumName = "La Cumbia De Carmelo",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1479030160180-b1860951d696?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a81.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Quality Control"));
                a81.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "La Chanchona De Tito Mira"));
                a81.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a81.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a81.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a81.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a81.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Albums.Add(a81);

                Album a82 = new Album()
                {
                    AlbumName = "Holiday",
                    AlbumPrice = 8m,
                    AlbumCover = "https://images.unsplash.com/photo-1485470733090-0aae1788d5af?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a82.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Problem Child"));
                a82.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a82.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a82.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a82);

                Album a83 = new Album()
                {
                    AlbumName = "REI DO BRASIL",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1500673922987-e212871fec22?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjF8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a83.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Seek"));
                a83.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a83.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Albums.Add(a83);

                Album a84 = new Album()
                {
                    AlbumName = "Body",
                    AlbumPrice = 19m,
                    AlbumCover = "https://images.unsplash.com/photo-1507936580189-3816b4abf640?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjN8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a84.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bob Marley & The Wailers"));
                a84.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Naira Marley"));
                a84.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a84.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a84.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a84.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Albums.Add(a84);

                Album a85 = new Album()
                {
                    AlbumName = "The Evil Genius",
                    AlbumPrice = 20m,
                    AlbumCover = "https://images.unsplash.com/photo-1507187632231-5beb21a654a2?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjR8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a85.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mr Eazi"));
                a85.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a85.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Albums.Add(a85);

                Album a86 = new Album()
                {
                    AlbumName = "Do not forget",
                    AlbumPrice = 23m,
                    AlbumCover = "https://images.unsplash.com/photo-1459909633680-206dc5c67abb?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjV8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a86.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Perry Goldfish"));
                a86.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a86.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a86);

                Album a87 = new Album()
                {
                    AlbumName = "Jingle Bell",
                    AlbumPrice = 6m,
                    AlbumCover = "https://images.unsplash.com/photo-1504288145234-919e7bbc6d19?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjd8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a87.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Teteu"));
                a87.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a87.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Albums.Add(a87);

                Album a88 = new Album()
                {
                    AlbumName = "Khuphuka",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1534447677768-be436bb09401?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjh8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a88.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Royal MusiQ"));
                a88.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a88.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a88.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Albums.Add(a88);

                Album a89 = new Album()
                {
                    AlbumName = "Static",
                    AlbumPrice = 8m,
                    AlbumCover = "https://images.unsplash.com/photo-1443428018053-13da55589fed?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjl8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a89.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "2JtheRichest"));
                a89.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Albums.Add(a89);

                Album a90 = new Album()
                {
                    AlbumName = "Milki",
                    AlbumPrice = 22m,
                    AlbumCover = "https://images.unsplash.com/photo-1500754088824-ce0582cfe45f?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzF8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a90.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Akapellah"));
                a90.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a90.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Albums.Add(a90);

                Album a91 = new Album()
                {
                    AlbumName = "Colours",
                    AlbumPrice = 16m,
                    AlbumCover = "https://images.unsplash.com/photo-1504006833117-8886a355efbf?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzJ8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a91.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kid AlpHa"));
                a91.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a91);

                Album a92 = new Album()
                {
                    AlbumName = "LA PANTERA NEGRA",
                    AlbumPrice = 19m,
                    AlbumCover = "https://images.unsplash.com/photo-1457327289196-f38b88d97147?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzN8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a92.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Myke Towers"));
                a92.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Albums.Add(a92);

                Album a93 = new Album()
                {
                    AlbumName = "Bar Breeze",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1500073584060-670c36a703f1?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzV8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a93.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Hammocks & Lime"));
                a93.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a93.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Albums.Add(a93);

                Album a94 = new Album()
                {
                    AlbumName = "Unruly",
                    AlbumPrice = 10m,
                    AlbumCover = "https://images.unsplash.com/photo-1501791187590-9ef2612ba1eb?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MzZ8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a94.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Olamide"));
                a94.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Albums.Add(a94);

                Album a95 = new Album()
                {
                    AlbumName = "Quest for Coin II",
                    AlbumPrice = 12m,
                    AlbumCover = "https://images.unsplash.com/photo-1501854140801-50d01698950b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mzd8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a95.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "The Notorious B.I.G."));
                a95.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kid AlpHa"));
                a95.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Ezra Collective"));
                a95.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a95.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a95.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a95.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Albums.Add(a95);

                Album a96 = new Album()
                {
                    AlbumName = "Made In Lagos: Deluxe Edition",
                    AlbumPrice = 23m,
                    AlbumCover = "https://images.unsplash.com/photo-1505699261378-c372af38134c?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mzl8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a96.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Wizkid"));
                a96.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a96.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Albums.Add(a96);

                Album a97 = new Album()
                {
                    AlbumName = "Shifting Sands",
                    AlbumPrice = 16m,
                    AlbumCover = "https://images.unsplash.com/photo-1501696461415-6bd6660c6742?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDB8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a97.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "G:sson"));
                a97.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a97);

                Album a98 = new Album()
                {
                    AlbumName = "Beam Me Up",
                    AlbumPrice = 14m,
                    AlbumCover = "https://images.unsplash.com/photo-1490237014491-822aee911b99?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDF8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a98.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Daft Punk"));
                a98.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Adam Space"));
                a98.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a98.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a98);

                Album a99 = new Album()
                {
                    AlbumName = "Time Fragments",
                    AlbumPrice = 18m,
                    AlbumCover = "https://images.unsplash.com/photo-1470813740244-df37b8c1edcb?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDN8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a99.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "LoFi Waiter"));
                a99.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a99);

                Album a100 = new Album()
                {
                    AlbumName = "PSYCHODRAMA",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1477346611705-65d1883cee1e?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDR8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a100.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dave"));
                a100.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a100.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Albums.Add(a100);

                Album a101 = new Album()
                {
                    AlbumName = "glow",
                    AlbumPrice = 17m,
                    AlbumCover = "https://images.unsplash.com/photo-1493246507139-91e8fad9978e?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDV8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a101.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "low&slow"));
                a101.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a101.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Albums.Add(a101);

                Album a102 = new Album()
                {
                    AlbumName = "spring is coming",
                    AlbumPrice = 10m,
                    AlbumCover = "https://images.unsplash.com/photo-1430876988766-1be68caef0e4?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDd8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a102.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "jaackson"));
                a102.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a102);

                Album a103 = new Album()
                {
                    AlbumName = "Tekky",
                    AlbumPrice = 13m,
                    AlbumCover = "https://images.unsplash.com/photo-1441260038675-7329ab4cc264?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDh8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a103.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Chip"));
                a103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Albums.Add(a103);

                Album a104 = new Album()
                {
                    AlbumName = "Midterm Mix",
                    AlbumPrice = 13m,
                    AlbumCover = "https://images.unsplash.com/photo-1480321182142-e77f14b9aa64?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDl8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Mazzie"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Humble Francis"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kizz Daniel"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Debugger"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Controller"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Ninja"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Architect"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Builder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee View"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Builder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Hacker"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Tester"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Builder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee View"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Controller"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Debugger"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle View"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em View"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Dev"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Model"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Controller"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Dev"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Model"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Builder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Mapper"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Architect"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Controller"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Coder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Controller"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Model"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Builder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Hacker"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Builder"));
                a104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "jaackson"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Albums.Add(a104);

                Album a105 = new Album()
                {
                    AlbumName = "Office Hours",
                    AlbumPrice = 23m,
                    AlbumCover = "https://images.unsplash.com/photo-1470071459604-3b5ec3a7fe05?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTF8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Ice Cube"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Michael Jackson"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Future"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alison Hinds"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Ninja"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Dev"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Model"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Ninja"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Builder"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Mapper"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "C. Tangana"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Builder"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Coder"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Debugger"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Model"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee View"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Architect"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Hacker"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Mapper"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Model"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Controller"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Hacker"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Inventor Ace"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Tester"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Ninja"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Tester"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Hacker"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Coder"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Coder"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Mapper"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "The Dixie Cups"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Model"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Ninja"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Tester"));
                a105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Model"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Albums.Add(a105);

                Album a106 = new Album()
                {
                    AlbumName = "Wireframe Weekend",
                    AlbumPrice = 12m,
                    AlbumCover = "https://images.unsplash.com/photo-1579807851425-41def76a2f47?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTJ8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Timbaland"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Daft Punk"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Queen"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Debugger"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Builder"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Dev"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are View"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Hacker"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Model"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Coder"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Tester"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta View"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Architect"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Hacker"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee View"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Architect"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Model"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Dev"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Coder"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Model"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Debugger"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Dev"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Debugger"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Architect"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Dev"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kid AlpHa"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Kevin o Chris"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Builder"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Debugger"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Hacker"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Mapper"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Model"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Tester"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee View"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Model"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Dev"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Model"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee View"));
                a106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "low&slow"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Albums.Add(a106);

                Album a107 = new Album()
                {
                    AlbumName = "Sprint 1",
                    AlbumPrice = 13m,
                    AlbumCover = "https://images.unsplash.com/photo-1466853817435-05b43fe45b39?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTN8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Michael Jackson"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Kevin o Chris"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Chip"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Mapper"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Hacker"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Mapper"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Hacker"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Mapper"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Tester"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Debugger"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Architect"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Builder"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Coder"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Debugger"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Builder"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Coder"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Coder"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Architect"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Dev"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Dev"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Mapper"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Model"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Builder"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why View"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Builder"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Tester"));
                a107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee View"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Albums.Add(a107);

                Album a108 = new Album()
                {
                    AlbumName = "TA Sessions",
                    AlbumPrice = 10m,
                    AlbumCover = "https://images.unsplash.com/photo-1502472584811-0a2f2feb8968?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTV8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Luis R Conriquez"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "The Notorious B.I.G."));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Fireboy DML"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Debugger"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Mapper"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha View"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Dev"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Mapper"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Builder"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Builder"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Diam's"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Architect"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Model"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Controller"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Debugger"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Dev"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em View"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Builder"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Controller"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Model"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Controller"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Tester"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Dev"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Teteu"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Coder"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Controller"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Dev"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Mapper"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Royal MusiQ"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Saint"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Architect"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Coder"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Mapper"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why View"));
                a108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Hacker"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Albums.Add(a108);

                Album a109 = new Album()
                {
                    AlbumName = "Refactor Rhapsody",
                    AlbumPrice = 25m,
                    AlbumCover = "https://images.unsplash.com/photo-1431794062232-2a99a5431c6c?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTd8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "A Boogie Wit da Hoodie"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "JAE5"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Hacker"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Debugger"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Architect"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Mapper"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Architect"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Coder"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Debugger"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Ninja"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Tester"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Builder"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Model"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Coder"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Debugger"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Hacker"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Debugger"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Tester"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Builder"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Mapper"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Mapper"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Controller"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Coder"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Architect"));
                a109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Albums.Add(a109);

                Album a110 = new Album()
                {
                    AlbumName = "Diagram Dreams",
                    AlbumPrice = 24m,
                    AlbumCover = "https://images.unsplash.com/photo-1469719847081-4757697d117a?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjB8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Quality Control"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mary J. Blige"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Inventor Ace"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Controller"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Dev"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Hacker"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Architect"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Mapper"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Model"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Ninja"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Coder"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Hacker"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Model"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Tester"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Controller"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Coder"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Dev"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Mapper"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Builder"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Coder"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Tester"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Machel Montano"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Hacker"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Mapper"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Model"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Tester"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Tester"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Dev"));
                a110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Mapper"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Albums.Add(a110);

                Album a111 = new Album()
                {
                    AlbumName = "Final Release",
                    AlbumPrice = 23m,
                    AlbumCover = "https://images.unsplash.com/photo-1464254786740-b97e5420c299?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjN8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Queen"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dave"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Tester"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Hacker"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Mapper"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Architect"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Ninja"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Coder"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Debugger"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Builder"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Controller"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Dev"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Debugger"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Hacker"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Debugger"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Model"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Controller"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Dev"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Ninja"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Tester"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Builder"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Dev"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Builder"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Mapper"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Dev"));
                a111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Mapper"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Albums.Add(a111);

                Album a112 = new Album()
                {
                    AlbumName = "Code Freeze",
                    AlbumPrice = 19m,
                    AlbumCover = "https://images.unsplash.com/photo-1483347756197-71ef80e95f73?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjR8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "21 Savage"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jerry Di"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Debugger"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Coder"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Architect"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Controller"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Ninja"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta View"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Architect"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Coder"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Hacker"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Controller"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Ninja"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Dev"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Mapper"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Hacker"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Debugger"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Mapper"));
                a112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Albums.Add(a112);

                Album a113 = new Album()
                {
                    AlbumName = "Bug Bash",
                    AlbumPrice = 11m,
                    AlbumCover = "https://images.unsplash.com/photo-1428447207228-b396f310848b?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NjV8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Timbaland"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gunna"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bad Bunny"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Coder"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Ninja"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Mapper"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Ninja"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Coder"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Hacker"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Coder"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta View"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Debugger"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Mapper"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Model"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Debugger"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Mapper"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Ninja"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Tester"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay View"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Hacker"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Coder"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Hacker"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Builder"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Builder"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why View"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Dev"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Hacker"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Mapper"));
                a113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee View"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Albums.Add(a113);

                Album a114 = new Album()
                {
                    AlbumName = "Unit Test Utopia",
                    AlbumPrice = 8m,
                    AlbumCover = "https://images.unsplash.com/photo-1505852679233-d9fd70aff56d?w=1400&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Njh8fGNvb2wlMjB3YWxscGFwZXJ8ZW58MHx8MHx8fDA%3D"
                };
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bob Marley & The Wailers"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Central Cee"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jerry Di"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Akapellah"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Debugger"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Model"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are View"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Controller"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Mapper"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee View"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Model"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta View"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Burna Boy"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Architect"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee View"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Diam's"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Architect"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Coder"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em View"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Coder"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Debugger"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Tester"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Builder"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Mapper"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Ninja"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Tester"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee View"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Teteu"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Debugger"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Ninja"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Tester"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee View"));
                a114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Model"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Albums.Add(a114);


                foreach (Album albumToAdd in Albums)
                {
                    Album dbAlbum = db.Albums.FirstOrDefault(g => g.AlbumName == albumToAdd.AlbumName);
                    if (dbAlbum == null)
                    {
                        db.Albums.Add(albumToAdd);
                        db.SaveChanges();
                        intAlbumsAdded += 1;
                    }
                }

            }
            catch
            {
                String msg = "Albums Added: " + intAlbumsAdded.ToString();
                throw new InvalidOperationException(msg);
            }
        }
    }
}
