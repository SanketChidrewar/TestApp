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

	}
}

