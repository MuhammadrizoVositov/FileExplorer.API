using AutoMapper;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplorer.API.Models.Dto;

namespace FileExplorer.API.Common.MapperProfile
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<StorageFile, StorageFileDto>();
            CreateMap<StorageFileDto, StorageFile>();
        }
    }
}
