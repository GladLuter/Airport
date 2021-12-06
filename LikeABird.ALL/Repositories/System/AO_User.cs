
using AutoMapper;
using LikeABird.IIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace LikeABird.ALL.Repositories.System;
public class AO_User<DO> : ApplicationModel<DO, AO_User<DO>> where DO : IDataObject<DO>, IGetRole
{
    public AO_User(IMapper CurMapper) : base(CurMapper)
    {
    }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string MainEmail { get; set; }
    //public AO_Role UserRole { get; set; }
    public string Password { get; set; }

    public override AO_User<DO> GetNewObj(AO_User<DO> obj)
    {
        if (obj is null)
        {
            return new(DataMapper);
        }
        else
        {
            return new(obj.DataMapper);
        }
    }

    protected override AO_User<DO> GetThis()
    {
        return this;
    }

}

