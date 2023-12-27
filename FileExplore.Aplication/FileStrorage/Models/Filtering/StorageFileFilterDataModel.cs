using FileExplore.Aplication.Common.Model.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.FileStrorage.Models.Filtering
{
    public class StorageFileFilterDataModel
    {
        public List<StorageFilesSummary> FilterData { get; set; } = new();
    }
}
