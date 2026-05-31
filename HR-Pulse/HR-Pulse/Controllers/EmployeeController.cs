using HR_Pulse.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_Pulse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private static readonly List<Employee> employees = new List<Employee>
        {
            new() {
                Guid = Guid.NewGuid(),
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                Password = "Password123!",
                Phone = "555-123-4567",
                Title = "Software Engineer",
                Address = "123 Main St",
                City = "Springfield",
                State = "IL",
                ZipCode = "62701"
            },
            new()
            {
                Guid = Guid.NewGuid(),
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@example.com",
                Password = "SecurePass456!",
                Phone = "555-987-6543",
                Title = "HR Manager",
                Address = "456 Elm St",
                City = "Springfield",
                State = "IL",
                ZipCode = "62702"
            },
            new()
            {
                Guid = Guid.NewGuid(),
                FirstName = "Carol",
                LastName = "Williams",
                Email = "carol.williams@example.com",
                Password = "MyPass789!",
                Phone = "555-555-1212",
                Title = "Accountant",
                Address = "789 Oak St",
                City = "Springfield",
                State = "IL",
                ZipCode = "62703"
            }
        };

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEmployee")]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<Employee> GetById(Guid id)
        {
            var employee = employees.FirstOrDefault(emp => emp.Guid == id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
    }
}
