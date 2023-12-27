using AutoMapper;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplorer.API.Models.Dto;

namespace FileExplorer.API.Common.MapperProfile
{
    public class StorageItemProfile : Profile
    {
        public StorageItemProfile()
        {
            CreateMap<IStorageEntry, IStorageItemDto>();
            CreateMap<IStorageItemDto, IStorageEntry>();
        }
    }
}
