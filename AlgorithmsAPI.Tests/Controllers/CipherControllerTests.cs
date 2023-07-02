using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Controllers;
using AlgorithmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Controllers
{
    public class CipherControllerTests
    {
        private CipherController _cipherController;
        private Mock<ICipherService> _cipherServiceMock;
        private Mock<ILogger<CipherController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            this._cipherServiceMock = new Mock<ICipherService>();
            this._loggerMock = new Mock<ILogger<CipherController>>();

            this._cipherController = new CipherController(_cipherServiceMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task Caesar_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";
            int key = 15;

            // Act
            var actualResult = await _cipherController.Caesar(text, key, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Caesar_InvalidKeyValue_ReturnsBadRequest()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = -5;

            // Act
            var actualResult = await _cipherController.Caesar(text, key, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Caesar_InvalidMode_ThrowsArgumentException()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = 1;
            CipherMode mode = (CipherMode)3;

            // Act
            var actualResult = await _cipherController.Caesar(text, key, mode);
            var statusCodeResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
            Assert.AreEqual("Invalid parameter value mode", statusCodeResult.Value);
        }

        [Test]
        public async Task Caesar_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            int key = 0;
            string caesarCipherResult = "I like apples and oranges, but I prefer apples.";
            var expectedResult = new CipherResult
            {
                NameOfAlgorithm = "Caesar",
                ElapsedTime = It.IsAny<TimeSpan>(),
                TextToTransform = text,
                Key = key.ToString(),
                SelectedMode = CipherMode.Encrypt,
                ResultText = caesarCipherResult
            };

            _cipherServiceMock.Setup(service => service.CaesarCipher(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(caesarCipherResult);

            // Act
            var actualResult = await _cipherController.Caesar(text, key, CipherMode.Encrypt);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((CipherResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.TextToTransform, ((CipherResult)okResult.Value).TextToTransform);
            Assert.AreEqual(expectedResult.Key, ((CipherResult)okResult.Value).Key);
            Assert.AreEqual(expectedResult.SelectedMode, ((CipherResult)okResult.Value).SelectedMode);
            Assert.AreEqual(expectedResult.ResultText, ((CipherResult)okResult.Value).ResultText);
        }

        [Test]
        public async Task Caesar_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "I like apples and oranges, but I prefer apples.";
            int key = 0;
            var exception = new Exception("Some error message");

            _cipherServiceMock.Setup(service => service.CaesarCipher(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _cipherController.Caesar(text, key, CipherMode.Encrypt);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task Vigenere_TwoEmptyStrings_ReturnsBadRequest()
        {
            // Arrange
            string text = "";
            string key = "";

            // Act
            var actualResult = await _cipherController.Vigenere(text, key, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Vigenere_OneEmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "Dlc ziyb jyvpq pvmw xfo fpkrar.";
            string key = "";

            // Act
            var actualResult = await _cipherController.Vigenere(text, key, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Vigenere_InvalidMode_ThrowsArgumentException()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            string key = "key";
            CipherMode mode = (CipherMode)3;

            // Act
            var actualResult = await _cipherController.Vigenere(text, key, mode);
            var statusCodeResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
            Assert.AreEqual("Invalid parameter value mode", statusCodeResult.Value);
        }

        [Test]
        public async Task Vigenere_CorrectStrings_ReturnsOkWithResult()
        {
            // Arrange
            string text = "Dlc ziyb jyvpq pvmw xfo fpkrar.";
            string key = "key";
            string vigenereCipherResult = "The pear falls from the branch.";
            var expectedResult = new CipherResult
            {
                NameOfAlgorithm = "Vigenere",
                ElapsedTime = It.IsAny<TimeSpan>(),
                TextToTransform = text,
                Key = key.ToString().ToUpper(),
                SelectedMode = CipherMode.Encrypt,
                ResultText = vigenereCipherResult
            };

            _cipherServiceMock.Setup(service => service.VigenereCipher(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(vigenereCipherResult);

            // Act
            var actualResult = await _cipherController.Vigenere(text, key, CipherMode.Encrypt);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((CipherResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.TextToTransform, ((CipherResult)okResult.Value).TextToTransform);
            Assert.AreEqual(expectedResult.Key, ((CipherResult)okResult.Value).Key);
            Assert.AreEqual(expectedResult.SelectedMode, ((CipherResult)okResult.Value).SelectedMode);
            Assert.AreEqual(expectedResult.ResultText, ((CipherResult)okResult.Value).ResultText);
        }

        [Test]
        public async Task Vigenere_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "Dlc ziyb jyvpq pvmw xfo fpkrar.";
            string key = "key";
            var exception = new Exception("Some error message");

            _cipherServiceMock.Setup(service => service.VigenereCipher(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _cipherController.Vigenere(text, key, CipherMode.Encrypt);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task Scytale_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";
            int key = 15;

            // Act
            var actualResult = await _cipherController.Scytale(text, key, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Scytale_InvalidKeyValue_ReturnsBadRequest()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = -5;

            // Act
            var actualResult = await _cipherController.Scytale(text, key, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Scytale_InvalidMode_ThrowsArgumentException()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = 3;
            CipherMode mode = (CipherMode)3;

            // Act
            var actualResult = await _cipherController.Scytale(text, key, mode);
            var statusCodeResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
            Assert.AreEqual("Invalid parameter value mode", statusCodeResult.Value);
        }

        [Test]
        public async Task Scytale_CorrectStringAndKey_ReturnsOkWithResult()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = 3;
            string scytaleCipherResult = "Tlehl esb  rpfaernaocrmh  .ft ah ";
            var expectedResult = new CipherResult
            {
                NameOfAlgorithm = "Scytale",
                ElapsedTime = It.IsAny<TimeSpan>(),
                TextToTransform = text,
                Key = key.ToString(),
                SelectedMode = CipherMode.Encrypt,
                ResultText = scytaleCipherResult
            };

            _cipherServiceMock.Setup(service => service.ScytaleCipher(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
                .ReturnsAsync(scytaleCipherResult);

            // Act
            var actualResult = await _cipherController.Scytale(text, key, CipherMode.Encrypt);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((CipherResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.TextToTransform, ((CipherResult)okResult.Value).TextToTransform);
            Assert.AreEqual(expectedResult.Key, ((CipherResult)okResult.Value).Key);
            Assert.AreEqual(expectedResult.SelectedMode, ((CipherResult)okResult.Value).SelectedMode);
            Assert.AreEqual(expectedResult.ResultText, ((CipherResult)okResult.Value).ResultText);
        }

        [Test]
        public async Task Scytale_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = 3;
            var exception = new Exception("Some error message");

            _cipherServiceMock.Setup(service => service.ScytaleCipher(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<bool>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _cipherController.Scytale(text, key, CipherMode.Encrypt);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task Atbash_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";

            // Act
            var actualResult = await _cipherController.Atbash(text, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Atbash_InvalidMode_ThrowsArgumentException()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            CipherMode mode = (CipherMode)3;

            // Act
            var actualResult = await _cipherController.Atbash(text, mode);
            var statusCodeResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
            Assert.AreEqual("Invalid parameter value mode", statusCodeResult.Value);
        }

        [Test]
        public async Task Atbash_CorrectString_ReturnsOkWithResult()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            string atbashCipherResult = "Gsv kvzi uzooh uiln gsv yizmxs.";
            var expectedResult = new CipherResult
            {
                NameOfAlgorithm = "Atbash",
                ElapsedTime = It.IsAny<TimeSpan>(),
                TextToTransform = text,
                Key = "Not needed",
                SelectedMode = CipherMode.Encrypt,
                ResultText = atbashCipherResult
            };

            _cipherServiceMock.Setup(service => service.AtbashCipher(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(atbashCipherResult);

            // Act
            var actualResult = await _cipherController.Atbash(text, CipherMode.Encrypt);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((CipherResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.TextToTransform, ((CipherResult)okResult.Value).TextToTransform);
            Assert.AreEqual(expectedResult.Key, ((CipherResult)okResult.Value).Key);
            Assert.AreEqual(expectedResult.SelectedMode, ((CipherResult)okResult.Value).SelectedMode);
            Assert.AreEqual(expectedResult.ResultText, ((CipherResult)okResult.Value).ResultText);
        }

        [Test]
        public async Task Atbash_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            var exception = new Exception("Some error message");

            _cipherServiceMock.Setup(service => service.AtbashCipher(It.IsAny<string>(), It.IsAny<bool>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _cipherController.Atbash(text, CipherMode.Encrypt);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task Rot13_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";

            // Act
            var actualResult = await _cipherController.Rot13(text, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task Rot13_InvalidMode_ThrowsArgumentException()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            CipherMode mode = (CipherMode)3;

            // Act
            var actualResult = await _cipherController.Rot13(text, mode);
            var statusCodeResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
            Assert.AreEqual("Invalid parameter value mode", statusCodeResult.Value);
        }

        [Test]
        public async Task Rot13_CorrectString_ReturnsOkWithResult()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            string rot13CipherResult = "Gur crne snyyf sebz gur oenapu.";
            var expectedResult = new CipherResult
            {
                NameOfAlgorithm = "Rot13",
                ElapsedTime = It.IsAny<TimeSpan>(),
                TextToTransform = text,
                Key = "Not needed",
                SelectedMode = CipherMode.Encrypt,
                ResultText = rot13CipherResult
            };

            _cipherServiceMock.Setup(service => service.Rot13Cipher(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(rot13CipherResult);

            // Act
            var actualResult = await _cipherController.Rot13(text, CipherMode.Encrypt);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((CipherResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.TextToTransform, ((CipherResult)okResult.Value).TextToTransform);
            Assert.AreEqual(expectedResult.Key, ((CipherResult)okResult.Value).Key);
            Assert.AreEqual(expectedResult.SelectedMode, ((CipherResult)okResult.Value).SelectedMode);
            Assert.AreEqual(expectedResult.ResultText, ((CipherResult)okResult.Value).ResultText);
        }

        [Test]
        public async Task Rot13_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            var exception = new Exception("Some error message");

            _cipherServiceMock.Setup(service => service.Rot13Cipher(It.IsAny<string>(), It.IsAny<bool>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _cipherController.Rot13(text, CipherMode.Encrypt);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }

        [Test]
        public async Task A1Z26_EmptyString_ReturnsBadRequest()
        {
            // Arrange
            string text = "";

            // Act
            var actualResult = await _cipherController.A1Z26(text, CipherMode.Encrypt);
            var badRequestResult = actualResult as BadRequestResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }

        [Test]
        public async Task A1Z26_InvalidMode_ThrowsArgumentException()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            CipherMode mode = (CipherMode)3;

            // Act
            var actualResult = await _cipherController.A1Z26(text, mode);
            var statusCodeResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
            Assert.AreEqual("Invalid parameter value mode", statusCodeResult.Value);
        }

        [Test]
        public async Task A1Z26_CorrectString_ReturnsOkWithResult()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            string a1z26CipherResult = "20-8-5 16-5-1-18 6-1-12-12-19 6-18-15-13 20-8-5 2-18-1-14-3-8.";
            var expectedResult = new CipherResult
            {
                NameOfAlgorithm = "A1Z26",
                ElapsedTime = It.IsAny<TimeSpan>(),
                TextToTransform = text,
                Key = "Not needed",
                SelectedMode = CipherMode.Encrypt,
                ResultText = a1z26CipherResult
            };

            _cipherServiceMock.Setup(service => service.A1Z26Cipher(It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(a1z26CipherResult);

            // Act
            var actualResult = await _cipherController.A1Z26(text, CipherMode.Encrypt);
            var okResult = actualResult as OkObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(expectedResult.NameOfAlgorithm, ((CipherResult)okResult.Value).NameOfAlgorithm);
            Assert.AreEqual(expectedResult.TextToTransform, ((CipherResult)okResult.Value).TextToTransform);
            Assert.AreEqual(expectedResult.Key, ((CipherResult)okResult.Value).Key);
            Assert.AreEqual(expectedResult.SelectedMode, ((CipherResult)okResult.Value).SelectedMode);
            Assert.AreEqual(expectedResult.ResultText, ((CipherResult)okResult.Value).ResultText);
        }

        [Test]
        public async Task A1Z26_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            var exception = new Exception("Some error message");

            _cipherServiceMock.Setup(service => service.A1Z26Cipher(It.IsAny<string>(), It.IsAny<bool>()))
                .ThrowsAsync(exception);

            // Act
            var actualResult = await _cipherController.A1Z26(text, CipherMode.Encrypt);
            var objectResult = actualResult as ObjectResult;

            // Assert
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, objectResult.StatusCode);
            Assert.AreEqual(exception.Message, objectResult.Value);
        }
    }
}
