﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AddMemberVM
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
