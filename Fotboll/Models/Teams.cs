using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotboll.Models
{
	public class Team
	{
		public int TeamId { get; set; }
		public int ArenaId { get; set; }
		public virtual Arena Arena { get; set; }
		public virtual List<Player> Players { get; set; } = new List<Player>();
		public string Name { get; set; }
		
	}
}
