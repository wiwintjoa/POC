using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetByEmail(string email);       
    }
}
