using System;
using System.Collections.Generic;

namespace Dinner
{
	class Program
	{
		static void Main(string[] args)
		{
			(string, string)[] table = new (string, string)[10];
			table[0] = ("S", "hr. Sepp");
			table[7] = ("S", "pr. Sepp");

			List<(string, string)> guests = new List<(string, string)>()
			{
				("E", "Anni Elkin"), // armunud
				("S", "Kalle Sepp"), // armunud
				("HR", "Jenny Harner"), // professor ja hr. Sepa kolleeg, 
				// oskab rääkida huvitavaid lugusid, kuid on antisimitist
				("E", "Margaret Elkin"), // väga korrekne, viisakas ja ebahuvitav
				("M", "kohtunik Master"), // hea kuulaja, äärmiselt taktitundeline
			};

			Console.WriteLine("Hello World!");
		}
	}
}
