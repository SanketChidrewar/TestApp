using System;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models.Domain;
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

			var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
		}

    }
}

