using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DittoBox.API.Shared.Infrastructure
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<Container> Containers { get; set; }
		public DbSet<Template> Templates { get; set; }
		public DbSet<Notification> Notifications { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			
			modelBuilder.Entity<Container>()
				.OwnsOne(c => c.ContainerConditions);

		}

	}

}