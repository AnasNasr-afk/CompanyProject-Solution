using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.DAL.Models;

namespace Company.BLL.Interface
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll();

        public Department getById(int id);

        public int Add (Department model);

        public int Update (Department model);

        public int Delete (Department department);
    }
}
