using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
	/// <summary>
	/// collection of words in dictionary
	/// </summary>
	public class WordCollection
	{
		/// <summary>
		/// all words in dictionary
		/// </summary>
		private List<string> Words;

		public WordCollection(string pathToDictionary)
		{
			LoadFile(pathToDictionary);
		}

		public void LoadFile(string path)
		{
			var fullPath = Path.GetFullPath(path);
			Words = File.ReadLines(fullPath).ToList();
		}

		/// <summary>
		/// Is the word in the dictionary?
		/// </summary>
		/// <param name="word"></param>
		/// <returns></returns>
		public bool Contains(string word) => Words.Contains(word);

		/// <summary>
		/// get N long words
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public List<string> GetNLongWords(int length)
		{
			return Words.Where(w => w.Length == length).ToList();
		}
	}
}
