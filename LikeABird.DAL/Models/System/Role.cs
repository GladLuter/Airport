﻿using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Earnings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.System {
    public class Role : BaseModel<Role> {
        public string Name { get; set; }
        public bool Employee { get; set; }
        public virtual ICollection<EmployeePermition> Permitions { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<EmployeePermition> EmployeePermitions { get; set; }
        public Role(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
    }
}
