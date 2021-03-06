﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Training.CSharp
{
    class Program
    {
        static string[] cities = CityRepository.GetSampleCities();
        static List<Product> products = ProductRepository.GetSampleProducts();
        static List<Product> productsWithSupplier = ProductRepository.GetSampleProductsWithSupplier();
        static List<Supplier> suppliers = SupplierRepository.GetSampleSuppliers();

        static void Main()
        {
            //All();
            //Any();
            //Average();
            //Concat();
            //Contains();
            //Cast();
            //Count();
            //First();
            //FirstOrDefault();
            //Distinct();
            //GroupBy();
            //GroupByProjection();
            //Into();
            //Join();
            //JoinCross();
            //JoinLeft(); // Also known as Group Join
            //Last();
            //LastOrDefault();
            //Let();
            //Max();
            //Min();
            //NestedQuery();
            //OrderBy();
            //OfType();
            //Projection();
            //Reverse();
            //SelectMany();
            //SequenceEqual();
            //Single();
            //Skip();
            //SkipWhile();
            //Take();
            //TakeWhile();
            //ToDictionary();
            //Union();
            //Where();
            //Zip();

            Console.ReadLine();
        }

        private static void Single()
        {
            Console.WriteLine("Single");
            string[] notEmpty = { "Hello" };
            var result = notEmpty.Single();
            Console.WriteLine(result);
            Console.WriteLine();
        }

        private static void All()
        {
            Console.WriteLine("All");
            bool result = productsWithSupplier.All(x => x.Name.Length == 3); // Check if all product name length is 3
            Console.WriteLine(result);
            Console.WriteLine();

            int[] twos = { 2, 4, 6, 8, 10 };
            bool areAllEven = twos.All(n => n % 2 == 0);
            Console.WriteLine(areAllEven);
            Console.WriteLine();
        }

        private static void Any()
        {
            Console.WriteLine("Any");
            bool result = productsWithSupplier.Any(x => x.Name.Length == 2); // Check if any product name length is 2 
            Console.WriteLine(result);
            Console.WriteLine();

            int[] twos = { 2, 4, 5, 8, 11 };
            bool anyEven = twos.Any(n => n % 2 == 0);
            Console.WriteLine(anyEven);
            Console.WriteLine();
        }

        private static void Average()
        {
            #region Query
            Console.WriteLine("Average Query");
            var avgQuery = (from p in products
                            select p.Price).Average();

            Console.WriteLine("Avg product price {0}", avgQuery);
            Console.WriteLine();
            #endregion

            #region Expression
            Console.WriteLine("Average Expression");
            Console.WriteLine("Avg product price {0}", products.Average(c => c.Price));
            Console.WriteLine();
            #endregion
        }
        
        private static void Cast()
        {
            // Converts a non-generic collection to IEnumerable<T>
            Console.WriteLine("Cast");
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            //list.Add(DateTime.Now); // any non int value will throw an exception since we are casting to int
            var genericList = list.Cast<int>();
            foreach (var item in genericList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        private static void Concat()
        {
            Console.WriteLine("Concat");
            string[] firstGroup = { "One", "Two", "Three" };
            string[] secondGroup = { "One", "Two", "Three", "Four", "Five", "Six" };
            var concat = firstGroup.Concat(secondGroup);
            foreach (var item in concat)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void Contains()
        {
            int[] numbers = { 2, 4, 6, 8, 10 };
            bool hasNine = numbers.Contains(9);
            bool hasTen = numbers.Contains(10);
            Console.WriteLine(hasNine);
            Console.WriteLine(hasTen);
            Console.WriteLine();
        }

        private static void Count()
        {
            #region Expression

            Console.WriteLine("Total number of cities {0}", cities.Count());

            Console.WriteLine("Count Expression ");
            Console.WriteLine("Total number of cities starts with L {0}", cities.Count(c => c.StartsWith("L")));
            Console.WriteLine();
            #endregion

            #region Query
            Console.WriteLine("Count Query");
            var query = (from city in cities
                         where city.StartsWith("L")
                         select city).Count();
            Console.WriteLine("Total number of cities starts with L {0}", query);

            Console.WriteLine();
            #endregion
        }

        private static void Distinct()
        {
            var customers = new List<Customer> 
            {
              new Customer { Name = "Prasad", City= "NY"},
              new Customer { Name = "Rahul", City= "Pune"},
              new Customer { Name = "Prasad", City= "NY"},
              new Customer { Name = "Scott", City= "Mumbai"}
            };

            #region Expression
            var query1 = customers.Distinct(); // Uses default IEqualityComparer, so all the customer instances are different
            foreach (var item in query1)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region Query
            var query2 = (from c in customers
                          select c).Distinct();
            foreach (var item in query2)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            #endregion

            #region Expression
            // Anonymous types automatically overrides Equals and GetHashCode method and uses all public properties to compare equality
            var query3 = (customers.Select(c => c.Name)).Distinct();
            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region Query
            var query4 = (from c in customers
                          select new { c.Name })
                              .Distinct();
            foreach (var item in query4)
            {
                Console.WriteLine(item.Name);
            }
            #endregion

        }

        private static void First()
        {
            #region Expression
            // First
            var firstCity = cities.First();
            Console.WriteLine("First city in the collection is {0}", firstCity);

            // First Expression 
            Console.WriteLine("First Expression");
            var firstCity5 = cities.First(c => c.Length == 5);
            Console.WriteLine("First city in the collection is with 5 letter {0}", firstCity5);

            Console.WriteLine();
            #endregion

            #region Query
            Console.WriteLine("First Query");
            var firstCity6 = (from city in cities
                              where city.Length == 6
                              select city).First();

            Console.WriteLine("First city in the collection is with 6 letter {0}", firstCity6);

            Console.WriteLine();
            #endregion
        }

        private static void FirstOrDefault()
        {
            Console.WriteLine("FirstOrDefault");
            string[] empty = { };
            string[] notEmpty = { "Hello", "World" };
            // var result = empty.First(); // throws exception
            var result = empty.FirstOrDefault();
            Console.WriteLine(result);
            result = notEmpty.FirstOrDefault();
            Console.WriteLine(result);
            Console.WriteLine();
        }

        private static void GroupBy()
        {
            #region Expression

            Console.WriteLine("Group by expression");

            var groupExpression = productsWithSupplier.GroupBy(p => p.SupplierId);

            foreach (var group in groupExpression)
            {
                Console.WriteLine("Supplier Id {0}", group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine("\t{0}", product.Name);
                }
            }
            Console.WriteLine();

            #endregion

            #region Query
            Console.WriteLine("Group by query");
            var groupQuery = from p in productsWithSupplier
                             group p by p.SupplierId;

            foreach (var group in groupQuery)
            {
                Console.WriteLine("Supplier Id {0}", group.Key);
                foreach (var product in group)
                {
                    Console.WriteLine("\t{0}", product.Name);
                }
            }

            Console.WriteLine();
            #endregion
        }

        private static void GroupByProjection()
        {
            #region Query
            Console.WriteLine("Group by query");
            var groupQuery = from p in productsWithSupplier
                             group p by p.SupplierId
                                 into ps
                                 select new
                                 {
                                     SupplierId = ps.Key,
                                     Products = ps
                                 };

            foreach (var group in groupQuery)
            {
                Console.WriteLine("Supplier Id {0}", group.SupplierId);
                foreach (var product in group.Products)
                {
                    Console.WriteLine("\t{0}", product.Name);
                }
            }

            Console.WriteLine();
            #endregion

            #region Expression
            Console.WriteLine("Group by Expression");
            var groupQuery2 = productsWithSupplier.GroupBy(p => p.SupplierId)
                                                  .Select(ps => new
                                                     {
                                                         SupplierId = ps.Key,
                                                         Products = ps
                                                     });

            foreach (var group in groupQuery2)
            {
                Console.WriteLine("Supplier Id {0}", group.SupplierId);
                foreach (var product in group.Products)
                {
                    Console.WriteLine("\t{0}", product.Name);
                }
            }

            Console.WriteLine();
            #endregion

            Console.WriteLine();
        }

        private static void Into()
        {
            // into is used to continue query after projection. Normally used in grouping
            Console.WriteLine("into keyword");
            var intoQuery = from p in products
                            where p.Name.ToLower().StartsWith("i")
                            select p
                                into iProduct // original range variable p goes out of scope
                                where iProduct.Price > 400
                                select iProduct;

            foreach (var product in intoQuery)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();

            Console.WriteLine("into keyword with product and supplier grouping");
            var intoQuery2 = from p in productsWithSupplier
                             join s in suppliers
                                 on p.SupplierId equals s.Id
                             select new { Product = p, Supplier = s }
                                 into ps
                                 where ps.Product.Price > 400 && ps.Supplier.Id > 1
                                 select new { ProductName = ps.Product.Name };

            foreach (var product in intoQuery2)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine();
        }

        private static void Join()
        {
            #region Expression
            Console.WriteLine("Join Expression");
            var joinExpression = productsWithSupplier.Join(suppliers, p => p.SupplierId, s => s.Id, (p, s) => new { ProductName = p.Name, Supplier = s });

            foreach (var item in joinExpression)
            {
                Console.WriteLine("Product : {0}, Supplier : {1} {2}", item.ProductName, item.Supplier.Id, item.Supplier.Name);
            }
            Console.WriteLine();
            #endregion

            #region Query
            Console.WriteLine("Join Query ");
            var joinQuery = from p in productsWithSupplier
                            join s in suppliers
                            on p.SupplierId equals s.Id
                            orderby s.Id
                            select new { ProductName = p.Name, Supplier = s };

            foreach (var item in joinQuery)
            {
                Console.WriteLine("Product : {0}, Supplier : {1} {2}", item.ProductName, item.Supplier.Id, item.Supplier.Name);
            }

            Console.WriteLine();
            #endregion
        }

        private static void JoinCross()
        {
            Console.WriteLine("Cross Join");
            var query = from p in products
                        from s in suppliers
                        select new { Product = p.Name, Supplier = s.Name };
            foreach (var item in query)
            {
                Console.WriteLine("{0} : {1}", item.Product, item.Supplier);
            }
            Console.WriteLine();
        }

        private static void JoinLeft()
        {
            Console.WriteLine("Left Join Query ");
            var joinQuery = from s in suppliers
                            join p in productsWithSupplier
                            on s.Id equals p.SupplierId
                            into sp
                            orderby s.Id
                            select new { Products = sp, Supplier = s.Name }; // Even though used into, outer sequence s remains in scope, but not the inner sequence p

            foreach (var item in joinQuery)
            {
                Console.WriteLine(item.Supplier);
                foreach (var product in item.Products)
                {
                    Console.WriteLine("\t" + product.Name);
                }
            }

            Console.WriteLine();
        }

        private static void Last()
        {
            // Last
            var lastCity = cities.Last();
            Console.WriteLine("Last city in the collection is {0}", lastCity);

            #region Expression
            Console.WriteLine("Last Expression");
            var lastCity5 = cities.Last(c => c.Length == 5);
            Console.WriteLine("Last city in the collection is with 5 letter {0}", lastCity5);

            Console.WriteLine();
            #endregion

            #region Query
            Console.WriteLine("Last Query");
            var lastCity6 = (from city in cities
                             where city.Length == 6
                             select city).Last();
            Console.WriteLine("Last city in the collection is with 6 letter {0}", lastCity6);

            Console.WriteLine();
            #endregion
        }

        private static void LastOrDefault()
        {
            Console.WriteLine("LastOrDefault");
            string[] empty = { };
            string[] notEmpty = { "Hello", "World" };
            // var result = empty.First(); // throws exception
            var result = empty.LastOrDefault();
            Console.WriteLine(result);
            result = notEmpty.LastOrDefault();
            Console.WriteLine(result);
            Console.WriteLine();
        }

        private static void Let()
        {
            #region Query
            // let is used to add additional range variable in the query
            Console.WriteLine("let keyword");

            var letQuery = from ps in productsWithSupplier
                           where ps.Price > 100
                           let lName = ps.Name.ToLower()
                           select lName;

            foreach (var item in letQuery)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            #endregion
        }

        private static void Max()
        {
            #region Expression
            Console.WriteLine("Max length");
            var maxQuery = cities.Max(x => x.Length);
            Console.WriteLine("Max length of a city {0}", maxQuery);

            Console.WriteLine();
            #endregion
        }

        private static void Min()
        {
            #region Expression
            Console.WriteLine("Min length");
            var minQuery = cities.Min(x => x.Length);
            Console.WriteLine("Min length of a city {0}", minQuery);

            Console.WriteLine();
            #endregion
        }

        private static void NestedQuery()
        {
            #region Wrong Way to use nested query
            //Console.WriteLine(suppliers.Where(s => s.Name == "Apple").First().Id);
            //var query = from p in productsWithSupplier
            //            where p.SupplierId ==
            //                            (from s in suppliers // executes for each product
            //                             where s.Name == "Apple"
            //                             select s).FirstOrDefault().Id
            //            select p;

            //foreach (var p in query)
            //{
            //    Console.WriteLine(p.Name);
            //}
            //Console.WriteLine(); 
            #endregion

            #region Right Way to use nested query
            var supplierId = suppliers.Where(s => s.Name == "Apple").First().Id;
            var query2 = from p in productsWithSupplier
                         where p.SupplierId == supplierId
                         select p;

            foreach (var p in query2)
            {
                Console.WriteLine(p.Name);
            }
            Console.WriteLine();
            #endregion
        }

        private static void OfType()
        {
            // Used with non-generic collection like ArrayList
            Console.WriteLine("OfType");
            ArrayList list = new ArrayList();
            list.Add("One");
            list.Add(2);
            list.Add("Three");
            list.Add(new Object());

            var query = from item in list.OfType<string>()
                        select item;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            var query2 = from item in list.OfType<string>().Where(x => x.Length > 3) select item;

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }

        }

        private static void OrderBy()
        {
            #region Expression
            Console.WriteLine("OrderBy Expression");
            var orderExpression = cities.OrderBy(o => o);
            var descendingOrderExpression = cities.OrderByDescending(o => o);

            foreach (var city in orderExpression)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
            #endregion

            #region Query
            Console.WriteLine("OrderBy Query");
            var orderQuery = from city in cities
                             orderby city
                             select city;

            var descendingOrderQuery = from city in cities
                                       orderby city descending
                                       select city;

            foreach (var city in orderQuery)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
            #endregion

            #region Secondary Sort
            var query = Process.GetProcesses()
                               .OrderBy(p => p.ProcessName)
                               .ThenByDescending(p => p.Threads.Count);

            foreach (var item in query)
            {
                Console.WriteLine("{0} : {1}", item.ProcessName, item.Threads.Count);
            }

            Console.WriteLine();
            #endregion
        }

        private static void Projection()
        {
            var customers = CustomerRepository.GetSampleCustomers();

            #region Expression

            Console.WriteLine("Projection Expression");

            var londonCustomers = customers.Where(c => c.City == "London")
                                           .Select(c => c.Name);

            foreach (var item in londonCustomers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            #endregion

            #region Query
            Console.WriteLine("Projection Query");
            var londonCustomersQuery = from cust in customers
                                       where cust.City.Equals("London")
                                       select new { CustomerName = cust.Name };

            foreach (var item in londonCustomersQuery)
            {
                Console.WriteLine(item.CustomerName);
            }
            #endregion
        }

        private static void Reverse()
        {
            // Reverse
            Console.WriteLine("Reverse list items");
            var reverseQuery = cities.Reverse();
            foreach (var item in reverseQuery)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        private static void SelectMany()
        {
            string[] quotes = { 
                                  "This is a sample quote", 
                                  "C# is the most powerful language" 
                              };
            var query = quotes.SelectMany(s => s.Split(' '));
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void SequenceEqual()
        {
            Console.WriteLine("SequenceEqual");
            Customer c1 = new Customer { ID = 1 };
            Customer c2 = new Customer { ID = 2 };
            Customer c3 = new Customer { ID = 3 };

            var list1 = new List<Customer>() { c1, c2, c3 };
            var list2 = new List<Customer>() { c1, c3, c2 };
            var list3 = new List<Customer>() { c1, c2, c3 };
            Console.WriteLine("List1 == List2 " + list1.SequenceEqual(list2));
            Console.WriteLine("List1 == List3 " + list1.SequenceEqual(list3));
            Console.WriteLine();
        }

        private static void Skip()
        {
            #region Expression
            Console.WriteLine("Skip Expression");
            var skipExpression = cities.Skip(2).OrderBy(o => o);

            foreach (var item in skipExpression)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            #endregion

            #region Query
            Console.WriteLine("Skip Query");
            var skipQuery = from city in cities
                            orderby city
                            select city;

            var skip2 = skipQuery.Skip(2);

            foreach (var item in skip2)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();
            #endregion
        }

        private static void SkipWhile()
        {
            Console.WriteLine("SkipWhile");
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            IEnumerable<int> lowerGrades =
                grades
                .OrderByDescending(grade => grade)
                .SkipWhile(grade => grade >= 80);

            Console.WriteLine("All grades below 80:");
            foreach (int grade in lowerGrades)
            {
                Console.WriteLine(grade);
            }

            Console.WriteLine();
        }

        private static void Take()
        {
            #region Expression
            Console.WriteLine("Skip first two cities and display two cities");
            var skipTakeQuery = cities.Skip(2).Take(2).OrderBy(o => o);
            foreach (var item in skipTakeQuery)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            #endregion
        }

        private static void TakeWhile()
        {
            Console.WriteLine("TakeWhile");
            int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

            IEnumerable<int> lowerGrades =
                grades
                .OrderByDescending(grade => grade)
                .TakeWhile(grade => grade >= 80);

            Console.WriteLine("All grades above 80:");
            foreach (int grade in lowerGrades)
            {
                Console.WriteLine(grade);
            }

            Console.WriteLine();
        }

        private static void ToDictionary()
        {
            Console.WriteLine("ToDictionary");
            var dictionary = products.ToDictionary(p => p.ID, //key
                                                   p => p); //value

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " " + item.Value.Name);
            }
            Console.WriteLine();
        }

        private static void Union()
        {
            Console.WriteLine("Concat");
            string[] firstGroup = { "One", "Two", "Three" };
            string[] secondGroup = { "One", "Two", "Three", "Four", "Five", "Six" };
            var concat = firstGroup.Union(secondGroup);
            foreach (var item in concat)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        private static void Where()
        {
            #region Expression
            Console.WriteLine("Where Expression");
            var whereExpression = cities.Where(c => c.StartsWith("L"));

            foreach (var city in whereExpression)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
            #endregion

            #region Query
            Console.WriteLine("Where Query");
            var whereQuery = from city in cities
                             where city.StartsWith("L")
                             select city;
            foreach (var city in whereQuery)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
            #endregion
        }

        private static void Zip()
        {
            #region Expression
            var numbers = Enumerable.Range(1, 5);
            string[] numberAsString = { "One", "Two", "Three", "Four", "Five" };

            var numberPlusString = numbers.Zip(numberAsString, (num, str) =>
                num + ":" + str);

            foreach (var item in numberPlusString)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            #endregion
        }
    }
}
