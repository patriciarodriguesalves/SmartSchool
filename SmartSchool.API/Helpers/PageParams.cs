﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;
        public int PageSize
        { 
            get { return pageSize; } 
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; } 
        }

        public int? Matricula { get; set; } = null;
        public String Nome { get; set; } = string.Empty;
        public int? Ativo { get; set; } = null;

    }
}
