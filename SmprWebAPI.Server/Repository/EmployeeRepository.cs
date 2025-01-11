using Microsoft.EntityFrameworkCore;
using SmprWebAPI.Server.Data;
using SmprWebAPI.Server.Models;

namespace SmprWebAPI.Server.Repository
{
	public class EmployeeRepository
	{
		private readonly AppDbContext _appDbContext;

		public EmployeeRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public async Task<List<Employee>> GetEmployees()
		{
			return await _appDbContext.Employees.ToListAsync();
		}
		public async Task SaveEmp(Employee employee)
		{
			await _appDbContext.Employees.AddAsync(employee);
			await _appDbContext.SaveChangesAsync();
		}
		public async Task DeleteEmp(int id)
		{
			var emp = await _appDbContext.Employees.FindAsync(id);
			if(emp != null)
			{
				_appDbContext.Employees.Remove(emp);
				await _appDbContext.SaveChangesAsync();
			}
		}
		public async Task Update(Employee employee)
		{
			var existingEmp = await _appDbContext.Employees.FindAsync(employee.Id);
			if(existingEmp != null)
			{
				existingEmp.Name = employee.Name;
				existingEmp.Email = employee.Email;
				existingEmp.Mobile = employee.Mobile;
				existingEmp.Age = employee.Age;
				existingEmp.Salary = employee.Salary;
				existingEmp.Status = employee.Status;
				
				
				_appDbContext.Employees.Update(employee);
				await _appDbContext.SaveChangesAsync();
			}
		}
		public async Task<Employee> GetEmpById(int id)
		{
			return await _appDbContext.Employees.FindAsync((id));
		}
	}
}
