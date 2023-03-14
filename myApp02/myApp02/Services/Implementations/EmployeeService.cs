using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using myApp02.DAL.DBContext;
using myApp02.DAL.Entities;
using myApp02.DAL.Repositories.Interfaces;
using myApp02.Extensions;
using myApp02.Models.RequestViewModels;
using myApp02.Services.Interfaces;
using myApp02.DAL.Repositories.Implementations;

namespace myApp02.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IServiceProvider serviceProvider)
        {
            _employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
        }

        public async Task<List<EmployeeResponseModel>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            List<EmployeeResponseModel> result = new List<EmployeeResponseModel>();

            foreach (var employee in employees)
            {
                result.Add(employee.OneTwoKaFour<Employee, EmployeeResponseModel>());
            }
            return result;
        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            return employee.OneTwoKaFour<Employee, EmployeeResponseModel>();
        }

        public Task<string> AddEmployeeAsync(EmployeeResponseModel employee)
        {
            var input = employee.OneTwoKaFour<EmployeeResponseModel, Employee>();
            return _employeeRepository.AddEmployeeAsync(input);
        }

        public async Task<int> UpdateEmployeeAsync(int id, EmployeeResponseModel employee)
        {
            var input = employee.OneTwoKaFour<EmployeeResponseModel, Employee>();
            return await _employeeRepository.UpdateEmployeeAsync(id, input);
        }

        public async Task<int> DeleteEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.DeleteEmployeeByIdAsync(id);
        }

    }
}
