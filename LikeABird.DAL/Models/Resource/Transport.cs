using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Resource {
    public enum SeatsLetters {
        A = 0,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N
    }
    [Serializable]
    public struct Seat {
        public int Number { get; set; }
        public SeatsLetters Letter { get; set; }
    }
    public abstract class Transport<T> : BaseModel<T> where T: BaseModel<T> {
        static public Seat[] GetSeats(int Lines, int Colums){
            Seat[] Seats = new Seat[Lines * Colums];
            int CurrNum = 0;
            for (int i = 0; i < Lines; i++) {
                for (int j = 0; j < Colums; j++) {
                    Seats[CurrNum].Number = i;
                    Seats[CurrNum].Letter = (SeatsLetters)Enum.ToObject(typeof(SeatsLetters), j);
                    CurrNum++;
                }
            }
            return Seats;
        }
        public virtual ICollection<Ticket> Tickets { get; set; }
        protected Transport(IDataContext incDb) : base(incDb) { }
    }
}
