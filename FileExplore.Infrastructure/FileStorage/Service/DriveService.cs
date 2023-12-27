using FileExplore.Aplication.FileStrorage.Broker;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplore.Aplication.FileStrorage.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Infrastructure.FileStorage.Service
{
    public class DriveService : IDriveService
    {
        private readonly IDriveBroker _broker;

        public DriveService(IDriveBroker broker)
        {
            _broker = broker;
        }
        public ValueTask<IList<StorageDrive>> GetAsync()
        {
            var drives = _broker.Get().ToList();

            return new ValueTask<IList<StorageDrive>>(drives);
        }
    }
}
