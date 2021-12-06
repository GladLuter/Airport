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

namespace LikeABird.DAL.Models.System;
public class User : BaseModel<User>, IGetRole
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string MainEmail { get; set; }
    public Role UserRole { get; set; }
    public string Password { get; set; }
    public virtual ICollection<UserOperation> UserOperations { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
    public User()
    {
        CurrentObject = this;
        SetCurRoleFromDB();
    }
    private async void SetCurRoleFromDB(IDataContext inDB = null)
    {
        Role EmptyRole = new();
        if (EmptyRole is null)
            return;

        int RoleId = (int)(inDB ?? Db).Entry<User>(this).Property("UserRoleId").CurrentValue;
        var a15 = (int)(inDB ?? Db).Entry<User>(this).Property("UserRoleId").OriginalValue;
        if (RoleId <= 0)
            return;

        UserRole = await EmptyRole.SelectByIdAsync(RoleId);

        //if (RoleResult is not null)
        //    UserRole = RoleResult;
    }

    //public override User GetNewObj(User obj) {
    //    //if (obj is null) {
    //    //    return new();
    //    //} else {
    //        return new();
    //    //}
    //}
    protected override void InitializeFilds(IDataContext inDB)
    {
        SetCurRoleFromDB(inDB);
    }

    public Task GetRole()
    {
        if (UserRole is null)
            SetCurRoleFromDB();
        return Task.Factory.StartNew(() => UserRole);
    }
}

