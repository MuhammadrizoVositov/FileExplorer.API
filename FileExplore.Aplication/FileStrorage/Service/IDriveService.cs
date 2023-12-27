using FileExplore.Aplication.FileStrorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Service
{
    public interface IDriveService
    {
        ValueTask<IList<StorageDrive>> GetAsync();
    }
}
