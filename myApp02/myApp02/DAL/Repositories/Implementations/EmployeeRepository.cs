using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using myApp02.DAL.DBContext;
using myApp02.DAL.Entities;
using myApp02.DAL.Repositories.Interfaces;

namespace myApp02.DAL.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _employee;
        public EmployeeRepository(IServiceProvider serviceProvider)
        {
            _employee = serviceProvider.GetRequiredService<ApplicationDBContext>();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employee.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employee.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
            return employee;
        }

        public async Task<string> AddEmployeeAsync(Employee employee)
        {
            int result = 0;
            try
            {
                await _employee.Employees.AddAsync(employee);
                result = await _employee.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            
            if(result > 0)
            {
                return "Success";
            }
            else
            {
                return "Please try again later!!";
            }
        }

        public async Task<int> UpdateEmployeeAsync(int id, Employee employee)
        {
            int result = 0;
            var employee1 = await _employee.Employees.FindAsync(id);

            try
            {
                if (employee1 != null)
                {
                    employee1.Id = id;
                    employee1.FirstName = employee.FirstName;
                    employee1.LastName = employee.LastName;
                    employee1.Address = employee.Address;

                    result = await _employee.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }


            return result;
        }

        public async Task<int> DeleteEmployeeByIdAsync(int id)
        {
            int result = 0;
            var employee = await _employee.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
            try
            {
                if (employee != null)
                {
                    _employee.Employees.Remove(employee);
                    result = await _employee.SaveChangesAsync();
                }
            }catch(DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
            return result;
        }
    }
}
