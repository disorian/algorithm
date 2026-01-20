namespace Playground.Tests.Session2;

using Playground.Session2;

public class IsPalindromeTests
{
    // Helper method to execute the IsPalindrome algorithm
    private static bool IsPalindrome(string s)
    {
        var twoPointers = new TwoPointersOppositeDirection();
        return twoPointers.IsPalindrome(s);
    }

    #region Basic Functionality Tests

    [Fact]
    public void IsPalindrome_SingleWord_ReturnsTrue()
    {
        // Arrange
        var input = "racecar";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_SimpleWord_ReturnsTrue()
    {
        // Arrange
        var input = "level";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_NotPalindrome_ReturnsFalse()
    {
        // Arrange
        var input = "hello";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPalindrome_SingleCharacter_ReturnsTrue()
    {
        // Arrange
        var input = "a";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_TwoSameCharacters_ReturnsTrue()
    {
        // Arrange
        var input = "aa";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_TwoDifferentCharacters_ReturnsFalse()
    {
        // Arrange
        var input = "ab";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Case Sensitivity Tests

    [Fact]
    public void IsPalindrome_MixedCase_ReturnsTrue()
    {
        // Arrange
        var input = "RaceCar";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_AllUpperCase_ReturnsTrue()
    {
        // Arrange
        var input = "RACECAR";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Special Characters and Spaces

    [Fact]
    public void IsPalindrome_WithSpaces_ReturnsTrue()
    {
        // Arrange
        var input = "race car";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_WithPunctuation_ReturnsTrue()
    {
        // Arrange
        var input = "A man, a plan, a canal: Panama";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_WithApostrophe_ReturnsTrue()
    {
        // Arrange
        var input = "Madam, I'm Adam";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_PhrasePalindrome_ReturnsTrue()
    {
        // Arrange
        var input = "Never odd or even";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_OnlySpecialCharacters_ReturnsTrue()
    {
        // Arrange
        var input = "!@#$%";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_SpecialCharactersBetweenLetters_ReturnsFalse()
    {
        // Arrange
        var input = "a!b";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Alphanumeric Tests

    [Fact]
    public void IsPalindrome_WithNumbers_ReturnsTrue()
    {
        // Arrange
        var input = "12321";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_MixedLettersAndNumbers_ReturnsTrue()
    {
        // Arrange
        var input = "A1B2B1A";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_DateFormat_ReturnsTrue()
    {
        // Arrange
        var input = "02/02/2020"; // Only digits are considered

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void IsPalindrome_EmptyString_ReturnsTrue()
    {
        // Arrange
        var input = "";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_NullString_ReturnsTrue()
    {
        // Arrange
        string? input = null;

        // Act
        var result = IsPalindrome(input!);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_WhitespaceOnly_ReturnsTrue()
    {
        // Arrange
        var input = "   ";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_TabsAndNewlines_ReturnsTrue()
    {
        // Arrange
        var input = "\t\n\r";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Additional Word Examples

    [Fact]
    public void IsPalindrome_Noon_ReturnsTrue()
    {
        // Arrange
        var input = "noon";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_Kayak_ReturnsTrue()
    {
        // Arrange
        var input = "kayak";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_Radar_ReturnsTrue()
    {
        // Arrange
        var input = "radar";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Long Strings

    [Fact]
    public void IsPalindrome_LongPalindrome_ReturnsTrue()
    {
        // Arrange
        var input = "abcdefghijklmnopqrstuvwxyzzyxwvutsrqponmlkjihgfedcba";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_LongNonPalindrome_ReturnsFalse()
    {
        // Arrange
        var input = "abcdefghijklmnopqrstuvwxyz";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Boundary Tests

    [Fact]
    public void IsPalindrome_OddLengthPalindrome_ReturnsTrue()
    {
        // Arrange
        var input = "aba";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_EvenLengthPalindrome_ReturnsTrue()
    {
        // Arrange
        var input = "abba";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_RepeatingPattern_ReturnsTrue()
    {
        // Arrange
        var input = "aaaaaa";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Real World Examples

    [Fact]
    public void IsPalindrome_CommonName_ReturnsFalse()
    {
        // Arrange
        var input = "John";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPalindrome_PalindromeWithMultipleSpaces_ReturnsTrue()
    {
        // Arrange
        var input = "race    car";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_MixedSpacesAndPunctuation_ReturnsTrue()
    {
        // Arrange
        var input = "Was it a car or a cat I saw?";

        // Act
        var result = IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    #endregion
}
