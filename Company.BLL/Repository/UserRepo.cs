using Company.DAL.Contexts;
using Company.DAL.Models;
using System.Linq;

namespace Company.BLL.Repository
{
    public class UserRepo
    {
        private readonly CompanyDbContext _companyDbContext;

        public UserRepo(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }

        public int Register(User user)
        {
            // Check if the username already exists in the database
            if (_companyDbContext.Users.Any(u => u.Username == user.Username))
                return -1;

            _companyDbContext.Users.Add(user);
            _companyDbContext.SaveChanges();
            return 1;
        }

        public User Login(string username, string password)
        {
            return _companyDbContext.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
