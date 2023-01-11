using System;
using TestApp.Models.Domain;

namespace TestApp.Repositories.Interfaces
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>> GetAllRegionsAsync();
        Task<Region> GetRegionsAsync(Guid id);
    }
}

