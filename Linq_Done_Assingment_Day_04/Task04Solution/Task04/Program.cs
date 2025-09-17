using E_commerce_System.Context;
using E_commerce_System.Models;
using Health_Care_System.Context;
using Health_Care_System.Models;
using Library_System.Context;
using Library_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Task04
{
    internal class Program
    {
        static void Main()
        {
            // ---------------- ECOMMERCE ----------------
            using (var ecomContext = new ECommerceContext())
            {
                ecomContext.Database.EnsureCreated();

                if (!ecomContext.Products.Any())
                {
                    ecomContext.Products.AddRange(
                        new Product { Name = "Laptop", Price = 1500, Stock = 10 },
                        new Product { Name = "Headphones", Price = 200, Stock = 25 }
                    );
                }

                if (!ecomContext.Customers.Any())
                {
                    ecomContext.Customers.AddRange(
                        new Customer { FullName = "Ahmed Sherif", Email = "ahmed@example.com" },
                        new Customer { FullName = "Nada Ali", Email = "nada@example.com" }
                    );
                }

                ecomContext.SaveChanges();
            }

            // ---------------- LIBRARY ----------------
            using (var libContext = new LibraryContext())
            {
                libContext.Database.EnsureCreated();

                if (!libContext.Books.Any())
                {
                    libContext.Books.AddRange(
                        new Book { Title = "Clean Code", Author = "Robert C. Martin" },
                        new Book { Title = "Design Patterns", Author = "GoF" }
                    );
                }

                if (!libContext.Members.Any())
                {
                    libContext.Members.AddRange(
                        new Member { Name = "Omar Hassan", Email = "omar@example.com" },
                        new Member { Name = "Mona Adel", Email = "mona@example.com" }
                    );
                }

                libContext.SaveChanges();
            }

            // ---------------- HEALTH CARE ----------------
            using (var healthContext = new HealthCareContext())
            {
                healthContext.Database.EnsureCreated();

                if (!healthContext.Doctors.Any())
                {
                    healthContext.Doctors.AddRange(
                        new Doctor { Name = "Dr. Sarah Mohamed", Specialty = "Cardiology" },
                        new Doctor { Name = "Dr. Ali Hassan", Specialty = "Dermatology" }
                    );
                }

                if (!healthContext.Patients.Any())
                {
                    healthContext.Patients.AddRange(
                        new Patient { Name = "Hassan Ibrahim", DateOfBirth = new DateTime(1980, 5, 12) },
                        new Patient { Name = "Layla Hossam", DateOfBirth = new DateTime(1996, 9, 23) }
                        );
                }

                healthContext.SaveChanges();
            }

            Console.WriteLine("✅ Sample data inserted successfully into all systems!");
        }
    }
}
