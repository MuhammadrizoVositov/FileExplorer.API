using AutoMapper;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplorer.API.Models.Dto;

namespace FileExplorer.API.Common.MapperProfile
{
    public class DirectoryProfile:Profile 
    {
        public DirectoryProfile() 
        {
            CreateMap<StorageDirectory, StorageDirectoryDto>();
            CreateMap<StorageDirectoryDto, StorageDirectory>();
        }
    }
}
