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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
