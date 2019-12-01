using Microsoft.EntityFrameworkCore;
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
        public DbSet<Login> Login { get; set; }
        public DbSet<LoginTrail> LoginTrail { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<BookedShifts> BookedShifts { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<ShiftInvitation> ShiftInvitation { get; set; }
        public DbSet<Timesheets> Timesheets { get; set; }
        public DbSet<PasswordRequest> PasswordRequest { get; set; }
    }
}
