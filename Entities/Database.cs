using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZBot.Entities
{
	public class Database : DbContext
	{
		private string _ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=PZDb;Trusted_Connection=True;";
	
		public DbSet<Channels> Channels { get; set; }
		public DbSet<ChannelCommands> ChannelCommands { get; set; }
		public DbSet<CommandVariables> CommandVariables { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Channels>()
				.HasMany(x => x.ChannelCommands)
				.WithOne(x => x.Channels)
				.HasForeignKey(x => x.ChannelId)
				.HasPrincipalKey(x => x.ChannelId);

			modelBuilder.Entity<ChannelCommands>()
				.HasMany(x => x.CommandVariables)
				.WithOne(x => x.ChannelCommands)
				.HasForeignKey(x => x.CommandId)
				.HasPrincipalKey(x => x.id);
			
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_ConnectionString);
		}
	}
}
