using FileExplore.Aplication.FileStrorage.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Models.Setting
{
    public class FileExtensionSettings
    {
        public StorageFileType FileType { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<string> Extensions { get; set; } = default!; 
    }
}
