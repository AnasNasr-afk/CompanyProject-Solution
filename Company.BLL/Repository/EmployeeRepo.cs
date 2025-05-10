using System;
using System.Collections.Generic;
using System.Linq;
using Company.BLL.Interface;
using Company.DAL.Contexts;
using Company.DAL.Models;

namespace Company.BLL.Repository
{
    public class EmployeeRepo : IEmployeeRepository
    {
        private readonly CompanyDbContext companyDbContext;

        public EmployeeRepo()
        {
            companyDbContext = new CompanyDbContext();
        }

     
        public IEnumerable<Employee> GetAll()
        =>
             companyDbContext.Employees.ToList();
        

        public Employee GetById(int id)
        =>
             companyDbContext.Employees.Find(id);
        

        
        public int Add(Employee employee)
        {
            companyDbContext.Employees.Add(employee);
            return companyDbContext.SaveChanges();  
        }

        
        public int Update(Employee employee)
        {
            companyDbContext.Employees.Update(employee);
            return companyDbContext.SaveChanges();  
        }

        public int Delete(Employee employee)
        {
            companyDbContext.Employees.Remove(employee);
            return companyDbContext.SaveChanges();  
        }
    }
}
