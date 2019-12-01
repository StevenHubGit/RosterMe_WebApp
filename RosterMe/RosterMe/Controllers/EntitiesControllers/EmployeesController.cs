using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RosterMe.Data;
using RosterMe.Models.Entities;

namespace RosterMe.Controllers.EntitiesControllers
{
    public class EmployeesController : Controller
    {
        //Class variables
        private static String LOG_TAG = "Employee Controller class message";
        private readonly RosterMeContext _context;

        /**
         * Constructor
         * */
        public EmployeesController(RosterMeContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            //
            var employees = await _context.Employees
                .Include(emp => emp.Department)
                .ToListAsync();

            //
            ViewData["EmployeesInDB"] = employees;

            //
            //return View(employees);
            return View(await _context.Employees
                //.Include(emp => emp.Department)
                .ToListAsync());
        }

        //GET : Employees
        public JsonResult EmployeesList()
        {
            var Employees = _context.Employees.Select(x => new
            {
                x.EmployeeId,
                x.FirstName,
                x.LastName//, x.Gender, x.DOB, x.Email,
                //x.HourlySalary, x.JoiningDate, x.PhoneNumber, x.Position,
                //x.ReportingManagerId,x.UserRole,x.ProfilePicture,x.DepartmentId,x.Contract
            }).ToList();
            return Json(Employees);
        }

        public JsonResult getDetails(int? id)
        {
            var employee = _context.Employees.Find(id);
            var model = new RosterMe.Models.Entities.Employee
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                DOB = employee.DOB,
                HourlySalary = employee.HourlySalary,
                JoiningDate = employee.JoiningDate,
                PhoneNumber = employee.PhoneNumber,
                Position = employee.Position,
                ReportingManagerId = employee.ReportingManagerId,
                DepartmentId = employee.DepartmentId,
                UserRole = employee.UserRole,
                Contract = employee.Contract,
                Email = employee.Email,
                ProfilePicture = employee.ProfilePicture
            };
            return Json(model);
        }

        public ActionResult List(string userRole)
        {
            if (userRole == "Admin")
            {
                return Json("/Employees/AdminListOfEmployees");
            }

            else if (userRole == "Manager")
            {
                return Json("/Employees/Index");
            }
            return Json("/Employees/Index");
        }

        public async Task<IActionResult> AdminListOfEmployees()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("EmployeeId,FirstName,LastName,Gender,ProfilePicture,DOB,JoiningDate,Position,PhoneNumber," +
            "Email,Contract,ReportingManagerId,DepartmentId,HourlySalary")] 
            Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Gender,ProfilePicture,DOB,JoiningDate,Position,PhoneNumber,Email,Contract,ReportingManagerId,DepartmentId,HourlySalary")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
