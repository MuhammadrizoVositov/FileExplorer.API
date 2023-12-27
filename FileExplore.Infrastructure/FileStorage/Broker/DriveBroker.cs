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
    public class DriveBroker : IDriveBroker
    {
        private readonly IMapper _mapper;

        public DriveBroker(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<StorageDrive> Get()
        {
            return DriveInfo
           .GetDrives()
           .Select(drive => _mapper.Map<StorageDrive>(drive))
           .AsQueryable();
        }
    }
}
