﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.Models
{
    [Keyless]
    public class CategoriesTotalPrices
    {
        public string Name { get; set; }
        public int totalPrice { get; set; }
    }
}
