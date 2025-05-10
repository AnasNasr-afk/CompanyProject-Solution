using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL.Models;

namespace Company.BLL.Interface
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAll();  
        public Employee GetById(int id);
        public int Add(Employee employee);  
        public int Update(Employee employee);
        public int Delete(Employee employee);

    }
}
