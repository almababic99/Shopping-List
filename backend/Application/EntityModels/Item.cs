﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int? ShopperId { get; set; }
    }
}
