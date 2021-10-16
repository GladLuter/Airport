using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Interfaces {
    public enum SeatsLetters {
        A,
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
    public struct Seat {
        public int Number { get; set; }
        public SeatsLetters Letter { get; set; }
    }
    interface ITransportPassenger {
        public Seat[] Seat { get; set; }
    }
}
