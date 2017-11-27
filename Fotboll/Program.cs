using Fotboll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotboll
{
	class Program
	{
		static void Main(string[] args)
		{
			FotbollContext ctx = new FotbollContext();
			Console.WriteLine("Enter arena name");
			var arenaName = Console.ReadLine();
			var anArena = new Arena();
			anArena.Name = arenaName;
			ctx.Arena.Add(anArena);
			ctx.SaveChanges();
			Console.WriteLine("Enter a team name");
			var teamName = Console.ReadLine();
			var aTeam = new Team();

			aTeam.Name = teamName;
			aTeam.Arena = anArena;

			ctx.Teams.Add(aTeam);
			ctx.SaveChanges();
			//List all teams and stadiums
			foreach (var theTeam in ctx.Teams)
			{
				Console.WriteLine($"{theTeam.Name}'s stadium is {theTeam.Arena.Name}");
			}

			Console.ReadKey();
		}
	}
}
