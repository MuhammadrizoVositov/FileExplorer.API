using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Models.Setting
{
    public class FileFilterSettings
    {
        public ICollection<FileExtensionSettings> FileExtensions { get; set; } = default!;
    }
}
