using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Seeding
{
    public static class SeedSongs
    {
        public static void SeedAllSongs(AppDbContext db)
        {
            // check to see if all the genres have already been added
            if (db.Songs.Count() == 295)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Song record count is already 295!");
                throw ex;
            }
            Int32 intSongsAdded = 0;
            try
            {
                //Create a list of song
                List<Song> Songs = new List<Song>();

                Song s1 = new Song()
                {
                    SongTitle = "Ice Ice Baby",
                    SongPrice = 1m
                };
                s1.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Vanilla Ice Is Back! - Hip Hop Classics"));
                s1.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Vanilla Ice"));
                s1.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s1.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s1);

                Song s2 = new Song()
                {
                    SongTitle = "Give It To Me",
                    SongPrice = 3m
                };
                s2.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Shock Value"));
                s2.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s2.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s2.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Timbaland"));
                s2.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s2.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s2);

                Song s3 = new Song()
                {
                    SongTitle = "NISSAN ALTIMA",
                    SongPrice = 2m
                };
                s3.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Alligator Bites Never Heal"));
                s3.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Doechii"));
                s3.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s3);

                Song s4 = new Song()
                {
                    SongTitle = "Baby (Lil Baby feat. DaBaby)",
                    SongPrice = 1m
                };
                s4.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Quality Control: Control The Streets Volume 2"));
                s4.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "La Cumbia De Carmelo"));
                s4.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s4.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Quality Control"));
                s4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s4);

                Song s5 = new Song()
                {
                    SongTitle = "Dior",
                    SongPrice = 1m
                };
                s5.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Still Rollin"));
                s5.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Shubh"));
                s5.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s5.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s5);

                Song s6 = new Song()
                {
                    SongTitle = "Yes Indeed",
                    SongPrice = 1m
                };
                s6.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Harder Than Ever"));
                s6.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Baby"));
                s6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s6);

                Song s7 = new Song()
                {
                    SongTitle = "Low Down",
                    SongPrice = 1m
                };
                s7.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "My Turn (Deluxe)"));
                s7.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Baby"));
                s7.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s7);

                Song s8 = new Song()
                {
                    SongTitle = "Se Voce Nao Quer Passa a Vez",
                    SongPrice = 4m
                };
                s8.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Se Voce Nao Quer Passa a Vez"));
                s8.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Please Excuse Me for Being Antisocial"));
                s8.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Delux"));
                s8.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s8);

                Song s9 = new Song()
                {
                    SongTitle = "Around the World",
                    SongPrice = 2m
                };
                s9.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Homework"));
                s9.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s9.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Beam Me Up"));
                s9.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Daft Punk"));
                s9.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s9);

                Song s10 = new Song()
                {
                    SongTitle = "Hot In Herre",
                    SongPrice = 3m
                };
                s10.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Nellyville"));
                s10.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Nelly"));
                s10.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s10.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                s10.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s10);

                Song s11 = new Song()
                {
                    SongTitle = "Temperature",
                    SongPrice = 5m
                };
                s11.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "The Trinity"));
                s11.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Sean Paul"));
                s11.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s11.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s11);

                Song s12 = new Song()
                {
                    SongTitle = "Ela Joga na Hora",
                    SongPrice = 5m
                };
                s12.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Ela Joga na Hora"));
                s12.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Pogba"));
                s12.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s12.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s12);

                Song s13 = new Song()
                {
                    SongTitle = "Still Think About You",
                    SongPrice = 3m
                };
                s13.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Artist"));
                s13.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s13.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "A Boogie Wit da Hoodie"));
                s13.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s13.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s13);

                Song s14 = new Song()
                {
                    SongTitle = "Lovin On Me",
                    SongPrice = 4m
                };
                s14.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Lovin On Me"));
                s14.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jack Harlow"));
                s14.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s14);

                Song s15 = new Song()
                {
                    SongTitle = "Que Se Cuide",
                    SongPrice = 5m
                };
                s15.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Que Se Cuide"));
                s15.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s15.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Luis R Conriquez"));
                s15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s15);

                Song s16 = new Song()
                {
                    SongTitle = "Houdini",
                    SongPrice = 4m
                };
                s16.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Houdini"));
                s16.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Eminem"));
                s16.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s16.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s16.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s16);

                Song s17 = new Song()
                {
                    SongTitle = "Check Yo Self - Remix",
                    SongPrice = 4m
                };
                s17.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bootlegs And B-Sides"));
                s17.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s17.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Ice Cube"));
                s17.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s17);

                Song s18 = new Song()
                {
                    SongTitle = "Another One Bites The Dust - Remastered 2011",
                    SongPrice = 5m
                };
                s18.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "The Game (Deluxe Remastered Version)"));
                s18.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s18.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s18.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Queen"));
                s18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s18);

                Song s19 = new Song()
                {
                    SongTitle = "Buffalo Soldier",
                    SongPrice = 4m
                };
                s19.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Confrontation"));
                s19.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Body"));
                s19.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bob Marley & The Wailers"));
                s19.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s19.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s19);

                Song s20 = new Song()
                {
                    SongTitle = "Bad and Boujee (feat. Lil Uzi Vert)",
                    SongPrice = 1m
                };
                s20.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Culture"));
                s20.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Tu Hablas Espanhol"));
                s20.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Migos"));
                s20.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s20);

                Song s21 = new Song()
                {
                    SongTitle = "We Paid (feat. 42 Dugg)",
                    SongPrice = 1m
                };
                s21.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "My Turn (Deluxe)"));
                s21.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Baby"));
                s21.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s21.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s21);

                Song s22 = new Song()
                {
                    SongTitle = "Si Antes Te Hubiera Conocido",
                    SongPrice = 2m
                };
                s22.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Si Antes Te Hubiera Conocido"));
                s22.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "KAROL G"));
                s22.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s22.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s22);

                Song s23 = new Song()
                {
                    SongTitle = "UK Rap",
                    SongPrice = 4m
                };
                s23.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Split Decision"));
                s23.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dave"));
                s23.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s23);

                Song s24 = new Song()
                {
                    SongTitle = "Moonlight",
                    SongPrice = 2m
                };
                s24.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "?"));
                s24.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Un Verano Sin Ti"));
                s24.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "XXXTENTACION"));
                s24.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s24.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s24.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s24);

                Song s25 = new Song()
                {
                    SongTitle = "Billie Jean",
                    SongPrice = 2m
                };
                s25.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Thriller 25 Super Deluxe Edition"));
                s25.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s25.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s25.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Michael Jackson"));
                s25.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s25);

                Song s26 = new Song()
                {
                    SongTitle = "Coffin",
                    SongPrice = 1m
                };
                s26.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Lil Boat 3.5"));
                s26.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Yachty"));
                s26.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s26.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s26);

                Song s27 = new Song()
                {
                    SongTitle = "Faz um Vuk Vuk (Teto Espelhado)",
                    SongPrice = 3m
                };
                s27.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Faz um Vuk Vuk (Teto Espelhado)"));
                s27.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s27.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s27.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Kevin o Chris"));
                s27.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s27.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s27.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s27);

                Song s28 = new Song()
                {
                    SongTitle = "ATLiens",
                    SongPrice = 3m
                };
                s28.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "ATLiens"));
                s28.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Hey Hou"));
                s28.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Outkast"));
                s28.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s28.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s28);

                Song s29 = new Song()
                {
                    SongTitle = "Sprinter",
                    SongPrice = 5m
                };
                s29.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprinter"));
                s29.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s29.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dave"));
                s29.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s29);

                Song s30 = new Song()
                {
                    SongTitle = "Could You Be Loved",
                    SongPrice = 1m
                };
                s30.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Uprising"));
                s30.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s30.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bob Marley & The Wailers"));
                s30.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s30.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s30);

                Song s31 = new Song()
                {
                    SongTitle = "TEFLON DON",
                    SongPrice = 1m
                };
                s31.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "MIXTAPE PLUTO"));
                s31.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s31.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Future"));
                s31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s31);

                Song s32 = new Song()
                {
                    SongTitle = "one of wun",
                    SongPrice = 3m
                };
                s32.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "One of Wun"));
                s32.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s32.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Lovin On Me"));
                s32.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gunna"));
                s32.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s32.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s32);

                Song s33 = new Song()
                {
                    SongTitle = "PERRO NEGRO",
                    SongPrice = 4m
                };
                s33.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "nadie sabe lo que va a pasar manana"));
                s33.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s33.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bad Bunny"));
                s33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s33);

                Song s34 = new Song()
                {
                    SongTitle = "Me Porto Bonito",
                    SongPrice = 2m
                };
                s34.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Un Verano Sin Ti"));
                s34.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bad Bunny"));
                s34.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s34.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s34.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s34);

                Song s35 = new Song()
                {
                    SongTitle = "Doja",
                    SongPrice = 3m
                };
                s35.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Doja"));
                s35.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s35.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Central Cee"));
                s35.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s35.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s35);

                Song s36 = new Song()
                {
                    SongTitle = "Family Affair",
                    SongPrice = 4m
                };
                s36.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "No More Drama"));
                s36.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Life After Death (2014 Remastered Edition)"));
                s36.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s36.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mary J. Blige"));
                s36.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s36.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s36);

                Song s37 = new Song()
                {
                    SongTitle = "Without Me",
                    SongPrice = 5m
                };
                s37.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "The Eminem Show"));
                s37.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Eminem"));
                s37.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s37.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s37.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s37);

                Song s38 = new Song()
                {
                    SongTitle = "No Heart",
                    SongPrice = 1m
                };
                s38.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Savage Mode"));
                s38.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wahala"));
                s38.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s38.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "21 Savage"));
                s38.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s38.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s38);

                Song s39 = new Song()
                {
                    SongTitle = "The Largest",
                    SongPrice = 3m
                };
                s39.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "The Largest"));
                s39.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "BigXthaPlug"));
                s39.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s39.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s39);

                Song s40 = new Song()
                {
                    SongTitle = "Hypnotize - 2014 Remaster",
                    SongPrice = 1m
                };
                s40.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Life After Death (2014 Remastered Edition)"));
                s40.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s40.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Quest for Coin II"));
                s40.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "The Notorious B.I.G."));
                s40.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s40.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s40);

                Song s41 = new Song()
                {
                    SongTitle = "Still Not a Player (feat. Joe) - Radio Version",
                    SongPrice = 1m
                };
                s41.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Capital Punishment"));
                s41.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Big Pun"));
                s41.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s41);

                Song s42 = new Song()
                {
                    SongTitle = "Nada",
                    SongPrice = 4m
                };
                s42.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Error 93"));
                s42.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "One of Wun"));
                s42.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Artist"));
                s42.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Cazzu"));
                s42.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s42.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s42.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s42);

                Song s43 = new Song()
                {
                    SongTitle = "THE SHADE",
                    SongPrice = 2m
                };
                s43.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "WHO CARES?"));
                s43.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Rex Orange County"));
                s43.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s43.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s43);

                Song s44 = new Song()
                {
                    SongTitle = "Not Like Us",
                    SongPrice = 3m
                };
                s44.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Not Like Us"));
                s44.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Shorty"));
                s44.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kendrick Lamar"));
                s44.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s44.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s44.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s44);

                Song s45 = new Song()
                {
                    SongTitle = "Neighbors",
                    SongPrice = 5m
                };
                s45.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "4 Your Eyez Only"));
                s45.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "J. Cole"));
                s45.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s45.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s45);

                Song s46 = new Song()
                {
                    SongTitle = "Kiss",
                    SongPrice = 2m
                };
                s46.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Parade - Music from the Motion Picture Under the Cherry Moon"));
                s46.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Prince"));
                s46.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s46.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s46);

                Song s47 = new Song()
                {
                    SongTitle = "JUJU (feat. Shallipopi)",
                    SongPrice = 1m
                };
                s47.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "JUJU (feat. Shallipopi)"));
                s47.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Smur Lee"));
                s47.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s47.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s47);

                Song s48 = new Song()
                {
                    SongTitle = "Drip Too Hard (Lil Baby & Gunna)",
                    SongPrice = 4m
                };
                s48.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Drip Harder"));
                s48.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Baby"));
                s48.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s48.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s48.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s48);

                Song s49 = new Song()
                {
                    SongTitle = "Insane in the Brain",
                    SongPrice = 3m
                };
                s49.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Black Sunday"));
                s49.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Cypress Hill"));
                s49.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s49.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s49);

                Song s50 = new Song()
                {
                    SongTitle = "The Box",
                    SongPrice = 1m
                };
                s50.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Please Excuse Me for Being Antisocial"));
                s50.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Vanilla Ice Is Back! - Hip Hop Classics"));
                s50.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Roddy Ricch"));
                s50.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s50);

                Song s51 = new Song()
                {
                    SongTitle = "Jogadinha do Paqueta",
                    SongPrice = 3m
                };
                s51.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Jogadinha do Paqueta"));
                s51.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Rf"));
                s51.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s51);

                Song s52 = new Song()
                {
                    SongTitle = "Bumbum granada",
                    SongPrice = 4m
                };
                s52.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bumbum granada"));
                s52.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC's Zaac"));
                s52.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s52);

                Song s53 = new Song()
                {
                    SongTitle = "Tchikita",
                    SongPrice = 1m
                };
                s53.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Tchikita"));
                s53.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jul"));
                s53.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s53);

                Song s54 = new Song()
                {
                    SongTitle = "Normally (feat. NSG)",
                    SongPrice = 1m
                };
                s54.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Normally (feat. NSG)"));
                s54.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s54.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "JAE5"));
                s54.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s54);

                Song s55 = new Song()
                {
                    SongTitle = "Peru",
                    SongPrice = 3m
                };
                s55.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Peru"));
                s55.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Still Rollin"));
                s55.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s55.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Fireboy DML"));
                s55.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s55);

                Song s56 = new Song()
                {
                    SongTitle = "Tu Hablas Espanhol",
                    SongPrice = 5m
                };
                s56.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Tu Hablas Espanhol"));
                s56.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Confrontation"));
                s56.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Delux"));
                s56.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s56.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s56);

                Song s57 = new Song()
                {
                    SongTitle = "Abo Nokthula (feat. The Exclusive SA, Scotts Maphuma, Kabelo Sings, Bontle Smith, 2woshort & Stompiiey)",
                    SongPrice = 2m
                };
                s57.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Abo Nokthula"));
                s57.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "TNK MusiQ"));
                s57.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s57.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s57);

                Song s58 = new Song()
                {
                    SongTitle = "Like Dat",
                    SongPrice = 3m
                };
                s58.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Beyond Infinity"));
                s58.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Lil Frosh"));
                s58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s58);

                Song s59 = new Song()
                {
                    SongTitle = "Champagne Shots",
                    SongPrice = 4m
                };
                s59.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Local Mvp"));
                s59.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s59.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Saint"));
                s59.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s59.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                s59.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s59);

                Song s60 = new Song()
                {
                    SongTitle = "GOSSIP",
                    SongPrice = 3m
                };
                s60.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "GOSSIP"));
                s60.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Killloane"));
                s60.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s60);

                Song s61 = new Song()
                {
                    SongTitle = "Wahala",
                    SongPrice = 5m
                };
                s61.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wahala"));
                s61.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Naira Marley"));
                s61.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s61.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s61.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s61);

                Song s62 = new Song()
                {
                    SongTitle = "Born Wit It (Bumpa Riddim)",
                    SongPrice = 3m
                };
                s62.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Born Wit It (Bumpa Riddim)"));
                s62.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s62.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alison Hinds"));
                s62.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s62);

                Song s63 = new Song()
                {
                    SongTitle = "Soca Soca",
                    SongPrice = 3m
                };
                s63.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Soca Soca"));
                s63.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s63.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Mazzie"));
                s63.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s63.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s63);

                Song s64 = new Song()
                {
                    SongTitle = "Magician (feat. J Milla & Yung L)",
                    SongPrice = 5m
                };
                s64.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Everybody Loves Ice Prince"));
                s64.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Ice Prince"));
                s64.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s64);

                Song s65 = new Song()
                {
                    SongTitle = "Caesar",
                    SongPrice = 5m
                };
                s65.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Caesar"));
                s65.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s65.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s65.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Inventor Ace"));
                s65.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s65);

                Song s66 = new Song()
                {
                    SongTitle = "Mr. Fete",
                    SongPrice = 4m
                };
                s66.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Double M, Vol. 1"));
                s66.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s66.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Machel Montano"));
                s66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s66);

                Song s67 = new Song()
                {
                    SongTitle = "Shorty",
                    SongPrice = 2m
                };
                s67.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Shorty"));
                s67.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s67.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s67.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jerry Di"));
                s67.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s67.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s67);

                Song s68 = new Song()
                {
                    SongTitle = "Talibans II",
                    SongPrice = 2m
                };
                s68.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Talibans II"));
                s68.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s68.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Burna Boy"));
                s68.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s68);

                Song s69 = new Song()
                {
                    SongTitle = "Chaque matin",
                    SongPrice = 3m
                };
                s69.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Chaque matin"));
                s69.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Key Largo"));
                s69.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s69.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s69.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s69);

                Song s70 = new Song()
                {
                    SongTitle = "TESLA BOY (feat. Blaqbonez)",
                    SongPrice = 5m
                };
                s70.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "EZIOKWU"));
                s70.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "ODUMODUBLVCK"));
                s70.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s70.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s70);

                Song s71 = new Song()
                {
                    SongTitle = "projection",
                    SongPrice = 5m
                };
                s71.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "projection"));
                s71.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "love_eight"));
                s71.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s71);

                Song s72 = new Song()
                {
                    SongTitle = "CIEL",
                    SongPrice = 4m
                };
                s72.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "LA FOLIE DES GRANDEURS"));
                s72.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Chaque matin"));
                s72.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "HOUDI"));
                s72.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s72.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s72);

                Song s73 = new Song()
                {
                    SongTitle = "Chama o Coveiro",
                    SongPrice = 5m
                };
                s73.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Chama o Coveiro"));
                s73.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mc Delux"));
                s73.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s73);

                Song s74 = new Song()
                {
                    SongTitle = "Talk Show",
                    SongPrice = 2m
                };
                s74.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Talk Show"));
                s74.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s74.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Humble Francis"));
                s74.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s74);

                Song s75 = new Song()
                {
                    SongTitle = "Merco Benz",
                    SongPrice = 2m
                };
                s75.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "July Key"));
                s75.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Key Largo"));
                s75.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s75.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s75.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s75);

                Song s76 = new Song()
                {
                    SongTitle = "Buga (Lo Lo Lo)",
                    SongPrice = 4m
                };
                s76.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Buga (Lo Lo Lo)"));
                s76.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s76.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kizz Daniel"));
                s76.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s76.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s76.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s76);

                Song s77 = new Song()
                {
                    SongTitle = "Nunca Estoy",
                    SongPrice = 1m
                };
                s77.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Nunca Estoy"));
                s77.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Un Verano Sin Ti"));
                s77.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s77.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "C. Tangana"));
                s77.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s77.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s77.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s77);

                Song s78 = new Song()
                {
                    SongTitle = "Rocking",
                    SongPrice = 1m
                };
                s78.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Grit & Lust"));
                s78.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zinoleesky"));
                s78.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s78);

                Song s79 = new Song()
                {
                    SongTitle = "DJ",
                    SongPrice = 1m
                };
                s79.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Brut de femme"));
                s79.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s79.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s79.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Diam's"));
                s79.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s79.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s79.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s79);

                Song s80 = new Song()
                {
                    SongTitle = "Iko Iko",
                    SongPrice = 2m
                };
                s80.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "The Very Best of The Dixie Cups: Chapel of Love"));
                s80.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s80.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "The Dixie Cups"));
                s80.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                s80.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s80.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s80);

                Song s81 = new Song()
                {
                    SongTitle = "Hey Hou",
                    SongPrice = 5m
                };
                s81.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Hey Hou"));
                s81.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Un Verano Sin Ti"));
                s81.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "DJ Guih Da ZO"));
                s81.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s81);

                Song s82 = new Song()
                {
                    SongTitle = "El Hijo De Tuta",
                    SongPrice = 2m
                };
                s82.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "La Cumbia De Carmelo"));
                s82.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "La Chanchona De Tito Mira"));
                s82.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s82.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s82);

                Song s83 = new Song()
                {
                    SongTitle = "Holiday",
                    SongPrice = 4m
                };
                s83.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Holiday"));
                s83.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Que Se Cuide"));
                s83.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Problem Child"));
                s83.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s83.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s83.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s83);

                Song s84 = new Song()
                {
                    SongTitle = "REI DO BRASIL",
                    SongPrice = 5m
                };
                s84.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "REI DO BRASIL"));
                s84.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Seek"));
                s84.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s84.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s84);

                Song s85 = new Song()
                {
                    SongTitle = "Body",
                    SongPrice = 3m
                };
                s85.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Body"));
                s85.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "One of Wun"));
                s85.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Naira Marley"));
                s85.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s85.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s85);

                Song s86 = new Song()
                {
                    SongTitle = "Mandela",
                    SongPrice = 5m
                };
                s86.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "The Evil Genius"));
                s86.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Mr Eazi"));
                s86.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s86.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s86);

                Song s87 = new Song()
                {
                    SongTitle = "Do not forget",
                    SongPrice = 2m
                };
                s87.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Do not forget"));
                s87.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Tchikita"));
                s87.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Perry Goldfish"));
                s87.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s87.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s87);

                Song s88 = new Song()
                {
                    SongTitle = "Jingle Bell",
                    SongPrice = 4m
                };
                s88.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Jingle Bell"));
                s88.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s88.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s88.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "MC Teteu"));
                s88.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s88.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s88);

                Song s89 = new Song()
                {
                    SongTitle = "Khuphuka",
                    SongPrice = 4m
                };
                s89.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Khuphuka"));
                s89.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s89.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Royal MusiQ"));
                s89.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s89.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s89.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s89);

                Song s90 = new Song()
                {
                    SongTitle = "Static",
                    SongPrice = 3m
                };
                s90.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Static"));
                s90.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "2JtheRichest"));
                s90.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s90);

                Song s91 = new Song()
                {
                    SongTitle = "Milki",
                    SongPrice = 2m
                };
                s91.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Milki"));
                s91.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s91.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Akapellah"));
                s91.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s91.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s91);

                Song s92 = new Song()
                {
                    SongTitle = "Colours",
                    SongPrice = 3m
                };
                s92.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Colours"));
                s92.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s92.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Quest for Coin II"));
                s92.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kid AlpHa"));
                s92.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s92);

                Song s93 = new Song()
                {
                    SongTitle = "DIABLITA (feat. YOVNGCHIMI)",
                    SongPrice = 5m
                };
                s93.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "LA PANTERA NEGRA"));
                s93.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Myke Towers"));
                s93.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s93);

                Song s94 = new Song()
                {
                    SongTitle = "Bar Breeze",
                    SongPrice = 1m
                };
                s94.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bar Breeze"));
                s94.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Hammocks & Lime"));
                s94.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s94.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s94);

                Song s95 = new Song()
                {
                    SongTitle = "Jinja",
                    SongPrice = 2m
                };
                s95.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unruly"));
                s95.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Olamide"));
                s95.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s95);

                Song s96 = new Song()
                {
                    SongTitle = "Quest For Coin II",
                    SongPrice = 4m
                };
                s96.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Quest for Coin II"));
                s96.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Ezra Collective"));
                s96.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s96.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s96);

                Song s97 = new Song()
                {
                    SongTitle = "Mood (feat. BNXN)",
                    SongPrice = 1m
                };
                s97.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Made In Lagos: Deluxe Edition"));
                s97.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Wizkid"));
                s97.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s97.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s97);

                Song s98 = new Song()
                {
                    SongTitle = "Shifting Sands",
                    SongPrice = 2m
                };
                s98.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Shifting Sands"));
                s98.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Split Decision"));
                s98.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "G:sson"));
                s98.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s98);

                Song s99 = new Song()
                {
                    SongTitle = "Beam Me Up",
                    SongPrice = 4m
                };
                s99.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Beam Me Up"));
                s99.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Adam Space"));
                s99.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s99);

                Song s100 = new Song()
                {
                    SongTitle = "Call of Duty",
                    SongPrice = 3m
                };
                s100.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Grit & Lust"));
                s100.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Everybody Loves Ice Prince"));
                s100.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zinoleesky"));
                s100.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s100);

                Song s101 = new Song()
                {
                    SongTitle = "Childhood Fragments",
                    SongPrice = 5m
                };
                s101.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Time Fragments"));
                s101.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "LoFi Waiter"));
                s101.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s101);

                Song s102 = new Song()
                {
                    SongTitle = "Streatham",
                    SongPrice = 1m
                };
                s102.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "PSYCHODRAMA"));
                s102.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dave"));
                s102.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s102.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s102);

                Song s103 = new Song()
                {
                    SongTitle = "glow",
                    SongPrice = 1m
                };
                s103.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "glow"));
                s103.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Double M, Vol. 1"));
                s103.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s103.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "low&slow"));
                s103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s103);

                Song s104 = new Song()
                {
                    SongTitle = "spring is coming",
                    SongPrice = 3m
                };
                s104.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "spring is coming"));
                s104.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s104.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "jaackson"));
                s104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s104);

                Song s105 = new Song()
                {
                    SongTitle = "Tekky",
                    SongPrice = 4m
                };
                s105.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Tekky"));
                s105.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "The Largest"));
                s105.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s105.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Chip"));
                s105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s105);

                Song s106 = new Song()
                {
                    SongTitle = "Integration Drop",
                    SongPrice = 3m
                };
                s106.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s106.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s106.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Hacker"));
                s106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s106);

                Song s107 = new Song()
                {
                    SongTitle = "Commit Ballad",
                    SongPrice = 5m
                };
                s107.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s107.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s107.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Tester"));
                s107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s107);

                Song s108 = new Song()
                {
                    SongTitle = "Section Loop",
                    SongPrice = 2m
                };
                s108.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s108.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s108.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Ninja"));
                s108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s108);

                Song s109 = new Song()
                {
                    SongTitle = "Entity Loop",
                    SongPrice = 5m
                };
                s109.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s109.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Model"));
                s109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s109);

                Song s110 = new Song()
                {
                    SongTitle = "Interface Sprint",
                    SongPrice = 1m
                };
                s110.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s110.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s110.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s110.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Debugger"));
                s110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                s110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s110);

                Song s111 = new Song()
                {
                    SongTitle = "Index CacheHit",
                    SongPrice = 1m
                };
                s111.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s111.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s111.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Coder"));
                s111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s111);

                Song s112 = new Song()
                {
                    SongTitle = "UnitTest Nugget",
                    SongPrice = 4m
                };
                s112.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s112.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s112.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Mapper"));
                s112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s112);

                Song s113 = new Song()
                {
                    SongTitle = "PartialView Webhook",
                    SongPrice = 2m
                };
                s113.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s113.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Hacker"));
                s113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s113);

                Song s114 = new Song()
                {
                    SongTitle = "Partial Release",
                    SongPrice = 5m
                };
                s114.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s114.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s114.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s114.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Ninja"));
                s114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s114);

                Song s115 = new Song()
                {
                    SongTitle = "Include Hotfix",
                    SongPrice = 4m
                };
                s115.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s115.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s115.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Model"));
                s115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s115);

                Song s116 = new Song()
                {
                    SongTitle = "Tuple Token",
                    SongPrice = 5m
                };
                s116.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s116.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s116.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s116.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                s116.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s116.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s116.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s116);

                Song s117 = new Song()
                {
                    SongTitle = "LeftJoin Endpoint",
                    SongPrice = 4m
                };
                s117.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s117.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s117.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Builder"));
                s117.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s117.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s117);

                Song s118 = new Song()
                {
                    SongTitle = "RightJoin Warmup",
                    SongPrice = 2m
                };
                s118.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s118.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s118.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Dev"));
                s118.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s118);

                Song s119 = new Song()
                {
                    SongTitle = "Fixture Loop",
                    SongPrice = 1m
                };
                s119.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s119.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Dev"));
                s119.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s119);

                Song s120 = new Song()
                {
                    SongTitle = "Scaffold Refactor",
                    SongPrice = 5m
                };
                s120.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s120.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s120.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Architect"));
                s120.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s120.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s120);

                Song s121 = new Song()
                {
                    SongTitle = "Mock Endpoint",
                    SongPrice = 2m
                };
                s121.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s121.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s121.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Hacker"));
                s121.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s121.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s121);

                Song s122 = new Song()
                {
                    SongTitle = "View Deploy",
                    SongPrice = 1m
                };
                s122.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s122.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s122.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Debugger"));
                s122.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s122.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s122);

                Song s123 = new Song()
                {
                    SongTitle = "TempData Sprint",
                    SongPrice = 4m
                };
                s123.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s123.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why View"));
                s123.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s123);

                Song s124 = new Song()
                {
                    SongTitle = "OrderBy Nugget",
                    SongPrice = 4m
                };
                s124.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s124.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee View"));
                s124.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s124.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s124);

                Song s125 = new Song()
                {
                    SongTitle = "Filter Standup",
                    SongPrice = 2m
                };
                s125.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s125.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s125.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Builder"));
                s125.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s125.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s125);

                Song s126 = new Song()
                {
                    SongTitle = "REST Beat",
                    SongPrice = 4m
                };
                s126.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s126.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Hacker"));
                s126.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s126);

                Song s127 = new Song()
                {
                    SongTitle = "Async Anthem",
                    SongPrice = 1m
                };
                s127.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s127.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s127.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s127.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Mapper"));
                s127.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s127.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s127);

                Song s128 = new Song()
                {
                    SongTitle = "Select Jam",
                    SongPrice = 1m
                };
                s128.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s128.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s128.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Tester"));
                s128.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s128.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s128.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s128);

                Song s129 = new Song()
                {
                    SongTitle = "DbContext Uptime",
                    SongPrice = 4m
                };
                s129.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s129.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s129.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s129.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Architect"));
                s129.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s129);

                Song s130 = new Song()
                {
                    SongTitle = "Lambda Bop",
                    SongPrice = 3m
                };
                s130.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s130.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                s130.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s130.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s130);

                Song s131 = new Song()
                {
                    SongTitle = "Dependency Groove",
                    SongPrice = 2m
                };
                s131.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s131.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s131.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee View"));
                s131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s131);

                Song s132 = new Song()
                {
                    SongTitle = "ViewData Webhook",
                    SongPrice = 5m
                };
                s132.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s132.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s132.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s132.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Architect"));
                s132.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s132.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s132.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s132);

                Song s133 = new Song()
                {
                    SongTitle = "REST Bop",
                    SongPrice = 5m
                };
                s133.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s133.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                s133.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s133);

                Song s134 = new Song()
                {
                    SongTitle = "MVC Suite",
                    SongPrice = 5m
                };
                s134.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s134.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s134.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Coder"));
                s134.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s134);

                Song s135 = new Song()
                {
                    SongTitle = "Cascade Overload",
                    SongPrice = 3m
                };
                s135.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s135.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Model"));
                s135.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s135.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s135);

                Song s136 = new Song()
                {
                    SongTitle = "OuterJoin Standup",
                    SongPrice = 1m
                };
                s136.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s136.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s136.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee View"));
                s136.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s136.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s136);

                Song s137 = new Song()
                {
                    SongTitle = "Async Exception",
                    SongPrice = 5m
                };
                s137.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s137.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s137.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Hacker"));
                s137.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s137);

                Song s138 = new Song()
                {
                    SongTitle = "InnerJoin Beat",
                    SongPrice = 5m
                };
                s138.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s138.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s138.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                s138.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s138);

                Song s139 = new Song()
                {
                    SongTitle = "ViewBag Breakpoint",
                    SongPrice = 1m
                };
                s139.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s139.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s139.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Dev"));
                s139.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s139.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s139);

                Song s140 = new Song()
                {
                    SongTitle = "Include Cipher",
                    SongPrice = 3m
                };
                s140.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s140.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s140.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Model"));
                s140.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s140);

                Song s141 = new Song()
                {
                    SongTitle = "Seeding Throughput",
                    SongPrice = 3m
                };
                s141.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s141.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s141.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s141.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Tester"));
                s141.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s141.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s141.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s141);

                Song s142 = new Song()
                {
                    SongTitle = "Delegate Token",
                    SongPrice = 3m
                };
                s142.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s142.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                s142.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s142);

                Song s143 = new Song()
                {
                    SongTitle = "OuterJoin Beat",
                    SongPrice = 4m
                };
                s143.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s143.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Hacker"));
                s143.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                s143.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s143);

                Song s144 = new Song()
                {
                    SongTitle = "Section Exception",
                    SongPrice = 3m
                };
                s144.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s144.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Hacker"));
                s144.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s144);

                Song s145 = new Song()
                {
                    SongTitle = "Include Ballad",
                    SongPrice = 4m
                };
                s145.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s145.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Dev"));
                s145.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s145);

                Song s146 = new Song()
                {
                    SongTitle = "LINQ Backoff",
                    SongPrice = 3m
                };
                s146.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s146.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s146.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee View"));
                s146.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s146.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s146.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s146);

                Song s147 = new Song()
                {
                    SongTitle = "DbContext Hotfix",
                    SongPrice = 1m
                };
                s147.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s147.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Mapper"));
                s147.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s147.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s147.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s147);

                Song s148 = new Song()
                {
                    SongTitle = "Integration Groove",
                    SongPrice = 4m
                };
                s148.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s148.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Coder"));
                s148.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s148);

                Song s149 = new Song()
                {
                    SongTitle = "InnerJoin Hash",
                    SongPrice = 4m
                };
                s149.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s149.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                s149.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s149.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s149);

                Song s150 = new Song()
                {
                    SongTitle = "Docker Ballad",
                    SongPrice = 1m
                };
                s150.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s150.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em View"));
                s150.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s150.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s150);

                Song s151 = new Song()
                {
                    SongTitle = "Merge Breakpoint",
                    SongPrice = 2m
                };
                s151.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s151.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s151.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Coder"));
                s151.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s151.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s151);

                Song s152 = new Song()
                {
                    SongTitle = "Integration Refactor",
                    SongPrice = 5m
                };
                s152.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s152.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s152.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Builder"));
                s152.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s152.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s152);

                Song s153 = new Song()
                {
                    SongTitle = "Generic Backoff",
                    SongPrice = 3m
                };
                s153.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s153.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Hacker"));
                s153.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s153);

                Song s154 = new Song()
                {
                    SongTitle = "Fixture Secret",
                    SongPrice = 2m
                };
                s154.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s154.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s154.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s154.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Ninja"));
                s154.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s154);

                Song s155 = new Song()
                {
                    SongTitle = "Identity Anthem",
                    SongPrice = 5m
                };
                s155.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s155.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s155.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s155.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Controller"));
                s155.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s155);

                Song s156 = new Song()
                {
                    SongTitle = "Scaffold Miss",
                    SongPrice = 4m
                };
                s156.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s156.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Model"));
                s156.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s156.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s156);

                Song s157 = new Song()
                {
                    SongTitle = "Entity Nugget",
                    SongPrice = 1m
                };
                s157.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s157.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s157.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Mapper"));
                s157.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s157.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s157);

                Song s158 = new Song()
                {
                    SongTitle = "JWT Salt",
                    SongPrice = 4m
                };
                s158.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s158.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s158.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s158.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Dev"));
                s158.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s158.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s158);

                Song s159 = new Song()
                {
                    SongTitle = "Git Breakpoint",
                    SongPrice = 2m
                };
                s159.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s159.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s159.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Coder"));
                s159.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s159);

                Song s160 = new Song()
                {
                    SongTitle = "Route Wave",
                    SongPrice = 3m
                };
                s160.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s160.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Model"));
                s160.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s160.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s160);

                Song s161 = new Song()
                {
                    SongTitle = "PrimaryKey Refactor",
                    SongPrice = 5m
                };
                s161.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s161.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Hacker"));
                s161.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s161);

                Song s162 = new Song()
                {
                    SongTitle = "Rebase Build",
                    SongPrice = 3m
                };
                s162.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s162.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s162.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Controller"));
                s162.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s162);

                Song s163 = new Song()
                {
                    SongTitle = "Swagger Sprint",
                    SongPrice = 5m
                };
                s163.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s163.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s163.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s163.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Debugger"));
                s163.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s163.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s163);

                Song s164 = new Song()
                {
                    SongTitle = "Tuple Bop",
                    SongPrice = 1m
                };
                s164.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s164.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Coder"));
                s164.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s164);

                Song s165 = new Song()
                {
                    SongTitle = "Include CacheHit",
                    SongPrice = 1m
                };
                s165.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s165.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s165.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s165.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                s165.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s165.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s165);

                Song s166 = new Song()
                {
                    SongTitle = "Dependency Retry",
                    SongPrice = 4m
                };
                s166.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s166.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s166.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Debugger"));
                s166.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s166);

                Song s167 = new Song()
                {
                    SongTitle = "OAuth Salt",
                    SongPrice = 4m
                };
                s167.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s167.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s167.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Architect"));
                s167.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s167);

                Song s168 = new Song()
                {
                    SongTitle = "Task Key",
                    SongPrice = 3m
                };
                s168.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s168.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s168.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Hacker"));
                s168.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s168.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s168);

                Song s169 = new Song()
                {
                    SongTitle = "UnitTest Debugger",
                    SongPrice = 3m
                };
                s169.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s169.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s169.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s169.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                s169.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s169.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s169);

                Song s170 = new Song()
                {
                    SongTitle = "IQueryable Build",
                    SongPrice = 1m
                };
                s170.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s170.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s170.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Architect"));
                s170.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s170.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s170);

                Song s171 = new Song()
                {
                    SongTitle = "Generic Demo",
                    SongPrice = 2m
                };
                s171.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s171.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Hacker"));
                s171.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s171);

                Song s172 = new Song()
                {
                    SongTitle = "JSON Webhook",
                    SongPrice = 2m
                };
                s172.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s172.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Builder"));
                s172.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s172);

                Song s173 = new Song()
                {
                    SongTitle = "JWT Breakpoint",
                    SongPrice = 1m
                };
                s173.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s173.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s173.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Hacker"));
                s173.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s173.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s173);

                Song s174 = new Song()
                {
                    SongTitle = "Abstract Tuning",
                    SongPrice = 4m
                };
                s174.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s174.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s174.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Ninja"));
                s174.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s174);

                Song s175 = new Song()
                {
                    SongTitle = "Cascade Wave",
                    SongPrice = 4m
                };
                s175.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s175.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Controller"));
                s175.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s175.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s175);

                Song s176 = new Song()
                {
                    SongTitle = "DbContext Breakpoint",
                    SongPrice = 5m
                };
                s176.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s176.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s176.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s176.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Tester"));
                s176.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s176.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s176.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s176);

                Song s177 = new Song()
                {
                    SongTitle = "Lambda Overload",
                    SongPrice = 3m
                };
                s177.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s177.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s177.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Ninja"));
                s177.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s177);

                Song s178 = new Song()
                {
                    SongTitle = "Swagger Bop",
                    SongPrice = 3m
                };
                s178.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s178.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s178.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s178.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Mapper"));
                s178.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s178);

                Song s179 = new Song()
                {
                    SongTitle = "Abstract Latency",
                    SongPrice = 2m
                };
                s179.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s179.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s179.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Mapper"));
                s179.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s179);

                Song s180 = new Song()
                {
                    SongTitle = "JSON Cipher",
                    SongPrice = 2m
                };
                s180.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s180.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s180.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Model"));
                s180.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s180);

                Song s181 = new Song()
                {
                    SongTitle = "Partial Standup",
                    SongPrice = 4m
                };
                s181.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s181.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s181.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em View"));
                s181.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s181.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s181);

                Song s182 = new Song()
                {
                    SongTitle = "Docker Bop",
                    SongPrice = 3m
                };
                s182.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s182.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s182.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s182.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Dev"));
                s182.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s182.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s182.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s182);

                Song s183 = new Song()
                {
                    SongTitle = "Controller Token",
                    SongPrice = 5m
                };
                s183.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s183.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s183.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Builder"));
                s183.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s183);

                Song s184 = new Song()
                {
                    SongTitle = "Commit Salt",
                    SongPrice = 1m
                };
                s184.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s184.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s184.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Mapper"));
                s184.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s184.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s184);

                Song s185 = new Song()
                {
                    SongTitle = "Merge Backoff",
                    SongPrice = 3m
                };
                s185.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s185.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s185.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s185.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                s185.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s185);

                Song s186 = new Song()
                {
                    SongTitle = "Rebase Retrospective",
                    SongPrice = 1m
                };
                s186.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s186.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s186.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Controller"));
                s186.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s186.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s186);

                Song s187 = new Song()
                {
                    SongTitle = "Tuple Uptime",
                    SongPrice = 3m
                };
                s187.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s187.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s187.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Coder"));
                s187.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s187);

                Song s188 = new Song()
                {
                    SongTitle = "C# Debugger",
                    SongPrice = 3m
                };
                s188.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s188.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Builder"));
                s188.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s188.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s188);

                Song s189 = new Song()
                {
                    SongTitle = "PrimaryKey Throttling",
                    SongPrice = 5m
                };
                s189.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s189.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s189.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                s189.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s189.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s189);

                Song s190 = new Song()
                {
                    SongTitle = "Delegate Cipher",
                    SongPrice = 5m
                };
                s190.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s190.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Coder"));
                s190.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s190);

                Song s191 = new Song()
                {
                    SongTitle = "Fixture Token",
                    SongPrice = 3m
                };
                s191.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s191.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s191.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta View"));
                s191.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s191);

                Song s192 = new Song()
                {
                    SongTitle = "SQL Anthem",
                    SongPrice = 3m
                };
                s192.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s192.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Builder"));
                s192.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s192.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s192);

                Song s193 = new Song()
                {
                    SongTitle = "Razor Timeout",
                    SongPrice = 1m
                };
                s193.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s193.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Builder"));
                s193.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s193.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s193);

                Song s194 = new Song()
                {
                    SongTitle = "Route Jam",
                    SongPrice = 2m
                };
                s194.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s194.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Controller"));
                s194.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s194);

                Song s195 = new Song()
                {
                    SongTitle = "ThenInclude Pipeline",
                    SongPrice = 1m
                };
                s195.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s195.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s195.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s195.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Builder"));
                s195.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s195);

                Song s196 = new Song()
                {
                    SongTitle = "Scaffold Throttling",
                    SongPrice = 5m
                };
                s196.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s196.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s196.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s196.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Dev"));
                s196.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s196);

                Song s197 = new Song()
                {
                    SongTitle = "Controller Endpoint",
                    SongPrice = 4m
                };
                s197.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s197.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s197.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s197.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Architect"));
                s197.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s197);

                Song s198 = new Song()
                {
                    SongTitle = "Mock Release",
                    SongPrice = 4m
                };
                s198.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s198.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s198.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Hacker"));
                s198.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s198.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s198);

                Song s199 = new Song()
                {
                    SongTitle = "Partial Debugger",
                    SongPrice = 3m
                };
                s199.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s199.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Architect"));
                s199.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s199);

                Song s200 = new Song()
                {
                    SongTitle = "Lambda Token",
                    SongPrice = 5m
                };
                s200.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s200.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s200.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Hacker"));
                s200.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s200.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s200);

                Song s201 = new Song()
                {
                    SongTitle = "Scaffold Blues",
                    SongPrice = 3m
                };
                s201.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s201.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s201.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Coder"));
                s201.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s201.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s201);

                Song s202 = new Song()
                {
                    SongTitle = "RazorPage Bop",
                    SongPrice = 3m
                };
                s202.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s202.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s202.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s202.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Model"));
                s202.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s202.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s202);

                Song s203 = new Song()
                {
                    SongTitle = "REST Demo",
                    SongPrice = 3m
                };
                s203.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s203.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee View"));
                s203.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s203.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s203.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s203);

                Song s204 = new Song()
                {
                    SongTitle = "Container Wave",
                    SongPrice = 5m
                };
                s204.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s204.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s204.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta View"));
                s204.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s204);

                Song s205 = new Song()
                {
                    SongTitle = "Git Hash",
                    SongPrice = 4m
                };
                s205.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s205.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s205.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                s205.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s205.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s205);

                Song s206 = new Song()
                {
                    SongTitle = "Policy Funk",
                    SongPrice = 3m
                };
                s206.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s206.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s206.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s206.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                s206.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s206);

                Song s207 = new Song()
                {
                    SongTitle = "Docker Release",
                    SongPrice = 4m
                };
                s207.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s207.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay View"));
                s207.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s207.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s207);

                Song s208 = new Song()
                {
                    SongTitle = "Lambda Hotfix",
                    SongPrice = 5m
                };
                s208.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s208.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Hacker"));
                s208.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s208.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s208);

                Song s209 = new Song()
                {
                    SongTitle = "Swagger Salt",
                    SongPrice = 1m
                };
                s209.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s209.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Builder"));
                s209.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s209);

                Song s210 = new Song()
                {
                    SongTitle = "ThenInclude Exception",
                    SongPrice = 2m
                };
                s210.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s210.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s210.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Dev"));
                s210.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s210.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s210.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s210);

                Song s211 = new Song()
                {
                    SongTitle = "Cookie Banger",
                    SongPrice = 2m
                };
                s211.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s211.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Coder"));
                s211.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s211.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s211);

                Song s212 = new Song()
                {
                    SongTitle = "SessionState Funk",
                    SongPrice = 4m
                };
                s212.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s212.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s212.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Coder"));
                s212.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s212);

                Song s213 = new Song()
                {
                    SongTitle = "Await Suite",
                    SongPrice = 2m
                };
                s213.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s213.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s213.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee View"));
                s213.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s213.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s213.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s213);

                Song s214 = new Song()
                {
                    SongTitle = "Filter Drop",
                    SongPrice = 1m
                };
                s214.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s214.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s214.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Builder"));
                s214.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s214);

                Song s215 = new Song()
                {
                    SongTitle = "Bootstrap Wave",
                    SongPrice = 5m
                };
                s215.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s215.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle View"));
                s215.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s215.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s215.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s215);

                Song s216 = new Song()
                {
                    SongTitle = "Role Secret",
                    SongPrice = 4m
                };
                s216.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s216.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s216.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s216.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Mapper"));
                s216.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s216);

                Song s217 = new Song()
                {
                    SongTitle = "Index Overload",
                    SongPrice = 1m
                };
                s217.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s217.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Tester"));
                s217.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s217);

                Song s218 = new Song()
                {
                    SongTitle = "Policy Suite",
                    SongPrice = 1m
                };
                s218.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s218.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Mapper"));
                s218.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s218);

                Song s219 = new Song()
                {
                    SongTitle = "OAuth Wave",
                    SongPrice = 1m
                };
                s219.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s219.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Model"));
                s219.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s219);

                Song s220 = new Song()
                {
                    SongTitle = "Bootstrap Remix",
                    SongPrice = 2m
                };
                s220.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s220.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Builder"));
                s220.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s220.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s220);

                Song s221 = new Song()
                {
                    SongTitle = "Commit Key",
                    SongPrice = 5m
                };
                s221.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s221.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em View"));
                s221.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s221);

                Song s222 = new Song()
                {
                    SongTitle = "Join Backoff",
                    SongPrice = 1m
                };
                s222.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s222.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s222.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Dev"));
                s222.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s222.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s222);

                Song s223 = new Song()
                {
                    SongTitle = "Fixture Debugger",
                    SongPrice = 5m
                };
                s223.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s223.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s223.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Builder"));
                s223.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s223.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s223.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s223);

                Song s224 = new Song()
                {
                    SongTitle = "Role Breakpoint",
                    SongPrice = 5m
                };
                s224.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s224.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Ninja"));
                s224.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s224.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s224);

                Song s225 = new Song()
                {
                    SongTitle = "Dependency Patch",
                    SongPrice = 2m
                };
                s225.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s225.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s225.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Mapper"));
                s225.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s225.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s225);

                Song s226 = new Song()
                {
                    SongTitle = "Fixture Pipeline",
                    SongPrice = 2m
                };
                s226.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s226.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s226.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Dev"));
                s226.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s226);

                Song s227 = new Song()
                {
                    SongTitle = "Partial Wave",
                    SongPrice = 4m
                };
                s227.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s227.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Ninja"));
                s227.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s227.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s227);

                Song s228 = new Song()
                {
                    SongTitle = "Cache Refactor",
                    SongPrice = 5m
                };
                s228.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s228.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Controller"));
                s228.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s228);

                Song s229 = new Song()
                {
                    SongTitle = "OrderBy Refactor",
                    SongPrice = 5m
                };
                s229.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s229.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Hacker"));
                s229.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s229.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s229.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s229);

                Song s230 = new Song()
                {
                    SongTitle = "TagHelper Demo",
                    SongPrice = 2m
                };
                s230.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s230.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Model"));
                s230.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s230);

                Song s231 = new Song()
                {
                    SongTitle = "XML Remix",
                    SongPrice = 4m
                };
                s231.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s231.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Architect"));
                s231.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s231);

                Song s232 = new Song()
                {
                    SongTitle = "Await CacheHit",
                    SongPrice = 5m
                };
                s232.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s232.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s232.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Tester"));
                s232.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s232);

                Song s233 = new Song()
                {
                    SongTitle = "GroupBy Drop",
                    SongPrice = 5m
                };
                s233.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s233.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Tester"));
                s233.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s233.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s233);

                Song s234 = new Song()
                {
                    SongTitle = "Identity Miss",
                    SongPrice = 2m
                };
                s234.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s234.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Debugger"));
                s234.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s234.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s234);

                Song s235 = new Song()
                {
                    SongTitle = "Delegate Remix",
                    SongPrice = 2m
                };
                s235.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s235.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s235.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s235.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Hacker"));
                s235.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s235.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s235);

                Song s236 = new Song()
                {
                    SongTitle = "Controller Funk",
                    SongPrice = 3m
                };
                s236.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s236.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s236.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s236.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Controller"));
                s236.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s236.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s236);

                Song s237 = new Song()
                {
                    SongTitle = "JSON Release",
                    SongPrice = 2m
                };
                s237.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s237.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Builder"));
                s237.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s237);

                Song s238 = new Song()
                {
                    SongTitle = "Push Throttling",
                    SongPrice = 4m
                };
                s238.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s238.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s238.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s238.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                s238.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s238);

                Song s239 = new Song()
                {
                    SongTitle = "XML CacheHit",
                    SongPrice = 1m
                };
                s239.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s239.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s239.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Debugger"));
                s239.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s239.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s239.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s239);

                Song s240 = new Song()
                {
                    SongTitle = "Dependency Overload",
                    SongPrice = 4m
                };
                s240.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s240.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Builder"));
                s240.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s240.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s240.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s240);

                Song s241 = new Song()
                {
                    SongTitle = "ThenInclude Deploy",
                    SongPrice = 2m
                };
                s241.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s241.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Builder"));
                s241.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                s241.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s241.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s241);

                Song s242 = new Song()
                {
                    SongTitle = "GroupBy Timeout",
                    SongPrice = 4m
                };
                s242.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s242.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s242.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Coder"));
                s242.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s242);

                Song s243 = new Song()
                {
                    SongTitle = "Commit Warmup",
                    SongPrice = 4m
                };
                s243.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s243.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s243.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Ninja"));
                s243.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s243.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s243);

                Song s244 = new Song()
                {
                    SongTitle = "Mock Secret",
                    SongPrice = 5m
                };
                s244.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s244.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s244.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s244.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee View"));
                s244.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s244.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s244);

                Song s245 = new Song()
                {
                    SongTitle = "Git Debugger",
                    SongPrice = 3m
                };
                s245.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s245.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s245.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s245.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Model"));
                s245.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s245);

                Song s246 = new Song()
                {
                    SongTitle = "Select Remix",
                    SongPrice = 3m
                };
                s246.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s246.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Model"));
                s246.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s246.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s246);

                Song s247 = new Song()
                {
                    SongTitle = "View Bop",
                    SongPrice = 5m
                };
                s247.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s247.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s247.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Mapper"));
                s247.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s247.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s247);

                Song s248 = new Song()
                {
                    SongTitle = "Route Retry",
                    SongPrice = 1m
                };
                s248.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s248.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Debugger"));
                s248.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                s248.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s248.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s248);

                Song s249 = new Song()
                {
                    SongTitle = "Filter Overload",
                    SongPrice = 3m
                };
                s249.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s249.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s249.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Controller"));
                s249.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                s249.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s249.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s249);

                Song s250 = new Song()
                {
                    SongTitle = "Fixture Nugget",
                    SongPrice = 2m
                };
                s250.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s250.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s250.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Tester"));
                s250.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                s250.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s250.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s250);

                Song s251 = new Song()
                {
                    SongTitle = "Claim Timeout",
                    SongPrice = 4m
                };
                s251.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s251.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s251.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s251.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Debugger"));
                s251.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s251);

                Song s252 = new Song()
                {
                    SongTitle = "Container Blues",
                    SongPrice = 3m
                };
                s252.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s252.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee View"));
                s252.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s252.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s252);

                Song s253 = new Song()
                {
                    SongTitle = "TempData Salt",
                    SongPrice = 2m
                };
                s253.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s253.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s253.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Tester"));
                s253.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Songs.Add(s253);

                Song s254 = new Song()
                {
                    SongTitle = "Where Backoff",
                    SongPrice = 4m
                };
                s254.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s254.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Controller"));
                s254.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s254);

                Song s255 = new Song()
                {
                    SongTitle = "Session Pipeline",
                    SongPrice = 5m
                };
                s255.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s255.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s255.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Debugger"));
                s255.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s255);

                Song s256 = new Song()
                {
                    SongTitle = "Validation Loop",
                    SongPrice = 2m
                };
                s256.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s256.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s256.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Tester"));
                s256.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s256);

                Song s257 = new Song()
                {
                    SongTitle = "Claim Ballad",
                    SongPrice = 1m
                };
                s257.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s257.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s257.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Mapper"));
                s257.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s257.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s257.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s257);

                Song s258 = new Song()
                {
                    SongTitle = "Cascade Ballad",
                    SongPrice = 2m
                };
                s258.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s258.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Model"));
                s258.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Songs.Add(s258);

                Song s259 = new Song()
                {
                    SongTitle = "Cache Handshake",
                    SongPrice = 1m
                };
                s259.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s259.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Dev"));
                s259.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s259);

                Song s260 = new Song()
                {
                    SongTitle = "Container Timeout",
                    SongPrice = 1m
                };
                s260.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s260.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha Coder"));
                s260.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s260.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s260);

                Song s261 = new Song()
                {
                    SongTitle = "Session Exception",
                    SongPrice = 1m
                };
                s261.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s261.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s261.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Mapper"));
                s261.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                s261.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s261.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s261);

                Song s262 = new Song()
                {
                    SongTitle = "Async Sprint",
                    SongPrice = 4m
                };
                s262.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s262.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s262.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Coder"));
                s262.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s262.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Songs.Add(s262);

                Song s263 = new Song()
                {
                    SongTitle = "RazorPage Hotfix",
                    SongPrice = 4m
                };
                s263.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s263.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s263.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Debugger"));
                s263.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s263.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s263);

                Song s264 = new Song()
                {
                    SongTitle = "LeftJoin Beat",
                    SongPrice = 2m
                };
                s264.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s264.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Mapper"));
                s264.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Songs.Add(s264);

                Song s265 = new Song()
                {
                    SongTitle = "Partial Jam",
                    SongPrice = 2m
                };
                s265.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s265.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Architect"));
                s265.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s265.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s265.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s265);

                Song s266 = new Song()
                {
                    SongTitle = "Async Wave",
                    SongPrice = 2m
                };
                s266.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s266.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s266.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Builder"));
                s266.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s266.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s266.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s266);

                Song s267 = new Song()
                {
                    SongTitle = "Interface Throughput",
                    SongPrice = 3m
                };
                s267.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s267.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s267.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Gamma Debugger"));
                s267.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s267.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s267);

                Song s268 = new Song()
                {
                    SongTitle = "SessionState Uptime",
                    SongPrice = 5m
                };
                s268.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s268.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s268.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why Coder"));
                s268.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s268.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                s268.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Songs.Add(s268);

                Song s269 = new Song()
                {
                    SongTitle = "Layout Pipeline",
                    SongPrice = 5m
                };
                s269.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s269.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s269.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Zee Model"));
                s269.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                s269.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                s269.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s269);

                Song s270 = new Song()
                {
                    SongTitle = "Session Flow",
                    SongPrice = 1m
                };
                s270.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s270.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s270.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Tester"));
                s270.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                s270.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s270);

                Song s271 = new Song()
                {
                    SongTitle = "Policy Loop",
                    SongPrice = 1m
                };
                s271.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s271.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s271.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Tester"));
                s271.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s271);

                Song s272 = new Song()
                {
                    SongTitle = "RightJoin Remix",
                    SongPrice = 2m
                };
                s272.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s272.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Model"));
                s272.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s272);

                Song s273 = new Song()
                {
                    SongTitle = "Container Secret",
                    SongPrice = 2m
                };
                s273.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s273.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s273.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Pro Coder"));
                s273.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s273);

                Song s274 = new Song()
                {
                    SongTitle = "Rebase Ballad",
                    SongPrice = 2m
                };
                s274.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s274.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s274.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Why View"));
                s274.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s274.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s274.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s274);

                Song s275 = new Song()
                {
                    SongTitle = "Integration Warmup",
                    SongPrice = 1m
                };
                s275.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s275.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s275.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Dee Coder"));
                s275.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s275);

                Song s276 = new Song()
                {
                    SongTitle = "Task Refactor",
                    SongPrice = 3m
                };
                s276.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s276.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s276.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta Architect"));
                s276.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s276);

                Song s277 = new Song()
                {
                    SongTitle = "Middleware Demo",
                    SongPrice = 3m
                };
                s277.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s277.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Controller"));
                s277.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s277.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                s277.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s277);

                Song s278 = new Song()
                {
                    SongTitle = "Query Deploy",
                    SongPrice = 3m
                };
                s278.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s278.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Model"));
                s278.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s278);

                Song s279 = new Song()
                {
                    SongTitle = "UnitTest Tuning",
                    SongPrice = 2m
                };
                s279.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s279.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s279.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Final Release"));
                s279.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are Mapper"));
                s279.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s279.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                s279.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Songs.Add(s279);

                Song s280 = new Song()
                {
                    SongTitle = "ForeignKey Throughput",
                    SongPrice = 3m
                };
                s280.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s280.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s280.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s280.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Tee Debugger"));
                s280.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                s280.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s280);

                Song s281 = new Song()
                {
                    SongTitle = "Pull Anthem",
                    SongPrice = 2m
                };
                s281.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s281.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Tester"));
                s281.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Songs.Add(s281);

                Song s282 = new Song()
                {
                    SongTitle = "OpenID Blues",
                    SongPrice = 5m
                };
                s282.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s282.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s282.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Builder"));
                s282.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s282);

                Song s283 = new Song()
                {
                    SongTitle = "Model Cipher",
                    SongPrice = 4m
                };
                s283.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Diagram Dreams"));
                s283.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Coder"));
                s283.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s283);

                Song s284 = new Song()
                {
                    SongTitle = "Container Uptime",
                    SongPrice = 4m
                };
                s284.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Refactor Rhapsody"));
                s284.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Em Hacker"));
                s284.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s284.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                s284.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s284);

                Song s285 = new Song()
                {
                    SongTitle = "Abstract Sprint",
                    SongPrice = 1m
                };
                s285.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s285.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Controller"));
                s285.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Songs.Add(s285);

                Song s286 = new Song()
                {
                    SongTitle = "InnerJoin Jam",
                    SongPrice = 5m
                };
                s286.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s286.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee View"));
                s286.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s286);

                Song s287 = new Song()
                {
                    SongTitle = "Interface Throttling",
                    SongPrice = 5m
                };
                s287.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s287.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s287.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Mapper"));
                s287.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Songs.Add(s287);

                Song s288 = new Song()
                {
                    SongTitle = "Layout Nonce",
                    SongPrice = 5m
                };
                s288.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s288.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s288.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay-Tee Dev"));
                s288.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s288.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Songs.Add(s288);

                Song s289 = new Song()
                {
                    SongTitle = "Commit Secret",
                    SongPrice = 5m
                };
                s289.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s289.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Unit Test Utopia"));
                s289.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Are View"));
                s289.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                s289.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Songs.Add(s289);

                Song s290 = new Song()
                {
                    SongTitle = "REST Patch",
                    SongPrice = 4m
                };
                s290.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s290.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Kay Mapper"));
                s290.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                s290.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s290);

                Song s291 = new Song()
                {
                    SongTitle = "C# Patch",
                    SongPrice = 2m
                };
                s291.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Sprint 1"));
                s291.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Wireframe Weekend"));
                s291.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Elle Architect"));
                s291.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                s291.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Songs.Add(s291);

                Song s292 = new Song()
                {
                    SongTitle = "ViewData Warmup",
                    SongPrice = 3m
                };
                s292.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s292.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s292.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Jay Model"));
                s292.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Songs.Add(s292);

                Song s293 = new Song()
                {
                    SongTitle = "SessionState Exception",
                    SongPrice = 4m
                };
                s293.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "TA Sessions"));
                s293.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Alpha View"));
                s293.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Songs.Add(s293);

                Song s294 = new Song()
                {
                    SongTitle = "Interface Key",
                    SongPrice = 2m
                };
                s294.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours"));
                s294.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Midterm Mix"));
                s294.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Bee Builder"));
                s294.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Songs.Add(s294);

                Song s295 = new Song()
                {
                    SongTitle = "Delegate Throughput",
                    SongPrice = 2m
                };
                s295.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Code Freeze"));
                s295.Albums.Add(db.Albums.FirstOrDefault(a => a.AlbumName == "Bug Bash"));
                s295.Artists.Add(db.Artists.FirstOrDefault(a => a.ArtistName == "Beta View"));
                s295.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Songs.Add(s295);


                foreach (Song songToAdd in Songs)
                {
                    Song dbSong = db.Songs.FirstOrDefault(g => g.SongTitle == songToAdd.SongTitle);
                    if (dbSong == null)
                    {
                        db.Songs.Add(dbSong);
                        db.SaveChanges();
                        intSongsAdded += 1;
                    }
                }

            }
            catch
            {
                String msg = "Songs Added: " + intSongsAdded.ToString();
                throw new InvalidOperationException(msg);
            }
        }
    }
}
