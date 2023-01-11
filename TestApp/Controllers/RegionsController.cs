using System;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models.Domain;
using TestApp.Models.DTO;
using TestApp.Repositories.Interfaces;

namespace TestApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
		{
			this.regionRepository = regionRepository;
			this.mapper = mapper;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllRegionsAsync()
		{
			var regions = await regionRepository.GetAllRegionsAsync();

            if (regions == null)
            {
                return NotFound();
            }

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
		}

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetRegionsAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }

    }
}

