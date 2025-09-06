using System;
using System.Linq;
using System.Collections.Generic;
using static day10_G01.ListGenerators;
using day10_G01;
using System.IO;
namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            #region Restriction Operators
            Console.WriteLine("=== Restriction Operators ===");

            // 1. Find all products that are out of stock.
            var outOfStock = ProductList.Where(p => p.UnitsInStock == 0);
            Console.WriteLine("Out of Stock Products:");
            foreach (var p in outOfStock)
                Console.WriteLine($"{p.ProductName} (Stock={p.UnitsInStock})");

            // 2. Find all products that are in stock and cost more than 3.00 per unit.
            var inStockExpensive = ProductList
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);
            Console.WriteLine("\nIn Stock and > 3.00:");
            foreach (var p in inStockExpensive)
                Console.WriteLine($"{p.ProductName} ({p.UnitPrice:C})");

            // 3. Returns digits whose name is shorter than their value.
            string[] digitsArr1 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shorterDigits = digitsArr1
                .Select((name, index) => new { name, index })
                .Where(d => d.name.Length < d.index);
            Console.WriteLine("\nDigits with name shorter than value:");
            foreach (var d in shorterDigits)
                Console.WriteLine($"{d.name} ({d.index})");

            #endregion

            #region Element Operators
            Console.WriteLine("\n=== Element Operators ===");

            // 1. Get first Product out of Stock
            var firstOutOfStock = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
            Console.WriteLine($"First out of stock product: {firstOutOfStock?.ProductName}");

            // 2. First product whose Price > 1000, else null
            var expensiveProduct = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine($"First product with price > 1000: {expensiveProduct?.ProductName ?? "null"}");

            // 3. Retrieve the second number greater than 5
            int[] arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondGreaterThan5 = arr2.Where(n => n > 5).Skip(1).FirstOrDefault();
            Console.WriteLine($"Second number greater than 5: {secondGreaterThan5}");

            #endregion

            #region Aggregate Operators
            Console.WriteLine("\n=== Aggregate Operators ===");

            int[] arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // 1. Number of odd numbers
            var oddCount = arr3.Count(n => n % 2 == 1);
            Console.WriteLine($"Odd numbers count: {oddCount}");

            // 2. Customers and how many orders each has
            var custOrdersCount = CustomerList
                .Select(c => new { c.Name, OrderCount = c.Orders.Count() });
            Console.WriteLine("\nCustomers and their order counts:");
            foreach (var c in custOrdersCount)
                Console.WriteLine($"{c.Name}: {c.OrderCount}");

            // 3. Categories and how many products each has
            var catProductsCount = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() });
            Console.WriteLine("\nCategories and product counts:");
            foreach (var c in catProductsCount)
                Console.WriteLine($"{c.Category}: {c.Count}");

            // 4. Total of numbers in array
            var totalArr = arr3.Sum();
            Console.WriteLine($"\nTotal of array numbers: {totalArr}");

            // 5. Total number of characters in dictionary
            var dictWords = File.ReadAllLines("dictionary_english.txt");
            var totalChars = dictWords.Sum(w => w.Length);
            Console.WriteLine($"Total characters in dictionary: {totalChars}");

            // 6. Total units in stock for each product category
            var stockByCat = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });
            Console.WriteLine("\nTotal units in stock per category:");
            foreach (var s in stockByCat)
                Console.WriteLine($"{s.Key}: {s.TotalUnits}");

            // 7. Length of the shortest word
            var shortest = dictWords.Min(w => w.Length);
            Console.WriteLine($"\nShortest word length: {shortest}");

            // 8. Cheapest price among each category's products
            var cheapestByCat = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { g.Key, MinPrice = g.Min(p => p.UnitPrice) });
            Console.WriteLine("\nCheapest price in each category:");
            foreach (var c in cheapestByCat)
                Console.WriteLine($"{c.Key}: {c.MinPrice}");

            // 9. Products with the cheapest price in each category (using let)
            var cheapestProducts = from p in ProductList
                                   group p by p.Category into g
                                   let minPrice = g.Min(p => p.UnitPrice)
                                   from p2 in g
                                   where p2.UnitPrice == minPrice
                                   select new { g.Key, p2.ProductName, p2.UnitPrice };
            Console.WriteLine("\nCheapest products in each category:");
            foreach (var p in cheapestProducts)
                Console.WriteLine($"{p.Key}: {p.ProductName} ({p.UnitPrice})");

            // 10. Longest word length
            var longest = dictWords.Max(w => w.Length);
            Console.WriteLine($"\nLongest word length: {longest}");

            // 11. Most expensive price among each category's products
            var mostExpByCat = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { g.Key, MaxPrice = g.Max(p => p.UnitPrice) });
            Console.WriteLine("\nMost expensive price in each category:");
            foreach (var c in mostExpByCat)
                Console.WriteLine($"{c.Key}: {c.MaxPrice}");

            // 12. Products with the most expensive price in each category
            var mostExpProducts = from p in ProductList
                                  group p by p.Category into g
                                  let maxPrice = g.Max(p => p.UnitPrice)
                                  from p2 in g
                                  where p2.UnitPrice == maxPrice
                                  select new { g.Key, p2.ProductName, p2.UnitPrice };
            Console.WriteLine("\nMost expensive products in each category:");
            foreach (var p in mostExpProducts)
                Console.WriteLine($"{p.Key}: {p.ProductName} ({p.UnitPrice})");

            // 13. Average length of dictionary words
            var avgWordLen = dictWords.Average(w => w.Length);
            Console.WriteLine($"\nAverage dictionary word length: {avgWordLen}");

            // 14. Average price of each category's products
            var avgPriceByCat = ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { g.Key, AvgPrice = g.Average(p => p.UnitPrice) });
            Console.WriteLine("\nAverage price in each category:");
            foreach (var c in avgPriceByCat)
                Console.WriteLine($"{c.Key}: {c.AvgPrice}");

            #endregion

            #region Ordering Operators
            Console.WriteLine("\n=== Ordering Operators ===");

            // 1. Sort products by name
            var productsByName = ProductList.OrderBy(p => p.ProductName);
            Console.WriteLine("\nProducts by name:");
            foreach (var p in productsByName)
                Console.WriteLine(p.ProductName);

            // 2. Case-insensitive sort of words
            string[] words1 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords1 = words1.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\nCase-insensitive sorted words:");
            foreach (var w in sortedWords1)
                Console.WriteLine(w);

            // 3. Products by units in stock (desc)
            var productsByStock = ProductList.OrderByDescending(p => p.UnitsInStock);
            Console.WriteLine("\nProducts by stock (desc):");
            foreach (var p in productsByStock)
                Console.WriteLine($"{p.ProductName}: {p.UnitsInStock}");

            // 4. Digits sorted by name length then alpha
            string[] digitsArr2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var digitsSorted = digitsArr2.OrderBy(d => d.Length).ThenBy(d => d);
            Console.WriteLine("\nDigits sorted by length then alpha:");
            foreach (var d in digitsSorted)
                Console.WriteLine(d);

            // 5. Words sorted by length then case-insensitive
            string[] words2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var sortedWords2 = words2.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\nWords sorted by length then case-insensitive:");
            foreach (var w in sortedWords2)
                Console.WriteLine(w);

            // 6. Products by category then price (desc)
            var productsCatPrice = ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            Console.WriteLine("\nProducts by category then price (desc):");
            foreach (var p in productsCatPrice)
                Console.WriteLine($"{p.Category}: {p.ProductName} ({p.UnitPrice})");

            // 7. Words sorted by length then case-insensitive descending
            var sortedWords3 = words2.OrderBy(w => w.Length)
                                     .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("\nWords sorted by length then case-insensitive desc:");
            foreach (var w in sortedWords3)
                Console.WriteLine(w);

            // 8. Digits with second letter 'i' reversed order
            var reversedDigits = digitsArr2.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
            Console.WriteLine("\nDigits with 2nd letter 'i' reversed:");
            foreach (var d in reversedDigits)
                Console.WriteLine(d);

            #endregion

            #region Transformation Operators
            Console.WriteLine("\n=== Transformation Operators ===");

            // 1. Sequence of product names
            var productNames = ProductList.Select(p => p.ProductName);
            Console.WriteLine("\nProduct names:");
            foreach (var n in productNames)
                Console.WriteLine(n);

            // 2. Uppercase and lowercase versions of words
            string[] words3 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var wordCases = words3.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            Console.WriteLine("\nWords upper/lower:");
            foreach (var w in wordCases)
                Console.WriteLine($"{w.Upper} / {w.Lower}");

            // 3. Some product properties (renaming UnitPrice to Price)
            var productProps = ProductList
                .Select(p => new { p.ProductName, Price = p.UnitPrice, p.Category });
            Console.WriteLine("\nProduct properties:");
            foreach (var p in productProps)
                Console.WriteLine($"{p.ProductName} - {p.Category} - {p.Price}");

            // 4. Ints in array match position?
            int[] arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var inplaceCheck = arr4.Select((n, index) => new { Number = n, InPlace = n == index });
            Console.WriteLine("\nNumbers in place?");
            foreach (var x in inplaceCheck)
                Console.WriteLine($"{x.Number}: {x.InPlace}");

            // 5. All pairs a < b
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { a, b };
            Console.WriteLine("\nPairs a < b:");
            foreach (var p in pairs)
                Console.WriteLine($"{p.a} < {p.b}");

            // 6. Orders where total < 500
            var ordersSmall =  CustomerList
                .SelectMany(c => c.Orders)
                .Where(o => o.Total < 500);
            Console.WriteLine("\nOrders with total < 500:");
            foreach (var o in ordersSmall)
                Console.WriteLine($"OrderID={o.Id}, Total={o.Total}");

            // 7. Orders from 1998 or later
            var orders1998 =  CustomerList
                .SelectMany(c => c.Orders)
                .Where(o => o.OrderDate.Year >= 1998);
            Console.WriteLine("\nOrders from 1998 or later:");
            foreach (var o in orders1998)
                Console.WriteLine($"OrderID={o.Id}, Date={o.OrderDate}");

            #endregion

            #region Partitioning Operators
            Console.WriteLine("\n=== Partitioning Operators ===");

            // 1. First 3 orders from Washington customers
            var first3OrdersWA = CustomerList
                .Where(c => c.City == "WA")
                .SelectMany(c => c.Orders)
                .Take(3);
            Console.WriteLine("\nFirst 3 orders from WA:");
            foreach (var o in first3OrdersWA)
                Console.WriteLine(o.Id);

            // 2. All but first 2 orders from Washington
            var skip2OrdersWA = CustomerList
                .Where(c => c.City == "WA")
                .SelectMany(c => c.Orders)
                .Skip(2);
            Console.WriteLine("\nAll but first 2 orders from WA:");
            foreach (var o in skip2OrdersWA)
                Console.WriteLine(o.Id);

            // 3. Elements until number < position
            int[] numbers5 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var untilLess = numbers5.TakeWhile((n, i) => n >= i);
            Console.WriteLine("\nNumbers until n < position:");
            foreach (var n in untilLess)
                Console.WriteLine(n);

            // 4. Elements from first divisible by 3
            var fromDiv3 = numbers5.SkipWhile(n => n % 3 != 0);
            Console.WriteLine("\nNumbers from first divisible by 3:");
            foreach (var n in fromDiv3)
                Console.WriteLine(n);

            // 5. Elements from first less than position
            var fromLessPos = numbers5.SkipWhile((n, i) => n >= i);
            Console.WriteLine("\nNumbers from first less than position:");
            foreach (var n in fromLessPos)
                Console.WriteLine(n);

            #endregion

            #region Quantifiers
            Console.WriteLine("\n=== Quantifiers ===");

            // 1. Any word contains "ei"
            var anyEi = dictWords.Any(w => w.Contains("ei"));
            Console.WriteLine($"\nAny word contains 'ei': {anyEi}");

            // 2. Categories with at least one product out of stock
            var catWithOut = ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0));
            Console.WriteLine("\nCategories with at least one product out of stock:");
            foreach (var g in catWithOut)
                Console.WriteLine(g.Key);

            // 3. Categories with all products in stock
            var catAllIn = ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0));
            Console.WriteLine("\nCategories with all products in stock:");
            foreach (var g in catAllIn)
                Console.WriteLine(g.Key);

            #endregion

            Console.WriteLine("\n=== END OF ASSIGNMENT ===");

        }
    }
}
