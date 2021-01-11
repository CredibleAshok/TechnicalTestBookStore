using System;
using System.Collections.Generic;

namespace TechnicalTestBookStore
{
    public enum Category
    {
        Crime,
        Romance,
        Fantasy
    }
    public class Book
    {
        public string Name { get; set; }
        public double ActualCost { get; set; }
        public double DiscountedCost { get; set; }
        public double AfterTaxCost { get; set; }
        public Category Category { get; set; }
    }
    class Program
    {
        #region global consts
        // Discount and Tax are both percentages
        const double TaxPerc = 10;
        const double DiscountPerc = 5;
        const int precison = 2;
        #endregion global consts

        #region Methods
        static double CalculateDiscountedPrice(Category category, double price)
        { 
            return price - (price * (category == Category.Crime ? DiscountPerc : 0) / 100); 
        }
        static double CalculatePriceAfterTax(double totalOrderCost)
        {
            return totalOrderCost + (totalOrderCost * TaxPerc / 100 );
        }
        public static List<Book> PopulateBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Name = "Unsolved crimes",
                    Category = Category.Crime,
                    ActualCost = 10.99
                },
                new Book
                {
                    Name = "Heresy",
                    Category = Category.Fantasy,
                    ActualCost = 6.80
                },
                new Book
                {
                    Name = "A Little Love Story",
                    Category = Category.Romance,
                    ActualCost = 2.40
                },
                new Book
                {
                    Name = "Heresy",
                    Category = Category.Fantasy,
                    ActualCost = 6.80
                },
                new Book
                {
                    Name = "Jack the Ripper",
                    Category = Category.Crime,
                    ActualCost = 16.00
                },
                new Book
                {
                    Name = "The Tolkien Years",
                    Category = Category.Fantasy,
                    ActualCost = 22.90
                }
            };
        }
        #endregion Methods

        static void Main(string[] args)
        {
            var books = PopulateBooks();
            double totalOrderCostWithoutTax = 0;
            double totalOrderCost = 0;
            Console.WriteLine("Book Name | Category | Actual Cost | Discounted Cost | After Tax");
            books.ForEach(b =>
            {
                /* Assumption:- As the requirement doesn't clearly says that Total Cost includes the tax and discount. So assuming, 
                 * Total cost as the display price of the book (without tax and discount) */
                b.DiscountedCost = Math.Round(CalculateDiscountedPrice(b.Category, b.ActualCost), precison);
                b.AfterTaxCost = Math.Round(CalculatePriceAfterTax(b.DiscountedCost), precison);
                totalOrderCostWithoutTax += b.DiscountedCost;
                totalOrderCost += b.AfterTaxCost;
                Console.WriteLine(b.Name + " | " + b.Category + " | "
                    + b.ActualCost + " | " + b.DiscountedCost + " | "
                    + b.AfterTaxCost);
            });
            Console.WriteLine("Total Order Cost (Without Tax):- " + Math.Round(totalOrderCostWithoutTax, 2));
            Console.WriteLine("Total Order Cost:- " + totalOrderCost);
        }
    }
}
