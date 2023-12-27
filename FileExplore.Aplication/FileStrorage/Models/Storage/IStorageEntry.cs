using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Models.Storage
{
    public interface IStorageEntry
    {
        string Path { get; set; }

        StorageEntryType EntryType { get; set; }

    }
}
