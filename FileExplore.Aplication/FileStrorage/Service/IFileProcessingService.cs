using FileExplore.Aplication.FileStrorage.Models.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Service
{
    public interface IFileProcessingService
    {
        ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath);

        ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel);
    }
}
