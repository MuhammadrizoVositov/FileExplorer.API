using AutoMapper;
using FileExplore.Aplication.FileStrorage.Broker;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Infrastructure.FileStorage.Broker
{
    public class DirectoryBroker : IDirectoryBroker
    {
        private readonly IMapper _mapper;

        public DirectoryBroker(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool ExistsAsync(string directoryPath)
        {
          return  Directory.Exists(directoryPath);
        }
         
        public string Get()
        {
            throw new NotImplementedException();
        }

        public  StorageDirectory GetByPathAsync(string directoryPath)
        {
          return _mapper.Map<StorageDirectory>(new DirectoryInfo(directoryPath));
        }

        public IEnumerable<StorageDirectory> GetDirectories(string directoryPath)
        {
            return      GetDirectoriesPath(directoryPath)
            .Select(path => _mapper.Map<StorageDirectory>(new DirectoryInfo(path)));
        }

        public IEnumerable<string> GetDirectoriesPath(string directoryPath)
        {
          return  Directory.EnumerateDirectories(directoryPath);
        }

        public IEnumerable<string> GetFilesPath(string directoryPath)
        {
              return Directory.EnumerateFiles(directoryPath);
        }
    }
}
