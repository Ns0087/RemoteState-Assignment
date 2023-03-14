using Microsoft.AspNetCore.Mvc;
using myApp02.DAL.Entities;

namespace myApp02.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<string> AddEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(int id, Employee employee);
        public Task<int> DeleteEmployeeByIdAsync(int id);
    }
}
