using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Seeding
{
    public static class SeedCustCreditCards
    {
        public static void SeedAllCustCreditCards(AppDbContext db)
        {
            // check to see if all the genres have already been added
            if (db.CustCreditCards.Count() == 10)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Credit Card Count record count is already 10!");
                throw ex;
            }
            Int32 intCardsAdded = 0;
            try
            {
                //Create a list of credit cards
                List<CustCreditCard> CustCreditCards = new List<CustCreditCard>();

                CustCreditCard c1 = new CustCreditCard()
                {
                    CardID = 1001,
                    CardNumber = "5402487911641970",
                    CardType = CardType.MasterCard,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker")
                };
                CustCreditCards.Add(c1);

                CustCreditCard c2 = new CustCreditCard()
                {
                    CardID = 1002,
                    CardNumber = "4040646714659780",
                    CardType = CardType.Visa,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia")
                };
                CustCreditCards.Add(c2);

                CustCreditCard c3 = new CustCreditCard()
                {
                    CardID = 1003,
                    CardNumber = "561479481465379",
                    CardType = CardType.Amex,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker")
                };
                CustCreditCards.Add(c3);

                CustCreditCard c4 = new CustCreditCard()
                {
                    CardID = 1004,
                    CardNumber = "5469290013187490",
                    CardType = CardType.MasterCard,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean")
                };
                CustCreditCards.Add(c4);

                CustCreditCard c5 = new CustCreditCard()
                {
                    CardID = 1005,
                    CardNumber = "6011485978941640",
                    CardType = CardType.Discover,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Wendy" && u.LastName == "Chang")
                };
                CustCreditCards.Add(c5);

                CustCreditCard c6 = new CustCreditCard()
                {
                    CardID = 1006,
                    CardNumber = "4584794615342670",
                    CardType = CardType.Visa,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Jennifer" && u.LastName == "MacLeod")
                };
                CustCreditCards.Add(c6);

                CustCreditCard c7 = new CustCreditCard()
                {
                    CardID = 1007,
                    CardNumber = "6767489513462640",
                    CardType = CardType.Discover,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Tesa" && u.LastName == "Freeley")
                };
                CustCreditCards.Add(c7);

                CustCreditCard c8 = new CustCreditCard()
                {
                    CardID = 1008,
                    CardNumber = "865146254978453",
                    CardType = CardType.Amex,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "John" && u.LastName == "Hearn")
                };
                CustCreditCards.Add(c8);

                CustCreditCard c9 = new CustCreditCard()
                {
                    CardID = 1009,
                    CardNumber = "5489761548972350",
                    CardType = CardType.MasterCard,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Eric" && u.LastName == "Stuart")
                };
                CustCreditCards.Add(c9);

                CustCreditCard c10 = new CustCreditCard()
                {
                    CardID = 1010,
                    CardNumber = "4011798411664850",
                    CardType = CardType.Visa,
                    User = db.Users.FirstOrDefault(u => u.FirstName == "Michelle" && u.LastName == "Banks")
                };
                CustCreditCards.Add(c10);


                foreach (CustCreditCard cardToAdd in CustCreditCards)
                {
                    Artist dbCreditCard = db.CustCreditCards.FirstOrDefault(c => c.CardNumber == cardToAdd.CardNumber);
                    if (dbCreditCard == null)
                    {
                        db.CustCreditCards.Add(cardToAdd);
                        db.SaveChanges();
                        intCardsAdded += 1;
                    }
                }

            }
            catch
            {
                String msg = "Credit Cards Added: " + intCardsAdded.ToString();
                throw new InvalidOperationException(msg);
            }
        }
    }
}
