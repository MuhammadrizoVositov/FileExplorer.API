using FileExplore.Aplication.FileStrorage.Models.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplore.Aplication.FileStrorage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Infrastructure.FileStorage.Service
{
    public class DirectoryProcessingService : IDirectoryProcessingService
    {
        private readonly IFileService _fileService;
        private readonly IDirectoryService _directoryService;

        public DirectoryProcessingService(IFileService fileService, IDirectoryService directoryServices)//inject qilib olishlik
        {
            _fileService = fileService;
            _directoryService= directoryServices;
        }
        public  async ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel)
        {
            var storageItems=new List<IStorageEntry>();
            
            if (filterModel.IncludeDirectories)
                storageItems.AddRange(await _directoryService.GetDirectoriesAsync(directoryPath, filterModel));

            if (filterModel.IncludeFiles)
                storageItems.AddRange(await _fileService.GetFilesByPathAsync(_directoryService.GetFilesPath(directoryPath, filterModel)));
            
            return storageItems;

        }
    }
}
