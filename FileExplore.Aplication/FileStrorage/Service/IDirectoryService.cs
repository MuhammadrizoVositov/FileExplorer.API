using FileExplore.Aplication.Common.Model.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Service
{
    public interface IDirectoryService
    {
        IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions);

        IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions);

        ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions);

        ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath);
    }
}
