using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Resource;
using LikeABird.DAL.Models.System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Logistic;
public class Ticket : BaseModel<Ticket>
{
    public User User { get; set; }
    public Transport<Airplane> Transport { get; set; }
    [NotMapped]
    public Seat? Seat { get; set; }
    private string SeatJson
    {
        get { return JsonConvert.SerializeObject(Seat); }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                Seat = null;
            else
                Seat = JsonConvert.DeserializeObject<Seat>(value);
        }
    }
    public Transfer Transfer { get; set; }
    //public Ticket(IDataContext incDb) : base(incDb) {
    //    CurrentObject = this;
    //}
    //public Ticket() : this(null) { }
    //public override Ticket GetNewObj(Ticket obj) {
    //    if (obj is null) {
    //        return new(Db);
    //    } else {
    //        return new(obj.Db);
    //    }
    //}
}

