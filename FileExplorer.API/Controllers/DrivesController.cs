﻿using AutoMapper;
using FileExplore.Aplication.FileStrorage.Service;
using FileExplorer.API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public DrivesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAsync([FromServices] IDriveService driveService)
        {
            var data = await driveService.GetAsync();
            var result = _mapper.Map<IEnumerable<StorageDriveDto>>(data);
            return result.Any() ? Ok(result) : NoContent();
        }
    }
}
