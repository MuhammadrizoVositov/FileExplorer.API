﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.Common.Model.Filtering
{
    public class FilterPagination
    {
        public uint PageSize { get; set; } = 10;

        public uint PageToken { get; set; } = 1;
    }
}
