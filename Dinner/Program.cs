﻿using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Dinner
{
	class Program
	{
		static void Main(string[] args)
		{
			(string, string)[] table = new (string, string)[14];
			table[0] = ("SP", "hr. Sepp"); // ei meeldi pr. Elkin
			table[7] = ("SH", "pr. Sepp"); // ei meeldi hr. Bertini

			List<(string, string)> guests = new List<(string, string)>()
			{
				("E+", "Anni Elkin"), // armunud
				("S+", "Kalle Sepp"), // armunud
				("JR", "Jenny Harner"), // professor ja hr. Sepa kolleeg, 
				// oskab rääkida huvitavaid lugusid, kuid on antisimitist
				("E", "Margaret Elkin"), // väga korrekne, viisakas ja ebahuvitav
				("M", "kohtunik Master"), // hea kuulaja, äärmiselt taktitundeline
				("K", "kirikuõpetaja Siidak"), // meeldib anda nõuda
				("R", "Rabi Simons"), // meeldib vaielda, kuid ta pole kunagi kiuslik
				("S", "vanaproua Sepp"), // räägib palju, on natuke rumal ja peaaegu kurt
				("HBV", "hr. Bertini"), // äärmiselt parempoolsete vaadetega
				("PB", "pr. Bertini"), // lauakombed on väga halvad ja ta kurdab alati
				("S", "Mari Sepp"), // hellitatud ja rahutu, 
				// sageli ebaviisakas oma vanemate ja vanaema vastu
				("VE", "Allan Elkin") // vasakpoolne, on väga huvitatud sotsiaalsetest teemadest
			};

			bool isTableFull = false;

			while (!isTableFull)
			{
				isTableFull = true;
				foreach (var guest in guests)
				{
					for (int i = 0; i < 14; i++)
					{
						if (table[i] == (null, null))
						{
							isTableFull = false;
							bool isSeatFitFor = true;
							int ii = i == 13 ? 7 : i + 1;
							foreach (var @char in guest.Item1)
							{
								if (@char < 'A')
									continue;
								if ( (table[i - 1].Item1 != null && table[i - 1].Item1.Contains(@char))
									|| (table[ii].Item1 != null && table[ii].Item1.Contains(@char))
									|| (table[14 - i].Item1 != null && table[14 - i].Item1.Contains(@char)))
								{
									isSeatFitFor = false;
								}
							}
							if(isSeatFitFor)
								table[i] = guest;
							break;
						}
					}
				}
			}

			Console.WriteLine($"        0 | {table[0].Item2} | ");
			for (int i = 1; i < 7; i++)
			{
				Console.WriteLine($"{i} | {table[i].Item2} |  | {table[14-i].Item2} | {14-i}");
			}
			Console.WriteLine($"        7 | {table[7].Item2} | ");
		}
	}
}
