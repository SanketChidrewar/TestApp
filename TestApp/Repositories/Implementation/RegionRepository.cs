using System;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models.Domain;
using TestApp.Repositories.Interfaces;

namespace TestApp.Repositories.Implementation
{
	public class RegionRepository : IRegionRepository
    {
		private readonly TestAppDbContext testAppDbContext;

		public RegionRepository(TestAppDbContext testAppDbContext)
		{
			this.testAppDbContext = testAppDbContext;
		}

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
		{
			return await testAppDbContext.Regions.ToListAsync();
		}

        public async Task<Region> GetRegionsAsync(Guid id)
        {
			return await testAppDbContext.Regions.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await testAppDbContext.AddAsync(region);
            await testAppDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegionAsync(Guid id)
        {
            var region = await testAppDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            testAppDbContext.Regions.Remove(region);
            await testAppDbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> UpdateRegionAsync(Guid id, Region updatedRegion)
        {
            var existingRegion = await testAppDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = updatedRegion.Code;
            existingRegion.Name = updatedRegion.Name;
            existingRegion.Area = updatedRegion.Area;
            existingRegion.Lat = updatedRegion.Lat;
            existingRegion.Long = updatedRegion.Long;
            existingRegion.Population = updatedRegion.Population;

            await testAppDbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}

