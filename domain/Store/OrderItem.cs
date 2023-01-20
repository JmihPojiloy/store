using System;

namespace Store
{
    public class OrderItem
    {
        public int BookID { get; }

        public int Count { get; }

        public decimal Price { get; }

        public OrderItem(int bookID, int count, decimal price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater zero!");

            BookID = bookID;
            Count = count;
            Price = price;
        }
    }
}
