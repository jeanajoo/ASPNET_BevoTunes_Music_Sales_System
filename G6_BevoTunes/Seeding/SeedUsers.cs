using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

//TODO: Upddate this namespace to match your project name
namespace G6_BevoTunes.Seeding
{
    public static class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            //Create a list of AddUserModels
            List<AddUserModel> AllUsers = new List<AddUserModel>();

                        AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "cbaker@example.com",
                    Email = "cbaker@example.com",
                    PhoneNumber = "5725458641",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Christopher",
                    LastName = "Baker",
                    Address = "1898 Schurz Alley",
                    ZipCode = "78701",
                    Status = UserStatus.Active

                },
                Password = "musiclover",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "banker@longhorn.net",
                    Email = "banker@longhorn.net",
                    PhoneNumber = "9867048435",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Michelle",
                    LastName = "Banks",
                    Address = "97 Elmside Pass",
                    ZipCode = "78702",
                    Status = UserStatus.Active

                },
                Password = "potato",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "franco@example.com",
                    Email = "franco@example.com",
                    PhoneNumber = "6836109514",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Franco",
                    LastName = "Broccolo",
                    Address = "88 Crowley Circle",
                    ZipCode = "78703",
                    Status = UserStatus.Active

                },
                Password = "painting",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "wchang@example.com",
                    Email = "wchang@example.com",
                    PhoneNumber = "7070911071",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Wendy",
                    LastName = "Chang",
                    Address = "56560 Sage Junction",
                    ZipCode = "78704",
                    Status = UserStatus.Active

                },
                Password = "texas1",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "limchou@gogle.com",
                    Email = "limchou@gogle.com",
                    PhoneNumber = "1488907687",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lim",
                    LastName = "Chou",
                    Address = "60 Lunder Point",
                    ZipCode = "78705",
                    Status = UserStatus.Active

                },
                Password = "Anchorage",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "shdixon@aoll.com",
                    Email = "shdixon@aoll.com",
                    PhoneNumber = "6899701824",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Shan",
                    LastName = "Dixon",
                    Address = "9448 Pleasure Avenue",
                    ZipCode = "78717",
                    Status = UserStatus.Active

                },
                Password = "aggies",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.b.evans@aheca.org",
                    Email = "j.b.evans@aheca.org",
                    PhoneNumber = "9986825917",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jim Bob",
                    LastName = "Evans",
                    Address = "51 Emmet Parkway",
                    ZipCode = "78723",
                    Status = UserStatus.Active

                },
                Password = "hampton1",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "feeley@penguin.org",
                    Email = "feeley@penguin.org",
                    PhoneNumber = "3464121966",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lou Ann",
                    LastName = "Feeley",
                    Address = "65 Darwin Crossing",
                    ZipCode = "78726",
                    Status = UserStatus.Active

                },
                Password = "longhorns",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "tfreeley@ci.us",
                    Email = "tfreeley@ci.us",
                    PhoneNumber = "6581357270",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Tesa",
                    LastName = "Freeley",
                    Address = "7352 Loftsgordon Court",
                    ZipCode = "78727",
                    Status = UserStatus.Active

                },
                Password = "mustangs",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mgarcia@gogle.com",
                    Email = "mgarcia@gogle.com",
                    PhoneNumber = "3767347949",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Margaret",
                    LastName = "Garcia",
                    Address = "7 International Road",
                    ZipCode = "78728",
                    Status = UserStatus.Active

                },
                Password = "onetime",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "chaley@thug.com",
                    Email = "chaley@thug.com",
                    PhoneNumber = "2198604221",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Charles",
                    LastName = "Haley",
                    Address = "8 Warrior Trail",
                    ZipCode = "78729",
                    Status = UserStatus.Active

                },
                Password = "pepperoni",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jeffh@sonic.com",
                    Email = "jeffh@sonic.com",
                    PhoneNumber = "1222185888",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeffrey",
                    LastName = "Hampton",
                    Address = "9107 Lighthouse Bay Road",
                    ZipCode = "78731",
                    Status = UserStatus.Active

                },
                Password = "raiders",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "wjhearniii@umich.org",
                    Email = "wjhearniii@umich.org",
                    PhoneNumber = "5123071976",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "John",
                    LastName = "Hearn",
                    Address = "59784 Pierstorff Center",
                    ZipCode = "78733",
                    Status = UserStatus.Active

                },
                Password = "jhearn22",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ahick@yaho.com",
                    Email = "ahick@yaho.com",
                    PhoneNumber = "1211949601",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Anthony",
                    LastName = "Hicks",
                    Address = "932 Monica Way",
                    ZipCode = "78734",
                    Status = UserStatus.Active

                },
                Password = "hickhickup",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ingram@jack.com",
                    Email = "ingram@jack.com",
                    PhoneNumber = "1372121569",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Brad",
                    LastName = "Ingram",
                    Address = "4 Lukken Court",
                    ZipCode = "78735",
                    Status = UserStatus.Active

                },
                Password = "ingram2015",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "toddj@yourmom.com",
                    Email = "toddj@yourmom.com",
                    PhoneNumber = "8543163836",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Todd",
                    LastName = "Jacobs",
                    Address = "7 Susan Junction",
                    ZipCode = "78736",
                    Status = UserStatus.Active

                },
                Password = "toddy25",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "thequeen@aska.net",
                    Email = "thequeen@aska.net",
                    PhoneNumber = "3214163359",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Victoria",
                    LastName = "Lawrence",
                    Address = "669 Oak Junction",
                    ZipCode = "78737",
                    Status = UserStatus.Active

                },
                Password = "something",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "linebacker@gogle.com",
                    Email = "linebacker@gogle.com",
                    PhoneNumber = "2505265350",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Erik",
                    LastName = "Lineback",
                    Address = "099 Luster Point",
                    ZipCode = "78738",
                    Status = UserStatus.Active

                },
                Password = "Password1",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "elowe@scare.net",
                    Email = "elowe@scare.net",
                    PhoneNumber = "4070619503",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Ernest",
                    LastName = "Lowe",
                    Address = "35473 Hansons Hill",
                    ZipCode = "78741",
                    Status = UserStatus.Active

                },
                Password = "aclfest2017",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "cluce@gogle.com",
                    Email = "cluce@gogle.com",
                    PhoneNumber = "7358436110",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Chuck",
                    LastName = "Luce",
                    Address = "4 Emmet Junction",
                    ZipCode = "78744",
                    Status = UserStatus.Active

                },
                Password = "nothinggood",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mackcloud@g.com",
                    Email = "mackcloud@g.com",
                    PhoneNumber = "7240178229",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jennifer",
                    LastName = "MacLeod",
                    Address = "3 Orin Road",
                    ZipCode = "78745",
                    Status = UserStatus.Active

                },
                Password = "whatever",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "cmartin@beets.com",
                    Email = "cmartin@beets.com",
                    PhoneNumber = "2495200223",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Elizabeth",
                    LastName = "Markham",
                    Address = "8171 Commercial Crossing",
                    ZipCode = "78746",
                    Status = UserStatus.Active

                },
                Password = "snowsnow",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "clarence@yoho.com",
                    Email = "clarence@yoho.com",
                    PhoneNumber = "4086179161",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Clarence",
                    LastName = "Martin",
                    Address = "96 Anthes Place",
                    ZipCode = "78748",
                    Status = UserStatus.Active

                },
                Password = "whocares",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "gregmartinez@dr.com",
                    Email = "gregmartinez@dr.com",
                    PhoneNumber = "9371927523",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Gregory",
                    LastName = "Martinez",
                    Address = "10 Northridge Plaza",
                    ZipCode = "78749",
                    Status = UserStatus.Active

                },
                Password = "xcellent",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "cmiller@bob.com",
                    Email = "cmiller@bob.com",
                    PhoneNumber = "5954063857",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Charles",
                    LastName = "Miller",
                    Address = "87683 Schmedeman Circle",
                    ZipCode = "78750",
                    Status = UserStatus.Active

                },
                Password = "mydogspot",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "knelson@aoll.com",
                    Email = "knelson@aoll.com",
                    PhoneNumber = "8929209512",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Kelly",
                    LastName = "Nelson",
                    Address = "3244 Ludington Court",
                    ZipCode = "77002",
                    Status = UserStatus.Active

                },
                Password = "spotmydog",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "joewin@factor.com",
                    Email = "joewin@factor.com",
                    PhoneNumber = "9226301774",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Joe",
                    LastName = "Nguyen",
                    Address = "4780 Talisman Court",
                    ZipCode = "77005",
                    Status = UserStatus.Active

                },
                Password = "joejoejoe",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "orielly@fox.cnn",
                    Email = "orielly@fox.cnn",
                    PhoneNumber = "2537646912",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Bill",
                    LastName = "O'Reilly",
                    Address = "4154 Delladonna Plaza",
                    ZipCode = "75201",
                    Status = UserStatus.Active

                },
                Password = "billyboy",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ankaisrad@gogle.com",
                    Email = "ankaisrad@gogle.com",
                    PhoneNumber = "2182889379",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Anka",
                    LastName = "Radkovich",
                    Address = "72361 Bayside Drive",
                    ZipCode = "75204",
                    Status = UserStatus.Active

                },
                Password = "radgirl",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "megrhodes@co.uk",
                    Email = "megrhodes@co.uk",
                    PhoneNumber = "9532396075",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Megan",
                    LastName = "Rhodes",
                    Address = "76875 Hoffman Point",
                    ZipCode = "78205",
                    Status = UserStatus.Active

                },
                Password = "meganr34",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "erynrice@aoll.com",
                    Email = "erynrice@aoll.com",
                    PhoneNumber = "7303815953",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eryn",
                    LastName = "Rice",
                    Address = "048 Elmside Park",
                    ZipCode = "78209",
                    Status = UserStatus.Active

                },
                Password = "ricearoni",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jorge@noclue.com",
                    Email = "jorge@noclue.com",
                    PhoneNumber = "3677322422",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jorge",
                    LastName = "Rodriguez",
                    Address = "01 Browning Pass",
                    ZipCode = "76102",
                    Status = UserStatus.Active

                },
                Password = "alaskaboy",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "mrrogers@day.com",
                    Email = "mrrogers@day.com",
                    PhoneNumber = "3911705385",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allen",
                    LastName = "Rogers",
                    Address = "844 Anderson Alley",
                    ZipCode = "75024",
                    Status = UserStatus.Active

                },
                Password = "bunnyhop",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "stjean@athome.com",
                    Email = "stjean@athome.com",
                    PhoneNumber = "7351610920",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Olivier",
                    LastName = "Saint-Jean",
                    Address = "1891 Docker Point",
                    ZipCode = "79901",
                    Status = UserStatus.Active

                },
                Password = "dustydusty",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "saunders@pen.com",
                    Email = "saunders@pen.com",
                    PhoneNumber = "5269661692",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Sarah",
                    LastName = "Saunders",
                    Address = "1469 Upham Road",
                    ZipCode = "78401",
                    Status = UserStatus.Active

                },
                Password = "jrod2017",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "willsheff@email.com",
                    Email = "willsheff@email.com",
                    PhoneNumber = "1875727246",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "William",
                    LastName = "Sewell",
                    Address = "1672 Oak Valley Circle",
                    ZipCode = "90001",
                    Status = UserStatus.Active

                },
                Password = "martin1234",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "sheffiled@gogle.com",
                    Email = "sheffiled@gogle.com",
                    PhoneNumber = "1394323615",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Martin",
                    LastName = "Sheffield",
                    Address = "816 Kennedy Place",
                    ZipCode = "90017",
                    Status = UserStatus.Active

                },
                Password = "penguin12",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "johnsmith187@aoll.com",
                    Email = "johnsmith187@aoll.com",
                    PhoneNumber = "6645937874",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "John",
                    LastName = "Smith",
                    Address = "0745 Golf Road",
                    ZipCode = "94102",
                    Status = UserStatus.Active

                },
                Password = "rogerthat",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "dustroud@mail.com",
                    Email = "dustroud@mail.com",
                    PhoneNumber = "6470254680",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Dustin",
                    LastName = "Stroud",
                    Address = "505 Dexter Plaza",
                    ZipCode = "92101",
                    Status = UserStatus.Active

                },
                Password = "smitty444",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "estuart@anchor.net",
                    Email = "estuart@anchor.net",
                    PhoneNumber = "7701621022",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eric",
                    LastName = "Stuart",
                    Address = "585 Claremont Drive",
                    ZipCode = "95814",
                    Status = UserStatus.Active

                },
                Password = "stewball",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "peterstump@noclue.com",
                    Email = "peterstump@noclue.com",
                    PhoneNumber = "2181960061",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Peter",
                    LastName = "Stump",
                    Address = "89035 Welch Circle",
                    ZipCode = "10001",
                    Status = UserStatus.Active

                },
                Password = "slowwind",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "jtanner@mustang.net",
                    Email = "jtanner@mustang.net",
                    PhoneNumber = "9908469499",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jeremy",
                    LastName = "Tanner",
                    Address = "4 Stang Trail",
                    ZipCode = "10019",
                    Status = UserStatus.Active

                },
                Password = "tanner5454",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "taylordjay@aoll.com",
                    Email = "taylordjay@aoll.com",
                    PhoneNumber = "7011918647",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allison",
                    LastName = "Taylor",
                    Address = "726 Twin Pines Avenue",
                    ZipCode = "60601",
                    Status = UserStatus.Active

                },
                Password = "allyrally",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "rtaylor@gogle.com",
                    Email = "rtaylor@gogle.com",
                    PhoneNumber = "8937910053",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Rachel",
                    LastName = "Taylor",
                    Address = "06605 Sugar Drive",
                    ZipCode = "60611",
                    Status = UserStatus.Active

                },
                Password = "taylorbaylor",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "teefrank@noclue.com",
                    Email = "teefrank@noclue.com",
                    PhoneNumber = "6394568913",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Frank",
                    LastName = "Tee",
                    Address = "3567 Dawn Plaza",
                    ZipCode = "33101",
                    Status = UserStatus.Active

                },
                Password = "teeoff22",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "ctucker@alphabet.co",
                    Email = "ctucker@alphabet.co",
                    PhoneNumber = "2676838676",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Clent",
                    LastName = "Tucker",
                    Address = "704 Northland Alley",
                    ZipCode = "32801",
                    Status = UserStatus.Active

                },
                Password = "tucksack1",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "avelasco@yoho.com",
                    Email = "avelasco@yoho.com",
                    PhoneNumber = "3452909754",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allen",
                    LastName = "Velasco",
                    Address = "72 Harbort Point",
                    ZipCode = "30303",
                    Status = UserStatus.Active

                },
                Password = "meow88",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "vinovino@grapes.com",
                    Email = "vinovino@grapes.com",
                    PhoneNumber = "8567089194",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Janet",
                    LastName = "Vino",
                    Address = "1 Oak Valley Place",
                    ZipCode = "98101",
                    Status = UserStatus.Active

                },
                Password = "vinovino",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "westj@pioneer.net",
                    Email = "westj@pioneer.net",
                    PhoneNumber = "6260784394",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jake",
                    LastName = "West",
                    Address = "48743 Banding Parkway",
                    ZipCode = "80202",
                    Status = UserStatus.Active

                },
                Password = "gowest",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "winner@hootmail.com",
                    Email = "winner@hootmail.com",
                    PhoneNumber = "3733971174",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Louis",
                    LastName = "Winthorpe",
                    Address = "96850 Summit Crossing",
                    ZipCode = "02108",
                    Status = UserStatus.Active

                },
                Password = "louielouie",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.smith@bevotunes.com",
                    Email = "j.smith@bevotunes.com",
                    PhoneNumber = "(339) 532-5649",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "John",
                    LastName = "Smith",
                    Address = "123 Oak St",
                    ZipCode = "78701",
                    Status = UserStatus.Active

                },
                Password = "Password1",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "e.johnson@bevotunes.com",
                    Email = "e.johnson@bevotunes.com",
                    PhoneNumber = "(963) 638-9416",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Address = "456 Pine St",
                    ZipCode = "78702",
                    Status = UserStatus.Active

                },
                Password = "Summer2",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.williams@bevotunes.com",
                    Email = "m.williams@bevotunes.com",
                    PhoneNumber = "(454) 713-5738",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Michael",
                    LastName = "Williams",
                    Address = "789 Maple Ave",
                    ZipCode = "78703",
                    Status = UserStatus.Active

                },
                Password = "SongLover5",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "s.brown@bevotunes.com",
                    Email = "s.brown@bevotunes.com",
                    PhoneNumber = "(581) 734-3315",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Sarah",
                    LastName = "Brown",
                    Address = "101 Cedar St",
                    ZipCode = "78704",
                    Status = UserStatus.Active

                },
                Password = "BrownSoCool",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "d.jones@bevotunes.com",
                    Email = "d.jones@bevotunes.com",
                    PhoneNumber = "(824) 191-5317",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "David",
                    LastName = "Jones",
                    Address = "222 Birch Rd",
                    ZipCode = "78705",
                    Status = UserStatus.Active

                },
                Password = "JDJones",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.garcia@bevotunes.com",
                    Email = "j.garcia@bevotunes.com",
                    PhoneNumber = "(247) 782-2475",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Jessica",
                    LastName = "Garcia",
                    Address = "333 Walnut St",
                    ZipCode = "78717",
                    Status = UserStatus.Active

                },
                Password = "WalGarJes",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "d.miller@bevotunes.com",
                    Email = "d.miller@bevotunes.com",
                    PhoneNumber = "(476) 496-6462",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Daniel",
                    LastName = "Miller",
                    Address = "444 Cherry Ln",
                    ZipCode = "78723",
                    Status = UserStatus.Active

                },
                Password = "MillHouse",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "a.davis@bevotunes.com",
                    Email = "a.davis@bevotunes.com",
                    PhoneNumber = "(512) 834-7291",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Ashley",
                    LastName = "Davis",
                    Address = "555 Spruce St",
                    ZipCode = "78727",
                    Status = UserStatus.Active

                },
                Password = "VolcanoAsh",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.rodriguez@bevotunes.com",
                    Email = "m.rodriguez@bevotunes.com",
                    PhoneNumber = "(713) 245-6837",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Matthew",
                    LastName = "Rodriguez",
                    Address = "666 Willow Dr",
                    ZipCode = "78729",
                    Status = UserStatus.Active

                },
                Password = "Marod",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "a.martinez@bevotunes.com",
                    Email = "a.martinez@bevotunes.com",
                    PhoneNumber = "(214) 567-9012",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Amanda",
                    LastName = "Martinez",
                    Address = "777 Aspen Way",
                    ZipCode = "78745",
                    Status = UserStatus.Active

                },
                Password = "martin51",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "c.hernandez@bevotunes.com",
                    Email = "c.hernandez@bevotunes.com",
                    PhoneNumber = "(936) 778-4526",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Christopher",
                    LastName = "Hernandez",
                    Address = "888 Poplar St",
                    ZipCode = "77002",
                    Status = UserStatus.Active

                },
                Password = "Member2",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "s.lopez@bevotunes.com",
                    Email = "s.lopez@bevotunes.com",
                    PhoneNumber = "(281) 349-7743",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Stephanie",
                    LastName = "Lopez",
                    Address = "999 Cypress Rd",
                    ZipCode = "75201",
                    Status = UserStatus.Active

                },
                Password = "Active3",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "a.gonzalez@bevotunes.com",
                    Email = "a.gonzalez@bevotunes.com",
                    PhoneNumber = "(972) 660-1835",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Andrew",
                    LastName = "Gonzalez",
                    Address = "111 Redwood Ave",
                    ZipCode = "78205",
                    Status = UserStatus.Active

                },
                Password = "System4",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "l.wilson@bevotunes.com",
                    Email = "l.wilson@bevotunes.com",
                    PhoneNumber = "(409) 522-9941",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Lauren",
                    LastName = "Wilson",
                    Address = "222 Dogwood Ln",
                    ZipCode = "76102",
                    Status = UserStatus.Active

                },
                Password = "Network5",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "j.anderson@bevotunes.com",
                    Email = "j.anderson@bevotunes.com",
                    PhoneNumber = "(830) 415-6278",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Joshua",
                    LastName = "Anderson",
                    Address = "333 Magnolia St",
                    ZipCode = "90001",
                    Status = UserStatus.Active

                },
                Password = "Service6",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "n.thomas@bevotunes.com",
                    Email = "n.thomas@bevotunes.com",
                    PhoneNumber = "(325) 738-5602",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Nicole",
                    LastName = "Thomas",
                    Address = "444 Juniper Dr",
                    ZipCode = "94102",
                    Status = UserStatus.Active

                },
                Password = "User7",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "r.taylor@bevotunes.com",
                    Email = "r.taylor@bevotunes.com",
                    PhoneNumber = "(915) 684-2294",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Ryan",
                    LastName = "Taylor",
                    Address = "555 Hickory St",
                    ZipCode = "10001",
                    Status = UserStatus.Active

                },
                Password = "Client81",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "m.moore@bevotunes.com",
                    Email = "m.moore@bevotunes.com",
                    PhoneNumber = "(210) 953-4471",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Megan",
                    LastName = "Moore",
                    Address = "666 Alder Rd",
                    ZipCode = "60601",
                    Status = UserStatus.Active

                },
                Password = "AccountSong",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "b.jackson@bevotunes.com",
                    Email = "b.jackson@bevotunes.com",
                    PhoneNumber = "(469) 318-7905",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Brandon",
                    LastName = "Jackson",
                    Address = "777 Sycamore St",
                    ZipCode = "33101",
                    Status = UserStatus.Active

                },
                Password = "Manage1",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "r.martin@bevotunes.com",
                    Email = "r.martin@bevotunes.com",
                    PhoneNumber = "(254) 842-6619",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Rachel",
                    LastName = "Martin",
                    Address = "888 Cottonwood Ave",
                    ZipCode = "02108",
                    Status = UserStatus.Active

                },
                Password = "SecurePass",
                RoleName = "Employee"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "c.baker@bevotunes.com",
                    Email = "c.baker@bevotunes.com",
                    PhoneNumber = "3395325649",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Christopher",
                    LastName = "Baker",
                    Address = "1245 Lake Libris Dr.",
                    ZipCode = "78613",
                    Status = UserStatus.Active

                },
                Password = "dewey4",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "e.rice@bevotunes.com",
                    Email = "e.rice@bevotunes.com",
                    PhoneNumber = "2706602803",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Eryn",
                    LastName = "Rice",
                    Address = "3405 Rio Grande",
                    ZipCode = "78746",
                    Status = UserStatus.Active

                },
                Password = "arched",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "a.rogers@bevotunes.com",
                    Email = "a.rogers@bevotunes.com",
                    PhoneNumber = "4139645586",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Allen",
                    LastName = "Rogers",
                    Address = "4965 Oak Hill",
                    ZipCode = "78705",
                    Status = UserStatus.Active

                },
                Password = "lottery",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "w.sewell@bevotunes.com",
                    Email = "w.sewell@bevotunes.com",
                    PhoneNumber = "7224308314",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "William",
                    LastName = "Sewell",
                    Address = "2365 51st St.",
                    ZipCode = "78755",
                    Status = UserStatus.Active

                },
                Password = "offbeat",
                RoleName = "Admin"
            });

            //create flag to help with errors
            String errorFlag = "Start";

            //create an identity result
            IdentityResult result = new IdentityResult();
            //call the method to seed the user
            try
            {
                foreach (AddUserModel aum in AllUsers)
                {
                    errorFlag = aum.User.Email;
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the user with email: "
                    + errorFlag, ex);
            }

            return result;
        }
    }
}
