using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interfaces
{
    public interface IUserService
    {
        void Add(UserModel User);     // Create New User
        void Update(UserModel User);  // Modify User
        //void Delete(UserModel User);  // Delete User
        UserModel LoginUser(string id, string password); // Get an Single User details by id
        IEnumerable<UserModel> GetAll();  // Gets All User details
    }
}
