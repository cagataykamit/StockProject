﻿using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Category
{
    public class CategoryDto : IDto
    {
        public int? CategoryId { get; set; }
    }
}