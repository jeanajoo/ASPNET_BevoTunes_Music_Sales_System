using G6_BevoTunes.DAL;
using System;
using System.Linq;


namespace G6_BevoTunes.Utilities
{
    public static class GenerateNextGenreNumber
    {
        public static Int32 GetNextGenreNumber(AppDbContext _context)
        {
            //set a constant to designate where the order numbers 
            //should start
            const Int32 START_NUMBER = 4000;

            Int32 intMaxNumber; //the current maximum order number
            Int32 intNextNumber; //the order number for the next class

            if (_context.Genres.Count() == 0) //there are no orders in the database yet
            {
                intMaxNumber = START_NUMBER; //order numbers start at 70001
            }
            else
            {
                intMaxNumber = _context.Orders.Max(c => c.OrderID); //this is the highest number in the database right now
            }

            //You added records to the datbase before you realized 
            //that you needed this and now you have numbers less than 100 
            //in the database
            if (intMaxNumber < START_NUMBER)
            {
                intMaxNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextNumber = intMaxNumber + 1;

            //return the value
            return intNextNumber;
        }

    }
}