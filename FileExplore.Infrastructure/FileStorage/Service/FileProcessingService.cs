using FileExplore.Aplication.Common.Model.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplore.Aplication.FileStrorage.Service;

namespace FileExplore.Infrastructure.FileStorage.Service;

public class FileProcessingService : IFileProcessingService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public FileProcessingService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }
    public async ValueTask<IList<StorageFile>> GetByFilterAsync(StorageFileFilterModel filterModel)
    {
        var filteredFilesPath = _directoryService
        .GetFilesPath(filterModel.DirectoryPath, filterModel)
        .Where(filePath => filterModel.FileTypes.Contains(_fileService.GetFileType(filePath)));

        var files = await _fileService.GetFilesByPathAsync(filteredFilesPath);

        return files;
    }

    public async ValueTask<StorageFileFilterDataModel> GetFilterDataModelAsync(string directoryPath)
    {
        var pagination = new FilterPagination
        {
            PageSize = int.MaxValue,
            PageToken = 1
        };

        var filesPath = _directoryService.GetFilesPath(directoryPath, pagination);
        var files = await _fileService.GetFilesByPathAsync(filesPath);


        var filesSummary = _fileService.GetFilesSummary(files);
        var filterDataModel = new StorageFileFilterDataModel
        {
            FilterData = filesSummary.ToList()
        };

        return filterDataModel;
    }
}
