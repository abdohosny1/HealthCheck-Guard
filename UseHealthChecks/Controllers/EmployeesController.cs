using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyUseHealthChecks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;



        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _unitOfWork.Employees.GellAllAsync());
        }

        [HttpPost]

        public async Task<IActionResult> Add(Employee employee)
        {
            return Ok(await _unitOfWork.Employees.AddAsync(employee));
        }

    }
}
