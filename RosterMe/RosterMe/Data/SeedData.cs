using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RosterMe.Models;
using System;
using System.Linq;
using RosterMe.Models.Entities;

namespace RosterMe.Data
{
    public class SeedData
    {
        //Class variables

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RosterMeContext
            (
                serviceProvider.GetRequiredService<DbContextOptions<RosterMeContext>>()))
            {
                //Check if entities are empty
                if (context.Employees.Any())
                {
                    //DB has been seeded
                    return;
                }

                //Create default employees
                context.Employees.AddRange
                (
                    new Employee
                    {
                        FirstName = "Maraehau",
                        LastName = "Salmon",
                        Gender = "Male",
                        ProfilePicture = "SomePictureMS",
                        DOB = DateTime.Parse("26/04/1997"),
                        JoiningDate = DateTime.Parse("11/08/2019"),
                        Position = "Developper",
                        UserRole = "Admin",
                        PhoneNumber = 0225146171,
                        Email = "salmon.maraehau@outlook.com",
                        Contract = "Full-Time",
                        ReportingManagerId = 1,
                        DepartmentId = 1,
                        HourlySalary = 18
                    },

                    new Employee
                    {
                        FirstName = "Daryl",
                        LastName = "George",
                        Gender = "Male",
                        ProfilePicture = "SomePictureDG",
                        DOB = DateTime.Parse("05/08/1992"),
                        JoiningDate = DateTime.Parse("15/05/2019"),
                        Position = "Developper",
                        UserRole = "Admin",
                        PhoneNumber = 0210687315,
                        Email = "daryl.george@gmail.com",
                        Contract = "Full-Time",
                        ReportingManagerId = 1,
                        DepartmentId = 1,
                        HourlySalary = 18
                    },

                    new Employee
                    {
                        FirstName = "Pooja",
                        LastName = "Khaire",
                        Gender = "Female",
                        ProfilePicture = "SomePicturePK",
                        DOB = DateTime.Parse("18/06/1994"),
                        JoiningDate = DateTime.Parse("08/11/2019"),
                        Position = "Developper",
                        UserRole = "Admin",
                        PhoneNumber = 0227804682,
                        Email = "pooja.khaire@gmail.com",
                        Contract = "Full-Time",
                        ReportingManagerId = 1,
                        DepartmentId = 1,
                        HourlySalary = 18
                    },

                    new Employee
                    {
                        FirstName = "Ellen",
                        LastName = "Partson",
                        Gender = "Female",
                        ProfilePicture = "SomePictureEP",
                        DOB = DateTime.Parse("11/05/1988"),
                        JoiningDate = DateTime.Parse("25/09/2019"),
                        Position = "Consultant",
                        UserRole = "Manager",
                        PhoneNumber = 0219864852,
                        Email = "ellen.partson@gmail.com",
                        Contract = "Full-Time",
                        ReportingManagerId = 1,
                        DepartmentId = 3,
                        HourlySalary = 18
                    },

                    new Employee
                    {
                        FirstName = "John",
                        LastName = "English",
                        Gender = "Male",
                        ProfilePicture = "SomePictureJE",
                        DOB = DateTime.Parse("05/11/1987"),
                        JoiningDate = DateTime.Parse("05/02/2017"),
                        Position = "Consultant",
                        UserRole = "Employee",
                        PhoneNumber = 0228705164,
                        Email = "john.english@gmail.com",
                        Contract = "Part Time",
                        ReportingManagerId = 1,
                        DepartmentId = 2,
                        HourlySalary = 18
                    }
                );

                //Save changes
                context.SaveChanges();
            }
        }
    }
}
