namespace AccessibleAI.Bots.Language.Levenshtein.Tests;

public class LevenshteinMatchTests
{
    [Theory]
    [InlineData(0, 1.0)]
    [InlineData(100, 0.0)]
    public void StringsShouldHaveCorrectDistance(int distance, double expectedConfidence)
    {
        // Arrange
        LevenshteinEntry entry = new("Test", "Test", "Test");
        LevenshteinMatch match = entry.CreateMatch(distance);

        // Act
        IntentMatch intent = match.ToIntentMatch();

        // Assert
        intent.ConfidenceScore.ShouldBe(expectedConfidence);
    }

    [Theory]
    [InlineData("Hello", 1, 0.80)]
    public void ConfidenceScoreShouldBeCorrectGivenDistanceAndWords(string text, int distance, double expectedConfidence)
    {
        // Arrange
        LevenshteinEntry entry = new(text, "Test", "Test");
        LevenshteinMatch match = entry.CreateMatch(distance);

        // Act
        IntentMatch intent = match.ToIntentMatch();

        // Assert
        intent.ConfidenceScore.ShouldBe(expectedConfidence, double.Epsilon);
    }
}