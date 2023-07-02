using AlgorithmsAPI.Contracts.Algorithms;
using AlgorithmsAPI.Services.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAPI.Tests.Services.Algorithms
{
    public class CipherServiceTests
    {
        private ICipherService _cipherService;

        [SetUp]
        public void Setup()
        {
            this._cipherService = new CipherService();
        }

        [Test]
        public async Task CaesarCipher_ValidTextKey0ModeEncrypt_ReturnsSameText()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = 0;
            bool mode = true;
            string expectedResult = "The pear falls from the branch.";

            // Act
            string actualResult = await _cipherService.CaesarCipher(text, key, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public async Task CaesarCipher_ValidTextKey0ModeDecrypt_ReturnsSameText()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = 0;
            bool mode = false;
            string expectedResult = "The pear falls from the branch.";

            // Act
            string actualResult = await _cipherService.CaesarCipher(text, key, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CaesarCipher_ValidTextKey3ModeEncrypt_ReturnsEncryptedText()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = 3;
            bool mode = true;
            string expectedResult = "Wkh shdu idoov iurp wkh eudqfk.";

            // Act
            string actualResult = await _cipherService.CaesarCipher(text, key, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CaesarCipher_ValidTextKey3ModeDecrypt_ReturnsDecryptedText()
        {
            // Arrange
            string text = "Wkh shdu idoov iurp wkh eudqfk.";
            int key = 3;
            bool mode = false;
            string expectedResult = "The pear falls from the branch.";

            // Act
            string actualResult = await _cipherService.CaesarCipher(text, key, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ScytaleCipher_ValidTextKey3ModeEncrypt_ReturnsEncryptedText()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            int key = 3;
            bool mode = true;
            string expectedResult = "Tlehl esb  rpfaernaocrmh  .ft ah ";

            // Act
            string actualResult = await _cipherService.ScytaleCipher(text, key, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ScytaleCipher_ValidTextKey3ModeDecrypt_ReturnsDecryptedText()
        {
            // Arrange
            string text = "Tlehl esb  rpfaernaocrmh  .ft ah ";
            int key = 3;
            bool mode = false;
            string expectedResult = "The pear falls from the branch.";

            // Act
            string actualResult = await _cipherService.ScytaleCipher(text, key, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task VigenereCipher_ValidTextKeyStringModeEncrypt_ReturnsEncryptedText()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            string key = "key";
            bool mode = true;
            string expectedResult = "Dlc ziyb jyvpq pvmw xfo fpkrar.";

            // Act
            string actualResult = await _cipherService.VigenereCipher(text, key, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task VigenereCipher_ValidTextKeyStringModeDecrypt_ReturnsDecryptedText()
        {
            // Arrange
            string text = "Dlc ziyb jyvpq pvmw xfo fpkrar.";
            string key = "key";
            bool mode = false;
            string expectedResult = "The pear falls from the branch.";

            // Act
            string actualResult = await _cipherService.VigenereCipher(text, key, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task AtbashCipher_ValidTextModeEncrypt_ReturnsEncryptedText()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            bool mode = true;
            string expectedResult = "Gsv kvzi uzooh uiln gsv yizmxs.";

            // Act
            string actualResult = await _cipherService.AtbashCipher(text, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task AtbashCipher_ValidTextModeDecrypt_ReturnsDecryptedText()
        {
            // Arrange
            string text = "Gsv kvzi uzooh uiln gsv yizmxs.";
            bool mode = false;
            string expectedResult = "The pear falls from the branch.";

            // Act
            string actualResult = await _cipherService.AtbashCipher(text, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task Rot13Cipher_ValidTextModeEncrypt_ReturnsEncryptedText()
        {
            // Arrange
            string text = "The pear falls from the branch.";
            bool mode = true;
            string expectedResult = "Gur crne snyyf sebz gur oenapu.";

            // Act
            string actualResult = await _cipherService.Rot13Cipher(text, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task Rot13Cipher_ValidTextModeDecrypt_ReturnsDecryptedText()
        {
            // Arrange
            string text = "Gur crne snyyf sebz gur oenapu.";
            bool mode = false;
            string expectedResult = "The pear falls from the branch.";

            // Act
            string actualResult = await _cipherService.Rot13Cipher(text, mode);

            // Assert
            Assert.AreEqual(expectedResult.Length, actualResult.Length);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task A1Z26Cipher_ValidTextModeEncrypt_ReturnsEncryptedText()
        {
            // Arrange
            string text = "the pear falls from the branch.";
            bool mode = true;
            string expectedResult = "20-8-5 16-5-1-18 6-1-12-12-19 6-18-15-13 20-8-5 2-18-1-14-3-8.";

            // Act
            string actualResult = await _cipherService.A1Z26Cipher(text, mode);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task A1Z26Cipher_ValidTextModeDecrypt_ReturnsDecryptedText()
        {
            // Arrange
            string text = "20-8-5 16-5-1-18 6-1-12-12-19 6-18-15-13 20-8-5 2-18-1-14-3-8.";
            bool mode = false;
            string expectedResult = "the pear falls from the branch.";

            // Act
            string actualResult = await _cipherService.A1Z26Cipher(text, mode);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
