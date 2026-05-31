using HR_Pulse.Data;
using HR_Pulse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_Pulse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly HrPulseDbContext _context;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, HrPulseDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetEmployee")]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<Employee> GetById(Guid id)
        {
            var employee = _context.Employees.FirstOrDefault(emp => emp.Guid == id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
    }
}
