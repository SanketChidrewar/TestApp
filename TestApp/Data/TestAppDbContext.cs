using System;
using Microsoft.EntityFrameworkCore;
using TestApp.Models.Domain;

namespace TestApp.Data
{
	public class TestAppDbContext : DbContext
	{

		public TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options)
		{

		}

		public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

    }
}

