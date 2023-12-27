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
    public class FileBroker : IFileBroker
    {

        private readonly IMapper _mapper;

        public FileBroker(IMapper mapper)
        {
            _mapper = mapper;
        }

        StorageFile IFileBroker.GetByPath(string filePath)
        {
            return _mapper.Map<StorageFile>(new FileInfo(filePath));
        }
    }
}
