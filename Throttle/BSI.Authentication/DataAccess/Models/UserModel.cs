﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("tblUser")]
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public string Email { get; set; }
    }
}
