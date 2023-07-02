using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Services.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Services.Algorithms
{
    public class StringsServiceTests
    {
        private IStringsService _stringsService;

        [SetUp]
        public void Setup()
        {
            this._stringsService = new StringsService();
        }

        [Test]
        public async Task IsStringPalindrom_PalindromString_ReturnsTrue()
        {
            // Arrange
            string palindrom = "Wow";

            // Act
            bool actualResult = await _stringsService.IsStringPalindrom(palindrom);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public async Task IsStringPalindrom_NonPalindromString_ReturnsFalse()
        {
            // Arrange
            string nonPalindrom = "abc";

            // Act
            bool actualResult = await _stringsService.IsStringPalindrom(nonPalindrom);

            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public async Task IsStringPalindrom_SingleCharacterString_ReturnsTrue()
        {
            // Arrange
            string singleCharacterString = "a";

            // Act
            bool actualResult = await _stringsService.IsStringPalindrom(singleCharacterString);

            // Assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public async Task ReverseString_ValidString_ReturnsReversedString()
        {
            // Arrange
            string validString = "abc";
            string expectedResult = "cba";

            // Act
            string actualResult = await _stringsService.ReverseString(validString);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ReverseString_SingleCharacterString_ReturnsSameString()
        {
            // Arrange
            string singleCharacter = "a";
            string expectedResult = "a";

            // Act
            string actualResult = await _stringsService.ReverseString(singleCharacter);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ReverseString_StringWithSpaces_ReturnsReversedStringWithSpaces()
        {
            // Arrange
            string stringWithSpaces = "Hello world";
            string expectedResult = "dlrow olleH";

            // Act
            string actualResult = await _stringsService.ReverseString(stringWithSpaces);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task GetEveryUniquePermutation_ValidString_ReturnsValidPermutation()
        {
            // Arrange
            string validString = "abc";
            List<string> expectedResult = new List<string> { "abc", "acb", "bac", "bca", "cab", "cba" };

            // Act
            List<string> actualResult = await _stringsService.GetEveryUniquePermutation(validString);

            // Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task GetEveryUniquePermutation_SingleCharacter_ReturnsSameCharacter()
        {
            // Arrange
            string singleCharacter = "a";
            List<string> expectedResult = new List<string> { "a" };

            // Act
            List<string> actualResult = await _stringsService.GetEveryUniquePermutation(singleCharacter);

            // Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task FindSubstring_ValidStringAndValidSubstring_ReturnsIndexList()
        {
            // Arrange
            string validString = "I like apples and oranges, but I prefer apples.";
            string validSubstring = "apples";
            List<int> expectedResult = new List<int> { 7, 40 };

            // Act
            List<int> actualResult = await _stringsService.FindSubstring(validString, validSubstring);

            // Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task FindSubstring_ValidStringAndSubstringNotFound_ReturnsEmptyList()
        {
            // Arrange
            string validString = "I like apples and oranges, but I prefer apples.";
            string validSubstring = "pears";
            List<int> expectedResult = new List<int> { };

            // Act
            List<int> actualResult = await _stringsService.FindSubstring(validString, validSubstring);

            // Assert
            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ReplaceSubstring_SubstringNotPresent_ReturnsOriginalText()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            string substring = "pears";
            string replacement = "bilberry";
            string expectedResult = "I like apples and oranges, but I prefer apples.";

            // Act
            string actualResult = await _stringsService.ReplaceSubstring(text, substring, replacement);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ReplaceSubstring_SubstringOccursOnce_ReplacesSubstring()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            string substring = "oranges";
            string replacement = "pears";
            string expectedResult = "I like apples and pears, but I prefer apples.";

            // Act
            string actualResult = await _stringsService.ReplaceSubstring(text, substring, replacement);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ReplaceSubstring_SubstringOccursMultipleTimes_ReplacesAllOccurrences()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            string substring = "apples";
            string replacement = "pears";
            string expectedResult = "I like pears and oranges, but I prefer pears.";

            // Act
            string actualResult = await _stringsService.ReplaceSubstring(text, substring, replacement);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
