using Challenge.WordFinder;

var matrix = new List<string>
{
	"abcdc",
	"fgwio",
	"chill",
	"pqnsd",
	"uvdxy"
};

var wordFinder = new WordFinder(matrix);
var wordStream = new[] { "cold", "wind", "snow", "chill" };

Console.WriteLine($"About to search for: {string.Join(",", wordStream)}");

Console.WriteLine($"The found elemets are: {string.Join(",", wordFinder.Find(wordStream))}");