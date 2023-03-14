using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myApp02.DAL.DBContext;
using myApp02.DAL.Entities;
using myApp02.Models.RequestViewModels;
using myApp02.Services.Interfaces;

namespace myApp02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("ClientIdPolicy")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IServiceProvider serviceProvider)
        {
            _employeeService = serviceProvider.GetRequiredService<IEmployeeService>();
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync()
        {
            var result = await _employeeService.GetAllEmployeesAsync();
            
            return result;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            
            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<string> AddEmployeeAsync(EmployeeResponseModel employee)
        {
            return await _employeeService.AddEmployeeAsync(employee);
        }

        [HttpPut("{id}")]
        public async Task<string> UpdateEmployeeAsync(int id, EmployeeResponseModel employee)
        {
            if (await _employeeService.UpdateEmployeeAsync(id, employee) > 0) { return "Success"; }
            else return "Please Try again later!!";
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteEmployeeByIdAsync(int id)
        {
            if (await _employeeService.DeleteEmployeeByIdAsync(id) > 0) { return "Success"; }
            else return "Please Try again later!!";
        }
    }
}
