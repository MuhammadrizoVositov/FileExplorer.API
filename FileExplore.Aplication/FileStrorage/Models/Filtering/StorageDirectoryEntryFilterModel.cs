using FileExplore.Aplication.Common.Model.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Models.Filtering
{
    public class StorageDirectoryEntryFilterModel:FilterPagination
    {
        public bool IncludeDirectories { get; set; }

        public bool IncludeFiles { get; set; }
    }
}
