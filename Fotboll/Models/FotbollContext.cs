using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotboll.Models
{
	public class FotbollContext : DbContext
	{
		public DbSet<Arena> Arena { get; set; }
		public DbSet<Team> Teams { get; set; }
	}
}
