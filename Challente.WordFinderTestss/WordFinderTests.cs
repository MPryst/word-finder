using Challenge.WordFinder;

namespace Challente.WordFinderTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
			
		}

		[Test]
		public void WhenTheSampleDataIsSentItShouldWork()
		{
			var matrix = new List<string>{
				"abcdc",
				"fgwio",
				"chill",
				"pqnsd",
				"uvdxy"
			};

			var wordFinder = new WordFinder(matrix);
			var wordStream = new[] { "cold", "wind", "snow", "chill" };

			var result = wordFinder.Find(wordStream);
			
			Assert.True(result.Contains("cold"));
			Assert.True(result.Contains("wind"));
			Assert.True(result.Contains("chill"));

		}
	}
}