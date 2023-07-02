using AlgorithmsAPI.Contracts.Helpers;
using AlgorithmsAPI.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Services.Helpers
{
    public class ConversionServiceTests
    {
        private IConversionService _conversionService;

        [SetUp]
        public void Setup()
        {
            this._conversionService = new ConversionService();
        }

        [Test]
        public void GetArrayNumbersFromString_ValidNumbers_ReturnsIntArray()
        {
            // Arrange
            string numbers = "1 2 3 4 5";
            int[] expectedResult = { 1, 2, 3, 4, 5 };

            // Act
            int[] actualResult = _conversionService.GetArrayNumbersFromString(numbers);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetArrayNumbersFromString_InvalidString_ThrowsFormatException()
        {
            // Arrange
            string numbers = "1 2 abc 4 5";

            // Act & Assert
            Assert.Throws<FormatException>(() => _conversionService.GetArrayNumbersFromString(numbers));
        }

        [Test]
        public void GetStringFromArrayNumbers_ValidNumbers_ReturnsIntArray()
        {
            // Arrange
            int[] numbers = { 1, 2, 3, 4, 5 };
            string expectedResult = "1 2 3 4 5";

            // Act
            string actualResult = _conversionService.GetStringFromArrayNumbers(numbers);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetStringFromArrayNumbers_NullArray_ThrowsArgumentNullException()
        {
            // Arrange
            int[] array = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _conversionService.GetStringFromArrayNumbers(array));
        }
    }
}
