using AutoMapper;
using FileExplore.Aplication.Common.Model.Filtering;
using FileExplore.Aplication.FileStrorage.Broker;
using FileExplore.Aplication.FileStrorage.Models.Filtering;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplore.Aplication.FileStrorage.Service;
using FileExplore.Aplication.Common.Model.Querinng.Extensions;
using System.Net.Http.Headers;

namespace FileExplore.Infrastructure.FileStorage.Service
{

    public class DirectoryService : IDirectoryService
    {
        private readonly IDirectoryBroker _broker;
        private readonly IMapper _mapper;

        public DirectoryService(IDirectoryBroker broker, IMapper mapper)
        {
            _broker = broker;
            _mapper = mapper;
        }

        public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                throw new ArgumentNullException(nameof(directoryPath));
            return new ValueTask<StorageDirectory?>(_broker.GetByPathAsync(directoryPath));
        }
        
        public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
        {
            if(string.IsNullOrWhiteSpace(directoryPath)) 
            {
                throw new ArgumentNullException(nameof(directoryPath)); 
            }
            var directories = await Task.Run(() => _broker.GetDirectories(directoryPath).ApplyPagination(paginationOptions).ToList());
            return directories;
        }
        
            
        

        

        public IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions)=>
        
            _broker.GetFilesPath(directoryPath)
           .ApplyPagination(paginationOptions);
        

        public IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions)=>
            _broker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);
        
           
        
    }
}
