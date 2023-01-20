using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Order_WithNullItems_ThrowsArgumentNullExeption()
        {
            Assert.Throws<ArgumentNullException>(() => new Order(1, null));
        }

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnsZero()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Equal(0m, order.TotalPrice);
        }

        [Fact]
        public void TotalCount_WithNonEmptyItems_CalculatesTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            Assert.Equal(3 + 5, order.TotalCount);
        }

        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalculatesTotalPrice()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 3, 10m),
                new OrderItem(2, 5, 100m)
            });

            Assert.Equal(3 * 10m + 5 * 100m, order.TotalPrice);
        }

        [Fact]
        public void AddItem_AddNullBook_ThrowsArgementOfNullExeption()
        {
            var order = new Order(1, new OrderItem[0]);

            Assert.Throws<ArgumentNullException>(() =>
            {
                order.AddItem(null, 1);
            });
        }

        [Fact]
        public void AddItem_AddNewOriginalBook()
        {
            var book = new Book(1, "", "", "", "", 1m);
            var order = new Order(1, new OrderItem[0]);

            order.AddItem(book, 1);

            var item = order.Items.SingleOrDefault(x => x.BookID == book.Id);

            Assert.Equal(1m, item.Price);
        }
    }
}
