using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
	class WordLadderSolver
	{
		/// <summary>
		/// Word collection
		/// </summary>
		private WordCollection m_WordCollection;

		/// <summary>
		/// Looked word
		/// </summary>
		private List<string> m_LookedWord;

		#region construct

		/// <summary>
		/// Constructor
		/// </summary>
		public WordLadderSolver(WordCollection wordCollection)
		{
			m_WordCollection = wordCollection;
		}

		#endregion

		#region public

		/// <summary>
		/// Solve Word Ladder
		/// </summary>
		/// <param name="start">start word</param>
		/// <param name="goal">goal word</param>
		/// <returns>rout from start word to goal word</returns>
		public IEnumerable<string> Solve(string start, string goal)
		{
			if (start == goal)
			{
				return new List<string> { start };
			}

			// cannot solve when the length of start is different from length of goal
			if (start.Length != goal.Length)
			{
				return new List<string>();
			}

			// get n long words to traverse along only n long words
			var nLongWords = m_WordCollection.GetNLongWords(start.Length);
			if (nLongWords.Count < 2)
			{
				return new List<string>();
			}

			// route from start word to goal word
			var route = new List<string>();

			// stack containing only stat word
			var initialStack = new Stack<string>();
			initialStack.Push(start);

			// queue containing initial stack
			var queue = new Queue<Stack<string>>();
			queue.Enqueue(initialStack);

			// list of already looked words
			m_LookedWord = new List<string>
			{
				start
			};

			while (queue.Any())
			{
				var stack = queue.Dequeue();
				var item = stack.Pop();
				stack.Push(item);

				if (item == goal)
				{
					var result = stack.ToList();
					result.Reverse();
					return result;
				}

				foreach (var neighbor in FindNeighbors(item, nLongWords).Except(m_LookedWord))
				{
					if (!m_LookedWord.Contains(neighbor))
					{
						m_LookedWord.Add(neighbor);
					}
					var temp = new Stack<string>(stack.Reverse());
					temp.Push(neighbor);
					queue.Enqueue(temp);
				}
			}

			return new List<string>();
		}

		#endregion

		/// <summary>
		/// Find neighbor words from the argument word
		/// </summary>
		/// <param name="word">cardinal point</param>
		/// <param name="wordList">word in the range</param>
		/// <returns></returns>
		private List<string> FindNeighbors(string word, List<string> wordList)
		{
			return wordList.Where(item => IsNeighborWord(word, item)).ToList();

			#region internal method

			bool IsNeighborWord(string word1, string word2)
			{
				var diffs = 0;

				foreach (var character in word1.Zip(word2, (a, b) => new { a, b }))
				{
					if (character.a != character.b)
					{
						diffs++;

						if (diffs > 1)
						{
							return false;
						}
					}
				}

				return diffs == 1;
			}

			#endregion
		}
	}
}
