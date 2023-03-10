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

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population,
            };

            region = await regionRepository.AddRegionAsync(region);

            var regionDTO = new Models.DTO.Region()
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteRegionAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Models.DTO.Region>(region));
        }

        [HttpPut]
        public async Task<IActionResult> updateRegionAsync([FromBody] Models.DTO.Region regionToBeUpdated)
        {
            var updatedRegion = await regionRepository.UpdateRegionAsync(regionToBeUpdated.Id, mapper.Map<Models.Domain.Region>(regionToBeUpdated));

            if(updatedRegion == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Models.DTO.Region>(updatedRegion));
        }



    }
}

