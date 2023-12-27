using AutoMapper;
using FileExplore.Aplication.FileStrorage.Models.Filtering;
using FileExplore.Aplication.FileStrorage.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoriesController : ControllerBase
    {
        private readonly IDirectoryProcessingService _directoryProcessingService;
        private readonly IMapper _mapper;

        public DirectoriesController(IDirectoryService directoryService, IDirectoryProcessingService directoryProcessingService, IMapper mapper)
        {
            _directoryProcessingService = directoryProcessingService;
            _mapper = mapper;
        }
        [HttpGet("root/entries")]
        public async ValueTask<IActionResult> GetRootEntriesAsync(
         [FromQuery] StorageDirectoryEntryFilterModel filterModel,
         [FromServices] IWebHostEnvironment environment
 )
        {
            var data = await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath, filterModel);
            return data.Any() ? Ok(data) : NoContent();
        }
        [HttpGet("{directoryPath}/entries")]
        public async ValueTask<IActionResult> GetDirectoryEntriesByPathAsync(
                [FromRoute] string directoryPath,
                [FromQuery] StorageDirectoryEntryFilterModel filterModel
  )
        {
            var data = await _directoryProcessingService.GetEntriesAsync(directoryPath, filterModel);
            return data.Any() ? Ok(data) : NoContent();
        }
    }
}
