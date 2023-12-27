using FileExplore.Aplication.Common.Model.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Models.Filtering
{
    public class StorageFileFilterModel : FilterPagination
    {
        public string DirectoryPath { get; set; } = string.Empty;

        public ICollection<StorageFileType> FileTypes { get; set; } = default!;
    }
}
