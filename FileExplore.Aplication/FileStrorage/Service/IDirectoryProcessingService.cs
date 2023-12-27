using FileExplore.Aplication.FileStrorage.Models.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Service
{
    public interface IDirectoryProcessingService
    {
        ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel);
    }
}
