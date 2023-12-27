using FileExplore.Aplication.FileStrorage.Models.Storage;

namespace FileExplorer.API.Models.Dto
{
    public class IStorageItemDto
    {
        string Path { get; set; }

        StorageEntryType EntryType { get; set; }
    }
}
