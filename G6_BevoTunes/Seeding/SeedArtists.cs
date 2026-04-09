using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Seeding
{
    public static class SeedArtists
    {
        public static void SeedAllArtists(AppDbContext db)
        {
            // check to see if all the genres have already been added
            if (db.Artists.Count() == 211)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Artist record count is already 211!");
                throw ex;
            }
            Int32 intArtistsAdded = 0;
            try
            {
                //Create a list of artist
                List<Artist> Artists = new List<Artist>();

                Artist a1 = new Artist()
                {
                    ArtistName = "Vanilla Ice",
                };
                a1.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a1.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a1);

                Artist a2 = new Artist()
                {
                    ArtistName = "Timbaland",
                };
                a2.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a2.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a2);

                Artist a3 = new Artist()
                {
                    ArtistName = "Doechii",
                };
                a3.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a3);

                Artist a4 = new Artist()
                {
                    ArtistName = "Quality Control",
                };
                a4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a4.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a4);

                Artist a5 = new Artist()
                {
                    ArtistName = "Shubh",
                };
                a5.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a5.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a5);

                Artist a6 = new Artist()
                {
                    ArtistName = "Lil Baby",
                };
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a6.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a6);

                Artist a7 = new Artist()
                {
                    ArtistName = "Mc Delux",
                };
                a7.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a7.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a7);

                Artist a8 = new Artist()
                {
                    ArtistName = "Daft Punk",
                };
                a8.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a8);

                Artist a9 = new Artist()
                {
                    ArtistName = "Nelly",
                };
                a9.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a9.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a9.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a9);

                Artist a10 = new Artist()
                {
                    ArtistName = "Sean Paul",
                };
                a10.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a10.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a10);

                Artist a11 = new Artist()
                {
                    ArtistName = "Mc Pogba",
                };
                a11.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a11.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a11);

                Artist a12 = new Artist()
                {
                    ArtistName = "A Boogie Wit da Hoodie",
                };
                a12.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a12.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a12);

                Artist a13 = new Artist()
                {
                    ArtistName = "Jack Harlow",
                };
                a13.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a13);

                Artist a14 = new Artist()
                {
                    ArtistName = "Luis R Conriquez",
                };
                a14.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a14);

                Artist a15 = new Artist()
                {
                    ArtistName = "Eminem",
                };
                a15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a15.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a15);

                Artist a16 = new Artist()
                {
                    ArtistName = "Ice Cube",
                };
                a16.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a16);

                Artist a17 = new Artist()
                {
                    ArtistName = "Queen",
                };
                a17.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a17.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a17.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a17);

                Artist a18 = new Artist()
                {
                    ArtistName = "Bob Marley & The Wailers",
                };
                a18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a18.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a18);

                Artist a19 = new Artist()
                {
                    ArtistName = "Migos",
                };
                a19.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a19);

                Artist a20 = new Artist()
                {
                    ArtistName = "KAROL G",
                };
                a20.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a20.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a20);

                Artist a21 = new Artist()
                {
                    ArtistName = "Dave",
                };
                a21.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a21.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a21.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a21);

                Artist a22 = new Artist()
                {
                    ArtistName = "XXXTENTACION",
                };
                a22.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a22.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a22.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a22);

                Artist a23 = new Artist()
                {
                    ArtistName = "Michael Jackson",
                };
                a23.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a23);

                Artist a24 = new Artist()
                {
                    ArtistName = "Lil Yachty",
                };
                a24.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a24.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a24);

                Artist a25 = new Artist()
                {
                    ArtistName = "MC Kevin o Chris",
                };
                a25.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a25.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a25.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a25);

                Artist a26 = new Artist()
                {
                    ArtistName = "Outkast",
                };
                a26.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a26.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a26);

                Artist a27 = new Artist()
                {
                    ArtistName = "Future",
                };
                a27.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a27);

                Artist a28 = new Artist()
                {
                    ArtistName = "Gunna",
                };
                a28.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a28.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a28);

                Artist a29 = new Artist()
                {
                    ArtistName = "Bad Bunny",
                };
                a29.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a29.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a29.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a29.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a29.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Artists.Add(a29);

                Artist a30 = new Artist()
                {
                    ArtistName = "Central Cee",
                };
                a30.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a30.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a30);

                Artist a31 = new Artist()
                {
                    ArtistName = "Mary J. Blige",
                };
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a31.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a31);

                Artist a32 = new Artist()
                {
                    ArtistName = "21 Savage",
                };
                a32.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a32.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a32);

                Artist a33 = new Artist()
                {
                    ArtistName = "BigXthaPlug",
                };
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a33.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a33);

                Artist a34 = new Artist()
                {
                    ArtistName = "The Notorious B.I.G.",
                };
                a34.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a34.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a34);

                Artist a35 = new Artist()
                {
                    ArtistName = "Big Pun",
                };
                a35.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a35);

                Artist a36 = new Artist()
                {
                    ArtistName = "Cazzu",
                };
                a36.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a36.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a36.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a36);

                Artist a37 = new Artist()
                {
                    ArtistName = "Rex Orange County",
                };
                a37.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a37.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a37);

                Artist a38 = new Artist()
                {
                    ArtistName = "Kendrick Lamar",
                };
                a38.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a38.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a38.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a38);

                Artist a39 = new Artist()
                {
                    ArtistName = "J. Cole",
                };
                a39.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a39.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a39);

                Artist a40 = new Artist()
                {
                    ArtistName = "Prince",
                };
                a40.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a40.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a40);

                Artist a41 = new Artist()
                {
                    ArtistName = "Smur Lee",
                };
                a41.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a41.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a41);

                Artist a42 = new Artist()
                {
                    ArtistName = "Cypress Hill",
                };
                a42.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a42.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a42);

                Artist a43 = new Artist()
                {
                    ArtistName = "Roddy Ricch",
                };
                a43.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a43);

                Artist a44 = new Artist()
                {
                    ArtistName = "Mc Rf",
                };
                a44.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a44);

                Artist a45 = new Artist()
                {
                    ArtistName = "MC's Zaac",
                };
                a45.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a45);

                Artist a46 = new Artist()
                {
                    ArtistName = "Jul",
                };
                a46.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a46);

                Artist a47 = new Artist()
                {
                    ArtistName = "JAE5",
                };
                a47.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a47);

                Artist a48 = new Artist()
                {
                    ArtistName = "Fireboy DML",
                };
                a48.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a48);

                Artist a49 = new Artist()
                {
                    ArtistName = "TNK MusiQ",
                };
                a49.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a49.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a49);

                Artist a50 = new Artist()
                {
                    ArtistName = "Lil Frosh",
                };
                a50.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a50.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a50.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a50);

                Artist a51 = new Artist()
                {
                    ArtistName = "Saint",
                };
                a51.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a51.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a51.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a51);

                Artist a52 = new Artist()
                {
                    ArtistName = "Killloane",
                };
                a52.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a52);

                Artist a53 = new Artist()
                {
                    ArtistName = "Naira Marley",
                };
                a53.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a53.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a53.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a53.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a53);

                Artist a54 = new Artist()
                {
                    ArtistName = "Alison Hinds",
                };
                a54.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a54);

                Artist a55 = new Artist()
                {
                    ArtistName = "MC Mazzie",
                };
                a55.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a55.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a55);

                Artist a56 = new Artist()
                {
                    ArtistName = "Ice Prince",
                };
                a56.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a56);

                Artist a57 = new Artist()
                {
                    ArtistName = "Inventor Ace",
                };
                a57.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a57);

                Artist a58 = new Artist()
                {
                    ArtistName = "Machel Montano",
                };
                a58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a58.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a58);

                Artist a59 = new Artist()
                {
                    ArtistName = "Jerry Di",
                };
                a59.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a59.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a59);

                Artist a60 = new Artist()
                {
                    ArtistName = "Burna Boy",
                };
                a60.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a60);

                Artist a61 = new Artist()
                {
                    ArtistName = "Key Largo",
                };
                a61.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a61.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a61.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a61.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a61);

                Artist a62 = new Artist()
                {
                    ArtistName = "ODUMODUBLVCK",
                };
                a62.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a62.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a62);

                Artist a63 = new Artist()
                {
                    ArtistName = "love_eight",
                };
                a63.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a63);

                Artist a64 = new Artist()
                {
                    ArtistName = "HOUDI",
                };
                a64.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a64.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a64);

                Artist a65 = new Artist()
                {
                    ArtistName = "Humble Francis",
                };
                a65.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a65);

                Artist a66 = new Artist()
                {
                    ArtistName = "Kizz Daniel",
                };
                a66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a66.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a66);

                Artist a67 = new Artist()
                {
                    ArtistName = "C. Tangana",
                };
                a67.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a67.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a67.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a67);

                Artist a68 = new Artist()
                {
                    ArtistName = "Zinoleesky",
                };
                a68.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a68);

                Artist a69 = new Artist()
                {
                    ArtistName = "Diam's",
                };
                a69.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a69.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a69.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a69);

                Artist a70 = new Artist()
                {
                    ArtistName = "The Dixie Cups",
                };
                a70.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a70.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a70.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a70);

                Artist a71 = new Artist()
                {
                    ArtistName = "DJ Guih Da ZO",
                };
                a71.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a71);

                Artist a72 = new Artist()
                {
                    ArtistName = "La Chanchona De Tito Mira",
                };
                a72.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a72.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a72);

                Artist a73 = new Artist()
                {
                    ArtistName = "Problem Child",
                };
                a73.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a73.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a73.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a73);

                Artist a74 = new Artist()
                {
                    ArtistName = "Seek",
                };
                a74.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a74.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a74);

                Artist a75 = new Artist()
                {
                    ArtistName = "Mr Eazi",
                };
                a75.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a75.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Artists.Add(a75);

                Artist a76 = new Artist()
                {
                    ArtistName = "Perry Goldfish",
                };
                a76.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a76.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a76);

                Artist a77 = new Artist()
                {
                    ArtistName = "MC Teteu",
                };
                a77.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a77.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a77);

                Artist a78 = new Artist()
                {
                    ArtistName = "Royal MusiQ",
                };
                a78.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a78.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a78.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a78);

                Artist a79 = new Artist()
                {
                    ArtistName = "2JtheRichest",
                };
                a79.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a79);

                Artist a80 = new Artist()
                {
                    ArtistName = "Akapellah",
                };
                a80.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a80.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a80);

                Artist a81 = new Artist()
                {
                    ArtistName = "Kid AlpHa",
                };
                a81.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a81);

                Artist a82 = new Artist()
                {
                    ArtistName = "Myke Towers",
                };
                a82.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a82);

                Artist a83 = new Artist()
                {
                    ArtistName = "Hammocks & Lime",
                };
                a83.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a83.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a83);

                Artist a84 = new Artist()
                {
                    ArtistName = "Olamide",
                };
                a84.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a84);

                Artist a85 = new Artist()
                {
                    ArtistName = "Ezra Collective",
                };
                a85.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a85.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a85);

                Artist a86 = new Artist()
                {
                    ArtistName = "Wizkid",
                };
                a86.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a86.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Artists.Add(a86);

                Artist a87 = new Artist()
                {
                    ArtistName = "G:sson",
                };
                a87.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a87);

                Artist a88 = new Artist()
                {
                    ArtistName = "Adam Space",
                };
                a88.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a88);

                Artist a89 = new Artist()
                {
                    ArtistName = "LoFi Waiter",
                };
                a89.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a89);

                Artist a90 = new Artist()
                {
                    ArtistName = "low&slow",
                };
                a90.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a90.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a90);

                Artist a91 = new Artist()
                {
                    ArtistName = "jaackson",
                };
                a91.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a91);

                Artist a92 = new Artist()
                {
                    ArtistName = "Chip",
                };
                a92.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a92.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a92);

                Artist a93 = new Artist()
                {
                    ArtistName = "Tee Hacker",
                };
                a93.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a93);

                Artist a94 = new Artist()
                {
                    ArtistName = "Beta Tester",
                };
                a94.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a94.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a94.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a94.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a94.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a94);

                Artist a95 = new Artist()
                {
                    ArtistName = "Alpha Ninja",
                };
                a95.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a95.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a95);

                Artist a96 = new Artist()
                {
                    ArtistName = "Tee Model",
                };
                a96.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a96.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a96);

                Artist a97 = new Artist()
                {
                    ArtistName = "Em Debugger",
                };
                a97.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a97.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a97.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a97.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a97.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a97);

                Artist a98 = new Artist()
                {
                    ArtistName = "Tee Coder",
                };
                a98.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a98.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a98.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a98);

                Artist a99 = new Artist()
                {
                    ArtistName = "Alpha Mapper",
                };
                a99.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a99.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a99.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a99);

                Artist a100 = new Artist()
                {
                    ArtistName = "Elle Hacker",
                };
                a100.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a100.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a100.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a100.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a100.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a100);

                Artist a101 = new Artist()
                {
                    ArtistName = "Are Ninja",
                };
                a101.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a101.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a101.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a101);

                Artist a102 = new Artist()
                {
                    ArtistName = "Beta Model",
                };
                a102.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a102.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a102.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a102.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a102.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Artists.Add(a102);

                Artist a103 = new Artist()
                {
                    ArtistName = "Dee Tester",
                };
                a103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a103.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a103);

                Artist a104 = new Artist()
                {
                    ArtistName = "Dee Builder",
                };
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a104.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a104);

                Artist a105 = new Artist()
                {
                    ArtistName = "Are Dev",
                };
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a105.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a105);

                Artist a106 = new Artist()
                {
                    ArtistName = "Elle Dev",
                };
                a106.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a106);

                Artist a107 = new Artist()
                {
                    ArtistName = "Bee Architect",
                };
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a107.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a107);

                Artist a108 = new Artist()
                {
                    ArtistName = "Em Hacker",
                };
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a108.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a108);

                Artist a109 = new Artist()
                {
                    ArtistName = "Jay Debugger",
                };
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a109.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a109);

                Artist a110 = new Artist()
                {
                    ArtistName = "Why View",
                };
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a110.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a110);

                Artist a111 = new Artist()
                {
                    ArtistName = "Tee View",
                };
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a111.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a111);

                Artist a112 = new Artist()
                {
                    ArtistName = "Gamma Builder",
                };
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a112.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a112);

                Artist a113 = new Artist()
                {
                    ArtistName = "Zee Mapper",
                };
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a113.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a113);

                Artist a114 = new Artist()
                {
                    ArtistName = "Dee Architect",
                };
                a114.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a114);

                Artist a115 = new Artist()
                {
                    ArtistName = "Why Coder",
                };
                a115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a115.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a115);

                Artist a116 = new Artist()
                {
                    ArtistName = "Dee View",
                };
                a116.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a116.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a116.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a116.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a116);

                Artist a117 = new Artist()
                {
                    ArtistName = "Elle Architect",
                };
                a117.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a117.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a117.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a117.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a117.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a117);

                Artist a118 = new Artist()
                {
                    ArtistName = "Beta Coder",
                };
                a118.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a118);

                Artist a119 = new Artist()
                {
                    ArtistName = "Why Model",
                };
                a119.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a119.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a119.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a119.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a119);

                Artist a120 = new Artist()
                {
                    ArtistName = "Zee View",
                };
                a120.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a120.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a120.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a120.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a120.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a120.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Artists.Add(a120);

                Artist a121 = new Artist()
                {
                    ArtistName = "Kay-Tee Hacker",
                };
                a121.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a121);

                Artist a122 = new Artist()
                {
                    ArtistName = "Alpha Builder",
                };
                a122.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a122.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a122.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a122.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a122);

                Artist a123 = new Artist()
                {
                    ArtistName = "Zee Dev",
                };
                a123.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a123.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a123.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a123.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a123);

                Artist a124 = new Artist()
                {
                    ArtistName = "Elle Model",
                };
                a124.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a124.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a124.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a124);

                Artist a125 = new Artist()
                {
                    ArtistName = "Kay Tester",
                };
                a125.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a125.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a125.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a125.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a125.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a125);

                Artist a126 = new Artist()
                {
                    ArtistName = "Pro Hacker",
                };
                a126.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a126.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a126.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a126);

                Artist a127 = new Artist()
                {
                    ArtistName = "Beta Hacker",
                };
                a127.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a127);

                Artist a128 = new Artist()
                {
                    ArtistName = "Kay Dev",
                };
                a128.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a128);

                Artist a129 = new Artist()
                {
                    ArtistName = "Pro Mapper",
                };
                a129.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a129.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a129.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a129.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a129);

                Artist a130 = new Artist()
                {
                    ArtistName = "Gamma Coder",
                };
                a130.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a130.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a130.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a130);

                Artist a131 = new Artist()
                {
                    ArtistName = "Beta Architect",
                };
                a131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a131.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a131);

                Artist a132 = new Artist()
                {
                    ArtistName = "Em View",
                };
                a132.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a132.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a132.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a132.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a132.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a132);

                Artist a133 = new Artist()
                {
                    ArtistName = "Kay Builder",
                };
                a133.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a133.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a133);

                Artist a134 = new Artist()
                {
                    ArtistName = "Dee Hacker",
                };
                a134.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a134.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a134.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a134);

                Artist a135 = new Artist()
                {
                    ArtistName = "Kay Ninja",
                };
                a135.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a135.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a135);

                Artist a136 = new Artist()
                {
                    ArtistName = "Pro Controller",
                };
                a136.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a136);

                Artist a137 = new Artist()
                {
                    ArtistName = "Beta Mapper",
                };
                a137.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a137.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a137);

                Artist a138 = new Artist()
                {
                    ArtistName = "Jay Dev",
                };
                a138.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a138.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a138);

                Artist a139 = new Artist()
                {
                    ArtistName = "Bee Coder",
                };
                a139.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a139);

                Artist a140 = new Artist()
                {
                    ArtistName = "Pro Model",
                };
                a140.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a140.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a140.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a140);

                Artist a141 = new Artist()
                {
                    ArtistName = "Bee Controller",
                };
                a141.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a141);

                Artist a142 = new Artist()
                {
                    ArtistName = "Alpha Debugger",
                };
                a142.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a142.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a142.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a142);

                Artist a143 = new Artist()
                {
                    ArtistName = "Bee Hacker",
                };
                a143.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a143.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a143.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a143.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a143);

                Artist a144 = new Artist()
                {
                    ArtistName = "Are Architect",
                };
                a144.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a144.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a144);

                Artist a145 = new Artist()
                {
                    ArtistName = "Zee Builder",
                };
                a145.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a145.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a145.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a145);

                Artist a146 = new Artist()
                {
                    ArtistName = "Are Hacker",
                };
                a146.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a146.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a146.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a146.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a146);

                Artist a147 = new Artist()
                {
                    ArtistName = "Bee Ninja",
                };
                a147.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a147);

                Artist a148 = new Artist()
                {
                    ArtistName = "Gamma Controller",
                };
                a148.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a148.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a148);

                Artist a149 = new Artist()
                {
                    ArtistName = "Tee Mapper",
                };
                a149.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a149);

                Artist a150 = new Artist()
                {
                    ArtistName = "Gamma Model",
                };
                a150.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a150);

                Artist a151 = new Artist()
                {
                    ArtistName = "Kay-Tee Mapper",
                };
                a151.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a151.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a151);

                Artist a152 = new Artist()
                {
                    ArtistName = "Elle Controller",
                };
                a152.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a152.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a152);

                Artist a153 = new Artist()
                {
                    ArtistName = "Dee Coder",
                };
                a153.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a153.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a153.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a153);

                Artist a154 = new Artist()
                {
                    ArtistName = "Why Builder",
                };
                a154.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a154.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a154);

                Artist a155 = new Artist()
                {
                    ArtistName = "Jay Coder",
                };
                a155.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a155);

                Artist a156 = new Artist()
                {
                    ArtistName = "Beta View",
                };
                a156.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a156.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a156.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a156);

                Artist a157 = new Artist()
                {
                    ArtistName = "Tee Builder",
                };
                a157.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a157.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a157.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a157.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                a157.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a157.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a157);

                Artist a158 = new Artist()
                {
                    ArtistName = "Jay Controller",
                };
                a158.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a158.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a158.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a158.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a158);

                Artist a159 = new Artist()
                {
                    ArtistName = "Pro Dev",
                };
                a159.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a159);

                Artist a160 = new Artist()
                {
                    ArtistName = "Kay-Tee Architect",
                };
                a160.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a160);

                Artist a161 = new Artist()
                {
                    ArtistName = "Zee Hacker",
                };
                a161.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a161.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a161);

                Artist a162 = new Artist()
                {
                    ArtistName = "Tee Architect",
                };
                a162.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a162);

                Artist a163 = new Artist()
                {
                    ArtistName = "Pro Coder",
                };
                a163.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a163.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a163.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a163);

                Artist a164 = new Artist()
                {
                    ArtistName = "Kay-Tee View",
                };
                a164.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a164.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a164.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a164);

                Artist a165 = new Artist()
                {
                    ArtistName = "Em Builder",
                };
                a165.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a165.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a165.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a165.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a165);

                Artist a166 = new Artist()
                {
                    ArtistName = "Kay View",
                };
                a166.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a166.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a166);

                Artist a167 = new Artist()
                {
                    ArtistName = "Beta Builder",
                };
                a167.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a167.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a167.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a167.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a167);

                Artist a168 = new Artist()
                {
                    ArtistName = "Alpha Coder",
                };
                a168.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a168.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a168.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a168.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a168);

                Artist a169 = new Artist()
                {
                    ArtistName = "Bee View",
                };
                a169.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a169.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a169.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                Artists.Add(a169);

                Artist a170 = new Artist()
                {
                    ArtistName = "Elle View",
                };
                a170.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a170.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a170.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a170);

                Artist a171 = new Artist()
                {
                    ArtistName = "Kay Mapper",
                };
                a171.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a171.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a171.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a171);

                Artist a172 = new Artist()
                {
                    ArtistName = "Elle Tester",
                };
                a172.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a172);

                Artist a173 = new Artist()
                {
                    ArtistName = "Bee Mapper",
                };
                a173.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a173.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                a173.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a173.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                a173.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a173);

                Artist a174 = new Artist()
                {
                    ArtistName = "Bee Model",
                };
                a174.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a174);

                Artist a175 = new Artist()
                {
                    ArtistName = "Kay-Tee Dev",
                };
                a175.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a175.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a175.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "reggae"));
                a175.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a175);

                Artist a176 = new Artist()
                {
                    ArtistName = "Why Ninja",
                };
                a176.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a176.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a176.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a176);

                Artist a177 = new Artist()
                {
                    ArtistName = "Jay Mapper",
                };
                a177.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a177.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a177);

                Artist a178 = new Artist()
                {
                    ArtistName = "Em Dev",
                };
                a178.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a178);

                Artist a179 = new Artist()
                {
                    ArtistName = "Are Controller",
                };
                a179.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a179.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a179);

                Artist a180 = new Artist()
                {
                    ArtistName = "Dee Model",
                };
                a180.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                Artists.Add(a180);

                Artist a181 = new Artist()
                {
                    ArtistName = "Why Architect",
                };
                a181.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a181);

                Artist a182 = new Artist()
                {
                    ArtistName = "Why Tester",
                };
                a182.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a182);

                Artist a183 = new Artist()
                {
                    ArtistName = "Bee Debugger",
                };
                a183.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a183.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a183);

                Artist a184 = new Artist()
                {
                    ArtistName = "Em Controller",
                };
                a184.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a184.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a184);

                Artist a185 = new Artist()
                {
                    ArtistName = "Kay-Tee Builder",
                };
                a185.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a185);

                Artist a186 = new Artist()
                {
                    ArtistName = "Are Builder",
                };
                a186.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a186.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a186.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                Artists.Add(a186);

                Artist a187 = new Artist()
                {
                    ArtistName = "Beta Ninja",
                };
                a187.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a187.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a187);

                Artist a188 = new Artist()
                {
                    ArtistName = "Are Mapper",
                };
                a188.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a188.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a188.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a188.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a188);

                Artist a189 = new Artist()
                {
                    ArtistName = "Kay Debugger",
                };
                a189.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                a189.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a189.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                Artists.Add(a189);

                Artist a190 = new Artist()
                {
                    ArtistName = "Kay Controller",
                };
                a190.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                a190.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a190.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a190);

                Artist a191 = new Artist()
                {
                    ArtistName = "Jay Tester",
                };
                a191.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                a191.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a191.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "brazilian"));
                a191.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a191);

                Artist a192 = new Artist()
                {
                    ArtistName = "Dee Debugger",
                };
                a192.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a192.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a192.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a192);

                Artist a193 = new Artist()
                {
                    ArtistName = "Elle Debugger",
                };
                a193.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                Artists.Add(a193);

                Artist a194 = new Artist()
                {
                    ArtistName = "Zee Tester",
                };
                a194.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a194);

                Artist a195 = new Artist()
                {
                    ArtistName = "Why Mapper",
                };
                a195.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                a195.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a195.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "electronic"));
                Artists.Add(a195);

                Artist a196 = new Artist()
                {
                    ArtistName = "Are Model",
                };
                a196.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a196.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a196);

                Artist a197 = new Artist()
                {
                    ArtistName = "Gamma Dev",
                };
                a197.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a197);

                Artist a198 = new Artist()
                {
                    ArtistName = "Em Coder",
                };
                a198.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                a198.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "afrobeats"));
                Artists.Add(a198);

                Artist a199 = new Artist()
                {
                    ArtistName = "Elle Builder",
                };
                a199.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a199.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "soca"));
                a199.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                Artists.Add(a199);

                Artist a200 = new Artist()
                {
                    ArtistName = "Gamma Debugger",
                };
                a200.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a200.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a200);

                Artist a201 = new Artist()
                {
                    ArtistName = "Zee Model",
                };
                a201.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "latin"));
                a201.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                a201.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a201);

                Artist a202 = new Artist()
                {
                    ArtistName = "Tee Tester",
                };
                a202.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "classroom"));
                Artists.Add(a202);

                Artist a203 = new Artist()
                {
                    ArtistName = "Jay Model",
                };
                a203.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                a203.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "hip-hop"));
                Artists.Add(a203);

                Artist a204 = new Artist()
                {
                    ArtistName = "Tee Debugger",
                };
                a204.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "lofi"));
                a204.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a204);

                Artist a205 = new Artist()
                {
                    ArtistName = "Bee Tester",
                };
                a205.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "arabic"));
                Artists.Add(a205);

                Artist a206 = new Artist()
                {
                    ArtistName = "Kay Coder",
                };
                a206.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a206);

                Artist a207 = new Artist()
                {
                    ArtistName = "Kay-Tee Controller",
                };
                a207.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "world"));
                Artists.Add(a207);

                Artist a208 = new Artist()
                {
                    ArtistName = "Elle Mapper",
                };
                a208.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "pop"));
                Artists.Add(a208);

                Artist a209 = new Artist()
                {
                    ArtistName = "Are View",
                };
                a209.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "gaming"));
                a209.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "rock"));
                Artists.Add(a209);

                Artist a210 = new Artist()
                {
                    ArtistName = "Alpha View",
                };
                a210.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "ambient"));
                Artists.Add(a210);

                Artist a211 = new Artist()
                {
                    ArtistName = "Bee Builder",
                };
                a211.Genres.Add(db.Genres.FirstOrDefault(g => g.GenreName == "r&b"));
                Artists.Add(a211);

                foreach (Artist artistToAdd in Artists)
                {
                    Artist dbArtist = db.Artists.FirstOrDefault(g => g.ArtistName == artistToAdd.ArtistName);
                    if (dbArtist == null)
                    {
                        db.Artists.Add(artistToAdd);
                        db.SaveChanges();
                        intArtistsAdded += 1;
                    }
                }

            }
            catch
            {
                String msg = "Artists Added: " + intArtistsAdded.ToString();
                throw new InvalidOperationException(msg);
            }
        }
    }
}
