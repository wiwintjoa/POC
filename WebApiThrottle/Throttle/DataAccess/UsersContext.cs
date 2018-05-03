using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            :base("UsersContext")
        { }

        public DbSet<UserModel> Users { get; set; }
    }
}
