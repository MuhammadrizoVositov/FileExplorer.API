using FileExplore.Aplication.Common.Model.Filtering;
using FileExplore.Aplication.FileStrorage.Broker;
using FileExplore.Aplication.FileStrorage.Models.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Setting;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplore.Aplication.FileStrorage.Service;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Infrastructure.FileStorage.Service
{
    public class FileService : IFileService
    {
        private readonly FileFilterSettings _fileFilterSettings;
        private readonly FileStorageSettings _fileStorageSettings;
        private readonly IFileBroker _fileBroker;

        public FileService(IOptions<FileStorageSettings> fileStorageSettings, IOptions<FileFilterSettings> fileFilterSettings, IFileBroker fileBroker)
        {
            _fileStorageSettings = fileStorageSettings.Value;
            _fileFilterSettings = fileFilterSettings.Value;
            _fileBroker = fileBroker;
        }

        public  ValueTask<StorageFile> GetFileByPathAsync(string filePath) =>
         !string.IsNullOrWhiteSpace(filePath)
              ? new ValueTask<StorageFile>(_fileBroker.GetByPath(filePath))
              : throw new ArgumentNullException(nameof(filePath));
        

        public async ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
        {
            var files = await Task.Run(() => { return filesPath.Select(filePath => _fileBroker.GetByPath(filePath)).ToList(); });

            return files;
        }

        public IEnumerable<StorageFilesSummary> GetFilesSummary(IEnumerable<StorageFile> files)
        {
            var filesType = files.Select(file => (File: file, Type: GetFileType(file.Path)));
            return filesType
                .GroupBy(file => file.Type)
                .Select(filesGroup => new StorageFilesSummary
                {
                    FileType = filesGroup.Key,
                    DisplayName = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.DisplayName ??
                                  "Other files",
                    Count = filesGroup.Count(),
                    Size = filesGroup.Sum(file => file.File.Size),
                    ImageUrl = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.ImageUrl ??
                               _fileStorageSettings.FileImageUrl
                });
        }

        public StorageFileType GetFileType(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath).TrimStart('.');
            var matchedFileType = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.Extensions.Contains(fileExtension));
            return matchedFileType?.FileType ?? StorageFileType.Other;
        }
    }
}
