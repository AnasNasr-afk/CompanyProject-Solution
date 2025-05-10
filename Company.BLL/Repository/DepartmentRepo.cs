using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.BLL.Interface;
using Company.DAL.Contexts;
using Company.DAL.Models;

namespace Company.BLL.Repository
{
    public class DepartmentRepo : IDepartmentRepository
    {
        private readonly CompanyDbContext companyDbContext;

        public DepartmentRepo() { 
             companyDbContext = new CompanyDbContext();
        }
        public IEnumerable<Department> GetAll()
        
           =>  companyDbContext.Departments.ToList();
        

        public Department getById(int id)
        
            => companyDbContext.Departments.Find(id);
        

        public int Add(Department model)
        {
            companyDbContext.Departments.Add(model);
            return companyDbContext.SaveChanges();  
        }
        public int Update(Department model)
        {
            companyDbContext.Departments.Update(model);
            return companyDbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            companyDbContext.Remove(department);
            return companyDbContext.SaveChanges();
        }

        
        
    }
}
