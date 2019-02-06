using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
	public class Program
	{
		static void Main(string[] args)
		{
			#region prepare

			// collection of the words in the dictionary file
			var wordCollection = new WordCollection($@"Data\dictionary.txt");

			#endregion

			#region input the start word and goal word

			Console.Write("input Start word: ");
			var startWord = Console.ReadLine();

			if (!wordCollection.Contains(startWord))
			{
				Console.WriteLine("inputted word does not exist. [END]");
				Console.ReadKey();
				return;
			}

			Console.Write("input Goal word: ");
			var goalWord = Console.ReadLine();

			if (!wordCollection.Contains(goalWord))
			{
				Console.WriteLine("inputted word does not exist. [END]");
				Console.ReadKey();
				return;
			}

			#endregion

			#region solve word ladder

			var wordLadderSolver = new WordLadderSolver(wordCollection);
			var route = wordLadderSolver.Solve(startWord, goalWord);

			#endregion

			#region show result

			if (!route.Any())
			{
				Console.WriteLine($"result: -1: No Ladder for \"{startWord}\" -> \"{goalWord}\"");
			}
			else
			{
				Console.WriteLine($"result: 1: Ladder for \"{startWord}\" -> \"{goalWord}\" found");
				Console.Write("[");
				Console.Write($"{string.Join(" ", route)}");
				Console.WriteLine("]");
			}

			Console.ReadKey();

			#endregion
		}
	}
}
