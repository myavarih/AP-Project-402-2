// Ignore Spelling: Admins

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AP_Project.Back;
using Microsoft.EntityFrameworkCore;

namespace AP_Project
{
    internal class Database 
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string currentPath = AppDomain.CurrentDomain.BaseDirectory;
        //    optionsBuilder.UseSqlite(@"Data Source=" + currentPath + @"\DB.db");
        //}
        public List<User> Users { get; set; } = new List<User>();
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public List<Admin> Admins { get; set; } = new List<Admin>();
        public List<Complaint> Complaints { get; set; } = new List<Complaint>();

        public void SaveChanges()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText("database.json", json);
        }
        public static void Load()
        {
            Data.Database = JsonSerializer.Deserialize<Database>(File.ReadAllText("database.json")) ?? new Database();
        }
    }
}
