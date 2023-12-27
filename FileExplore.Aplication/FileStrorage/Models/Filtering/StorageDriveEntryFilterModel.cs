using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Models.Filtering
{
    public class StorageDriveEntryFilterModel
    {
        public bool IncludeDirectories { get; set; }

        public bool IncludeFiles { get; set; }
    }
}
