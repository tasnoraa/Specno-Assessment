using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpecnoRepository.Models;
using System;

namespace SpecnoRepository
{
	public class RedditDbContext : IdentityDbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(@"Server=.;Database=OrgAPIDb;Trusted_Connection=True;");
		}

		public DbSet<Like> Likes { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
