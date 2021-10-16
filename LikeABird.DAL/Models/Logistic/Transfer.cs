﻿using LikeABird.DAL.Models.Earnings;
using LikeABird.DAL.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Logistic {
    public class Transfer {
        public int Id { get; set; }
        public Service Service { get; set; }
        public PointsRange PointsRange { get; set; }
    }
}
