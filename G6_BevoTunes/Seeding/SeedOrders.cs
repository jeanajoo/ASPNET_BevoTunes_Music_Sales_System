using Microsoft.AspNetCore.Identity;


//TODO: Update these using statements to include your project name
using G6_BevoTunes.Utilities;
using G6_BevoTunes.DAL;
using G6_BevoTunes.Models;

namespace G6_BevoTunes.Seeding
{
    public static class SeedOrders
    {
        public async static Task SeedAllOrders(AppDbContext db, UserManager<AppUser> userManager)
        {
            // check to see if all the genres have already been added
            if (db.Orders.Count() == 26)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Order record count is already 26!");
                throw ex;
            }
            Int32 intOrdersAdded = 0;
            List<AppUser> customers = [.. await userManager.GetUsersInRoleAsync("Customer")];
            try
            {
                //Create a list of credit cards
                List<Order> Orders = new List<Order>();

                Order o1 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Michelle" && u.LastName == "Banks"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1010),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Michelle" && u.LastName == "Banks"),
                    OrderStatus = OrderStatus.InCart
                };

                o1.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Not Like Us"),
                });

                o1.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 17m,
                    Album = db.Albums.FirstOrDefault(a => a.AlbumName == "Nellyville")
                });

                Orders.Add(o1);

                Order o2 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1001),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    OrderStatus = OrderStatus.Ordered
                };

                o2.OrderDate = DateTime.Parse("2026-02-23 00:00:00");

                o2.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 2m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Bootstrap Remix"),
                });

                Orders.Add(o2);

                Order o3 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1001),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    OrderStatus = OrderStatus.Ordered
                };

                o3.OrderDate = DateTime.Parse("2026-02-24 00:00:00");

                o3.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 2m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Ice Ice Baby"),
                });

                Orders.Add(o3);

                Order o4 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Eric" && u.LastName == "Stuart"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1009),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Eric" && u.LastName == "Stuart"),
                    OrderStatus = OrderStatus.InCart
                };

                o4.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 2m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Moonlight"),
                });

                Orders.Add(o4);

                Order o5 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1004),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Louis" && u.LastName == "Winthorpe"),
                    OrderStatus = OrderStatus.Ordered
                };

                o5.OrderDate = DateTime.Parse("2026-02-24 00:00:00");

                o5.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Hot In Herre"),
                });

                o5.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 15m,
                    Album = db.Albums.FirstOrDefault(a => a.AlbumName == "Shock Value")
                });

                Orders.Add(o5);

                Order o6 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "John" && u.LastName == "Hearn"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1008),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "John" && u.LastName == "Hearn"),
                    OrderStatus = OrderStatus.InCart
                };

                o6.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 1m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "The Box"),
                });

                Orders.Add(o6);

                Order o7 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1003),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    OrderStatus = OrderStatus.Ordered
                };

                o7.OrderDate = DateTime.Parse("2026-02-25 00:00:00");

                o7.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 2m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Billie Jean"),
                });

                Orders.Add(o7);

                Order o8 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1004),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    OrderStatus = OrderStatus.Ordered
                };

                o8.OrderDate = DateTime.Parse("2026-02-25 00:00:00");

                o8.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 5m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Without Me"),
                });

                Orders.Add(o8);

                Order o9 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1001),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    OrderStatus = OrderStatus.Ordered
                };

                o9.OrderDate = DateTime.Parse("2026-02-25 00:00:00");

                o9.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Not Like Us"),
                });

                Orders.Add(o9);

                Order o10 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Tesa" && u.LastName == "Freeley"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1007),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Tesa" && u.LastName == "Freeley"),
                    OrderStatus = OrderStatus.InCart
                };

                o10.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 2m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Around the World"),
                });

                o10.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 14m,
                    Album = db.Albums.FirstOrDefault(a => a.AlbumName == "Harder Than Ever")
                });

                Orders.Add(o10);

                Order o11 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1003),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    OrderStatus = OrderStatus.Refunded
                };

                o11.OrderDate = DateTime.Parse("2026-02-26 00:00:00");

                o11.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 5m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Another One Bites The Dust - Remastered 2011"),
                });

                Orders.Add(o11);

                Order o12 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1002),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia"),
                    OrderStatus = OrderStatus.Ordered
                };

                o12.OrderDate = DateTime.Parse("2026-02-26 00:00:00");

                o12.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 1m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "No Heart"),
                });

                Orders.Add(o12);

                Order o13 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1004),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    OrderStatus = OrderStatus.Ordered
                };

                o13.OrderDate = DateTime.Parse("2026-02-26 00:00:00");

                o13.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 1m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Bad and Boujee (feat. Lil Uzi Vert)"),
                });

                Orders.Add(o13);

                Order o14 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Jennifer" && u.LastName == "MacLeod"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1006),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Jennifer" && u.LastName == "MacLeod"),
                    OrderStatus = OrderStatus.InCart
                };

                o14.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 2m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Me Porto Bonito"),
                });

                Orders.Add(o14);

                Order o15 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1004),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    OrderStatus = OrderStatus.Refunded
                };

                o15.OrderDate = DateTime.Parse("2026-02-27 00:00:00");

                o15.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 15m,
                    Album = db.Albums.FirstOrDefault(a => a.AlbumName == "Still Rollin")
                });

                Orders.Add(o15);

                Order o16 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1002),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia"),
                    OrderStatus = OrderStatus.Ordered
                };

                o16.OrderDate = DateTime.Parse("2026-02-27 00:00:00");

                o16.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 5m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Sprinter"),
                });

                o16.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "GOSSIP"),
                });

                Orders.Add(o16);

                Order o17 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1003),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    OrderStatus = OrderStatus.Ordered
                };

                o17.OrderDate = DateTime.Parse("2026-02-27 00:00:00");

                o17.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 1m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Could You Be Loved"),
                });

                Orders.Add(o17);

                Order o18 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1003),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    OrderStatus = OrderStatus.Refunded
                };

                o18.OrderDate = DateTime.Parse("2026-02-28 00:00:00");

                o18.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 4m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Check Yo Self - Remix"),
                });

                Orders.Add(o18);

                Order o19 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1001),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    OrderStatus = OrderStatus.Ordered
                };

                o19.OrderDate = DateTime.Parse("2026-02-28 00:00:00");

                o19.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 1m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Hypnotize - 2014 Remaster"),
                });

                Orders.Add(o19);

                Order o20 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1002),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Margaret" && u.LastName == "Garcia"),
                    OrderStatus = OrderStatus.Ordered
                };

                o20.OrderDate = DateTime.Parse("2026-02-28 00:00:00");

                o20.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 22m,
                    Album = db.Albums.FirstOrDefault(a => a.AlbumName == "The Trinity")
                });

                o20.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Still Think About You"),
                });

                Orders.Add(o20);

                Order o21 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1004),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Joe" && u.LastName == "Nguyen"),
                    OrderStatus = OrderStatus.Ordered
                };

                o21.OrderDate = DateTime.Parse("2026-03-01 00:00:00");

                o21.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Doja"),
                });

                Orders.Add(o21);

                Order o22 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1004),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    OrderStatus = OrderStatus.Refunded
                };

                o22.OrderDate = DateTime.Parse("2026-03-01 00:00:00");

                o22.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 5m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "TESLA BOY (feat. Blaqbonez)"),
                });

                Orders.Add(o22);

                Order o23 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1001),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker"),
                    OrderStatus = OrderStatus.Ordered
                };

                o23.OrderDate = DateTime.Parse("2026-03-01 00:00:00");

                o23.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Soca Soca"),
                });

                Orders.Add(o23);

                Order o24 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1004),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Olivier" && u.LastName == "Saint-Jean"),
                    OrderStatus = OrderStatus.Refunded
                };

                o24.OrderDate = DateTime.Parse("2026-03-02 00:00:00");

                o24.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 11m,
                    Album = db.Albums.FirstOrDefault(a => a.AlbumName == "Please Excuse Me for Being Antisocial")
                });

                Orders.Add(o24);

                Order o25 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Tesa" && u.LastName == "Freeley"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1007),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Tesa" && u.LastName == "Freeley"),
                    OrderStatus = OrderStatus.Ordered
                };

                o25.OrderDate = DateTime.Parse("2026-03-04 00:00:00");

                o25.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 2m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "C# Debugger"),
                });

                Orders.Add(o25);

                Order o26 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Wendy" && u.LastName == "Chang"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1005),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Wendy" && u.LastName == "Chang"),
                    OrderStatus = OrderStatus.InCart
                };

                o26.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 23m,
                    Album = db.Albums.FirstOrDefault(a => a.AlbumName == "Office Hours")
                });

                o26.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 20m,
                    Album = db.Albums.FirstOrDefault(a => a.AlbumName == "The Evil Genius")
                });

                Orders.Add(o26);

                Order o27 = new Order()
                {
                    Customer = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    Card = db.CustCreditCards.FirstOrDefault(c => c.CustCreditCardID == 1003),
                    Recipient = customers.FirstOrDefault(u => u.FirstName == "Clent" && u.LastName == "Tucker"),
                    OrderStatus = OrderStatus.Ordered
                };

                o27.OrderDate = DateTime.Parse("2026-03-06 00:00:00");

                o27.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Hot In Herre"),
                });

                o27.OrderDetails.Add(new OrderDetail()
                {
                    PurchasedPrice = 3m,
                    Song = db.Songs.FirstOrDefault(s => s.SongTitle == "Ice Ice Baby"),
                });

                Orders.Add(o27);


                foreach (Order orderToAdd in Orders)
                {
                    Order dbOrder = db.Orders.FirstOrDefault(o => o.OrderID == orderToAdd.OrderID);
                    if (dbOrder == null)
                    {
                        db.Orders.Add(orderToAdd);
                        db.SaveChanges();
                        intOrdersAdded += 1;
                    }
                }

            }
            catch
            {
                String msg = "Orders Added: " + intOrdersAdded.ToString();
                throw new InvalidOperationException(msg);
            }
        }
    }
}
