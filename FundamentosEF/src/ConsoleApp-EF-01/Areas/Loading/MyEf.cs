using ConsoleApp_EF_01.Models;
using FundamentosEF.Core;
using FundamentosEF.Data;
using FundamentosEF.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp_EF_01.Areas.Loading
{
    public static class MyEf
    {
        public static NavigationModel Menu()
        {
            var id = (int)Options.Loading;
            var menu = new NavigationModel(id, "Loading", () => NavigationService.SaveOption(id));
            menu.Add(new NavigationModel(1, "Include All **All entities be included in the query results", MyEf.IncludeAll));
            menu.Add(new NavigationModel(2, "Load Multiple Results", MyEf.LoadMultipleResults));
            menu.Add(new NavigationModel(3, "Entry Collection Load", MyEf.CollectionLoad));
            menu.Add(new NavigationModel(4, "Entry Collection Query", MyEf.CollectionQuery));
            menu.Add(new NavigationModel(5, "Disabled Lazy Loading", MyEf.LazyLoadingDisabled));
            menu.Add(new NavigationModel(6, "Lazy Loader Proxies", MyEf.LazyLoaderProxies));
            menu.Add(new NavigationModel(7, "Lazy Loader Interface", MyEf.LazyLoaderInterface));
            menu.Add(new NavigationModel(8, "Lazy Loader Action", MyEf.LazyLoadingAction));
            menu.Add(new NavigationModel(9, "Clear Db", MyEf.ClearDb));
            menu.Add(new NavigationModel(0, "Back", () => NavigationService.Back()));
            return menu;
        }

        public static void LazyLoadingDisabled()
        {
            using var db = new FundamentosEF.Data.Proxies.ApplicationContext();
            db.ChangeTracker.LazyLoadingEnabled = false;

            var itens = db.Departments.ToList();

            foreach (var item in itens)
            {
                Helpers.Departaments.Write(item);
            }
        }

        public static void LazyLoadingAction()
        {
            using var db = new FundamentosEF.Data.LazyLoaderAction.ApplicationContext();             
            var departaments = db.Departaments.ToList();
            foreach (var item in departaments)
            {
                Helpers.Departaments.Write(item);
            }
        }
        public static void LazyLoaderProxies()
        {
            using var db = new FundamentosEF.Data.Proxies.ApplicationContext();   
            var departaments = db.Departments.ToList();

            foreach (var item in departaments)
            {
                Helpers.Departaments.Write(item);
            }
        }

        public static void LazyLoaderInterface()
        {
            using var db = new FundamentosEF.Data.LazyLoader.ApplicationContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated(); 

            var departaments = db.Departments.ToList();

            foreach (var item in departaments)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Department: {item.Description}");

                if (item.Employers?.Any() ?? false)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("| ID             | Name                                     |");
                    Console.WriteLine("| -------------- | ---------------------------------------- |");

                    foreach (var emp in item.Employers)
                    {
                        Console.WriteLine($"| {emp.Code} | {emp.Name} |");
                    }
                }
                else
                {
                    Console.WriteLine($"\tNo employees found!");
                }
            }
        }

        public static void LazyLoaderAction()
        {
            using var db = new FundamentosEF.Data.LazyLoader.ApplicationContext();
            var departaments = db.Departments.ToList();

            foreach (var item in departaments)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Department: {item.Description}");

                if (item.Employers?.Any() ?? false)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("| ID             | Name                                     |");
                    Console.WriteLine("| -------------- | ---------------------------------------- |");

                    foreach (var emp in item.Employers)
                    {
                        Console.WriteLine($"| {emp.Code} | {emp.Name} |");
                    }
                }
                else
                {
                    Console.WriteLine($"\tNo employees found!");
                }
            }
        }

        public static void CollectionQuery()
        {
            using var db = new ApplicationContext();
            var departaments = db.Departaments.ToList();

            foreach (var item in departaments)
            {
                if (item.Id == 2)
                {
                    db.Entry(item).Collection(p => p.Employers).Query().Where(p => p.Id > 2).ToList();
                }
                Helpers.Departaments.Write(item);
            }
        }

        public static void LoadMultipleResults()
        {
            using var db = new ApplicationContextMultiple();
            var departaments = db.Departments;

            foreach (var item in departaments)
            {
                if (item.Id == 2)
                {
                    db.Entry(item).Collection(p => p.Employers).Load();
                }

                Helpers.Departaments.Write(item);
            }
        }

        public static void CollectionLoad()
        {
            using var db = new ApplicationContext();
            var departaments = db.Departaments.ToList();

            foreach (var item in departaments)
            {
                if (item.Id == 2)
                {
                    db.Entry(item).Collection(p => p.Employers).Load();
                }
                Helpers.Departaments.Write(item);
            }
        }

        public static void IncludeAll()
        {
            using var db = new ApplicationContext();
            var departaments = db.Departaments.Include(p => p.Employers);

            foreach (var item in departaments)
            {
                Helpers.Departaments.Write(item);
            }
        }

        public static void ClearDb()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            PopulateDb(db);

            var departaments = db.Departaments.AsNoTracking().ToArray();
            Helpers.Employers.Write(departaments);
        }

        private static void PopulateDb(DbContext db)
        {
            var dbset = db.Set<Departament>();
            if (!dbset.Any())
            {
                dbset.AddRange(GenerateFaker.Departments(3));
                db.SaveChanges();
                db.ChangeTracker.Clear();
            }
        }
    }
}