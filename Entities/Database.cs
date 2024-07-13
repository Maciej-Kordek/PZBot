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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_ConnectionString);
		}
	}
}
