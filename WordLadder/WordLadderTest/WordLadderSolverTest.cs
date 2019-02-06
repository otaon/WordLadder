using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordLadder;

namespace WordLadderTest
{
	/// <summary>
	/// test for WordLadderSolver 
	/// </summary>
	[TestClass]
	public class WordLadderSolverTest
	{
		/// <summary>
		/// test for "word ladder solve"
		/// </summary>
		[TestMethod]
		public void WordLadderSolver_Solve()
		{
			#region expected

			var expectedLadders = new List<List<string>>
			{
				// start, goal
				// expected output
				new List<string>
				{
					"stone", "money",
					"[stone atone alone clone clons coons conns cones coney money]"
				},
				new List<string>
				{
					"babies", "sleepy",
					"[babies gabies gables gabled sabled sailed stiled stiles steles stells steels steeps sleeps sleepy]"
				},
				new List<string>{
					"devil", "angel",
					"[devil devel level lever leger luger auger anger angel]"
				},
				new List<string>{
					"monk", "perl",
					"[monk conk cork pork perk perl]"
				},
				new List<string>{
					"blue", "pink",
					"[blue blae blad bead beak peak penk pink]"
				},
				new List<string>{
					"heart", "heart",
					"[heart]"
				},
				new List<string>{
					"slow", "fast",
					"[slow slot slit flit fait fast]"
				},
				new List<string>{
					"atlas", "zebra",
					"[atlas aulas auras aures lures lares laris labis labia labra zabra zebra]"
				},
				new List<string>{
					"babes", "child",
					"[babes bales balls calls cells ceils ceili chili child]"
				},
				new List<string>{
					"train", "bikes",
					"[train brain brawn brown brows brogs biogs bings bines bikes]"
				},
				new List<string>{
					"brewing", "whiskey",
					"[brewing crewing chewing chowing choking cooking booking boobing bobbing bobbins bobbies bobbles babbles babbled wabbled warbled warsled warsted waisted whisted whisked whiskey]"
				},
				new List<string>{
					"men", "can",
					"[men man can]"
				},
				new List<string>{
					"money", "smart",
					"[money boney bones bonks boaks boars soars scars scart smart]"
				},
				new List<string>{
					"mumbo", "ghost",
					"[mumbo bumbo bombo bombs boobs blobs globs gloss glost ghost]"
				},
				new List<string>{
					"snow", "stop",
					"No Ladder for snow -> stop"
				},
			};

			#endregion

			#region prepare

			// collection of the words in the dictionary file
			var wordCollection = new WordCollection($@"Data\dictionary.txt");

			#endregion

			// execute test
			foreach (var item in expectedLadders)
			{
				var startWord = item[0];
				var goalWord = item[1];
				var expected = item[2];

				// solve word ladder
				var wordLadderSolver = new WordLadderSolver(wordCollection);
				var route = wordLadderSolver.Solve(startWord, goalWord);

				if (!route.Any())
				{
					// [TC] CASE: No Ladder found
					Assert.AreEqual(expected, $"No Ladder for {startWord} -> {goalWord}");
				}
				else
				{
					// [TC] CASE: Ladder found
					Assert.AreEqual(expected, $"[{string.Join(" ", route)}]");
				}
			}
		}
	}
}
