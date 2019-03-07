using DAL.Context;
using DAL.Migrations;
using System;
using System.Data.Entity;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
            new SomeService().DoSmth();

            Console.WriteLine("Main Completed");
        }
    }
}
