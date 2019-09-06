using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(x => x.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(x => x.Product.Id == product.Id);
        }

        public void RemoveItem(Product product)
        {
            CartLine line = lineCollection
                .FirstOrDefault(x => x.Product.Id == product.Id);


            if (line.Quantity <= 1)
                lineCollection.Remove(line);
            else
                line.Quantity--;
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Product.Price * x.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        /// <summary>
        /// Product on cart
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Count of goods
        /// </summary>
        public int Quantity { get; set; }
    }
}
