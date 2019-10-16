using Microsoft.EntityFrameworkCore;
using Polynesians.Models.Entities;
using RosterMe.Models;
using RosterMe.Models.Entities;
using System;

namespace RosterMe.Data
{
    public class RosterMeContext: DbContext
    {
        //Class variables
        private static String LOG_TAG = "RosterMe Context class message";

        /* ---- Constructor ---- */
        public RosterMeContext(DbContextOptions<RosterMeContext> options)
            : base(options)
        {
        }

        /* ---------- Dashboard ---------- */
        //public DbSet<Dashboard> Dashboards { get; set; }

        /* ---------- Entities ---------- */
        /**
         * Entities declaration:
         * When declaring entities, be careful of giving the same name as the table.
         * 
         * For instance:
         * Entity: Employee
         * Table Name: Employees
         * */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<LoginTrail> LoginTrail { get; set; }
    }
}
