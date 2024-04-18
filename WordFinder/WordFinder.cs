

namespace Challenge.WordFinder
{
	public class WordFinder
	{
		private int Columns { get; set; }
		private int Rows { get; set; }
		private Dictionary<char, IList<(int Row, int Column)>> CharDictionary { get; set; }
		private IEnumerable<string> Matrix { get; set; }

		public WordFinder(IEnumerable<string> matrix)
		{
			Matrix = matrix;
			Columns = matrix.First().Length;
			Rows = matrix.Count();

			CharDictionary = new Dictionary<char, IList<(int, int)>>();

			for (int row = 0; row < Rows; row++)
			{
				for (int column = 0; column < Columns; column++)
				{
					var currentChar = matrix.ElementAt(row)[column];
					if (!CharDictionary.ContainsKey(currentChar))
					{
						var values = new List<(int, int)> { (row, column) };
						CharDictionary.Add(currentChar, values);
					}
					else
					{
						CharDictionary[currentChar].Add((row, column));
					}
				}
			}
		}

		public IEnumerable<string> Find(IEnumerable<string> wordstream)
		{
			var wordstreamResult = new List<(string Word, int Occurrences)>();

			foreach (var word in wordstream.Distinct())
			{
				var occurrences = GetOcurrences(word);
				wordstreamResult.Add((word, occurrences));
			}

			var result = wordstreamResult
				.OrderByDescending(x => x.Occurrences)
				.Where( x => x.Occurrences > 0)
				.Take(10)
				.Select(x => x.Word);

			return result;
		}

		private int GetOcurrences(string word)
		{
			var result = 0;
			var startingCharacter = word[0];

			if (!CharDictionary.ContainsKey(startingCharacter))
				return result;

			foreach (var coordinate in CharDictionary[startingCharacter])
			{
				if (ContainsHorizontalWord(coordinate, word))
					result++;

				if (ContainsVerticallWord(coordinate, word))
					result++;

			}
			return result;
		}

		private bool ContainsHorizontalWord((int Row, int Column) coordinate, string word)
		{
			// Out of range check
			if (coordinate.Column + word.Length - 1 >= Columns)
				return false;

			for (var index = coordinate.Column; index <= coordinate.Column + word.Length - 1; index++)
			{				
				if (Matrix.ElementAt(coordinate.Row)[index] != word[Math.Abs(index - coordinate.Column)])
					return false;
			}
			return true;
		}

		private bool ContainsVerticallWord((int Row, int Column) coordinate, string word)
		{
			// Out of range check
			if (coordinate.Row + word.Length - 1 >= Rows)
				return false;

			for (var index = coordinate.Row; index <= coordinate.Row + word.Length - 1; index++)
			{				
				if (Matrix.ElementAt(index)[coordinate.Column] != word[Math.Abs(index - coordinate.Row)])
					return false;
			}
			return true;
		}
	}
}
