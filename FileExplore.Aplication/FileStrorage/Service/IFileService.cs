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
    public interface IFileService
    {
        ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath);

        ValueTask<StorageFile> GetFileByPathAsync(string filePath);

        IEnumerable<StorageFilesSummary> GetFilesSummary(IEnumerable<StorageFile> files);

        StorageFileType GetFileType(string filePath);
    }
}
