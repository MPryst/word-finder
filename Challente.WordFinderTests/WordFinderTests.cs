using Challenge.WordFinder.Library;

namespace Challente.WordFinderTests
{
	public class Tests
	{
		[SetUp]
		public void Setup() { }

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

		/*
		 *	word	frecuency
			hello	3
			bee		1
			bye		2
			to		2
			car		2
			ten		2
			pie		2
			cool	2
			abba	2
			zzz		2
			nope	1
			beep	0
		 */
		[Test]
		public void WhenThereAreMoreThanTenItShouldReturnTheOnesWithMoreFrecuency()
		{
			var matrix = new List<string>{
				"ttcdefghij",
				"oohellobye",
				"abcdefghij",
				"hellofghij",
				"abcdehello",
				"abcdefghij",
				"abyeefccij",
				"abcdefaaij",
				"nbcdefrrij",
				"obcdefghzz",
				"pbcdefghzz",
				"ebcdefghzz",
				"abcdefghij",
				"tbcdefghij",
				"ebcdefghij",
				"nbcdefghij",
				"tbcdefghij",
				"ebcdefghij",
				"nbcdefghij",
				"abcdefabba",
				"piedefabba",
				"pbcoolghij",
				"ibcdefghij",
				"ebcoolgbee"
			};

			var wordFinder = new WordFinder(matrix);
			var wordStream = new[] { "hello", "bee", "bye", "to", "car", "ten", "pie", "cool", "abba", "zzz", "nope", "beep" };

			var result = wordFinder.Find(wordStream);

			Assert.True(result.Contains("hello"));
			Assert.True(result.Contains("bee"));
			Assert.True(result.Contains("bye"));
			Assert.True(result.Contains("to"));
			Assert.True(result.Contains("car"));
			Assert.True(result.Contains("ten"));
			Assert.True(result.Contains("pie"));
			Assert.True(result.Contains("cool"));
			Assert.True(result.Contains("abba"));
			Assert.True(result.Contains("zzz"));
			
			Assert.True(!result.Contains("nope"));
			Assert.True(!result.Contains("beep"));
		}
	}
}