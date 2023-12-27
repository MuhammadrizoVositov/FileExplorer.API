using AutoMapper;
using FileExplore.Aplication.FileStrorage.Models.Storage;
using FileExplorer.API.Models.Dto;

namespace FileExplorer.API.Common.MapperProfile
{
    public class DriveProfile:Profile
    {
         public DriveProfile()
        {

            CreateMap<StorageDriveDto, StorageDrive>();
            CreateMap<StorageDrive, StorageDriveDto>();
        }
    }
}
