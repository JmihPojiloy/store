using System;

namespace Store
{
    public class OrderItem
    {
        public int BookID { get; }

        private int count;
        public int Count 
        {
            get { return count; }
            set
            {
                ThrowIfInvalidCount(value);
                count = value;
            }
        }

        public decimal Price { get; }

        public OrderItem(int bookID, int count, decimal price)
        {
            ThrowIfInvalidCount(count);

            BookID = bookID;
            Count = count;
            Price = price;
        }

        private static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count must be greater zero!");
        }
    }
}
