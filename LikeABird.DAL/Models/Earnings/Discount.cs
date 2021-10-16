﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    enum DiscountType {
        Amount,
        Percent
    }
    class Discount {
        public Service Service { get; set; }
        public Role UserRole { get; set; }
        public DiscountType Type { get; set; }
        public double Amount { get; set; }

    }
}
