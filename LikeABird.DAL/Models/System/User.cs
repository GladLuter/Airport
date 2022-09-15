using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Earnings;
using LikeABird.DAL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LikeABird.IIL;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LikeABird.DAL.Models.System;
public class User : BaseModel<User>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string MainEmail { get; set; }

    private Role UserRole_;
    [BackingField(nameof(UserRole_))]
    public Role UserRole { 
        get
        {
            if (UserRole_ == null && LazyLoader != null)
            {
                LazyLoader.Load(this, ref UserRole_);
            }
            return UserRole_;
        } 
        set 
        { 
            UserRole_ = value;
        } 
    }
    public string Password { get; set; }
    public virtual ICollection<UserOperation> UserOperations { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
    public User(ILazyLoader lazyLoader = null)
    {
        LazyLoader = lazyLoader;
        CurrentObject = this;
    }


    //public override User GetNewObj(User obj) {
    //    //if (obj is null) {
    //    //    return new();
    //    //} else {
    //        return new();
    //    //}
    //}


}

