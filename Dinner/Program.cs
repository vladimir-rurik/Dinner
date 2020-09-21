using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Xml.Schema;

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

			List<(string, string)> tableGuests = new List<(string, string)>();

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
								if ((table[i - 1].Item1 != null && table[i - 1].Item1.Contains(@char))
									|| (table[ii].Item1 != null && table[ii].Item1.Contains(@char))
									|| (table[14 - i].Item1 != null && table[14 - i].Item1.Contains(@char)))
								{
									isSeatFitFor = false;
								}
							}
							if (isSeatFitFor && !tableGuests.Contains(guest))
							{
								table[i] = guest;
								tableGuests.Add(guest);
							}
							break;
						}
					}
				}
			}

			Print(table);

			//foreach (var item in Permutate(guests.Select(n => n.Item2).ToList(), 8)) //guests.Count = 12
			//{
			//	foreach(var s in item)
			//		Console.Write(s+" , ");
			//	Console.WriteLine();
			//}

			//var allCombinations = guests.Select(n => n.Item2).Permute();
			//var stringList = new List<string>();

			//         Console.WriteLine(allCombinations.Count());

			//foreach (var item in allCombinations)
			//{
			//	stringList.Add(string.Join(",", item.ToArray()));
			//	foreach(var s in stringList)
			//		Console.WriteLine(s);
			//}
		}

		static string FormatGuestName(string name, char filler = ' ')
		{
			return $"{name}{new string(filler, 20 - name.Length)}";
		}

		static void Print((string, string)[] table)
		{
			Console.WriteLine($"                       0 | {FormatGuestName(table[0].Item2)} | ");
			Console.WriteLine($"                         | {FormatGuestName("", '-')} | ");
			for (int i = 1; i < 7; i++)
			{
				Console.WriteLine($"{i} | {FormatGuestName(table[i].Item2)} |                      | {FormatGuestName(table[14 - i].Item2)} | {14 - i}");
			}
			Console.WriteLine($"                         | {FormatGuestName("", '-')} | ");
			Console.WriteLine($"                       7 | {FormatGuestName(table[7].Item2)} | ");
			Console.WriteLine();
			Console.WriteLine();
		}

		public static void RotateRight(IList sequence, int count)
		{
			object tmp = sequence[count - 1];
			sequence.RemoveAt(count - 1);
			sequence.Insert(0, tmp);
		}

		public static IEnumerable<IList> Permutate(IList sequence, int count)
		{
			if (count == 1) yield return sequence;
			else
			{
				for (int i = 0; i < count; i++)
				{
					foreach (var perm in Permutate(sequence, count - 1))
						yield return perm;
					RotateRight(sequence, count);
				}
			}
		}
	}
}
