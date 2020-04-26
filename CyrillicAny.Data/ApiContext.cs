using System;
using System.Linq;
using System.Threading.Tasks;
using CyrillicAny.Entity;
using CyrillicAny.Entity.SearchedQueries;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CyrillicAny.Data
{
	public class ApiContext : IdentityDbContext
	{
		public ApiContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<SearchedQuery> Queries { get; set; }


		public override int SaveChanges()
		{
			AddAuditInfo();
			return base.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			AddAuditInfo();
			return await base.SaveChangesAsync();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SearchedQuery>();
			base.OnModelCreating(modelBuilder);
		}

		private void AddAuditInfo()
		{
			var entries = ChangeTracker.Entries()
										.Where(x =>
											x.Entity is IEntity &&
											(x.State == EntityState.Added || x.State == EntityState.Modified));
			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Added)
				{
					((IEntity) entry.Entity).Created = DateTime.UtcNow;
				}

				((IEntity) entry.Entity).Modified = DateTime.UtcNow;
			}
		}
	}
}