namespace AlgorithmsAPI.Contracts.Algorithms
{
    public interface ICipherService
    {
        Task<string> CaesarCipher(string text, int key, bool mode);
        Task<string> VigenereCipher(string text, string key, bool mode);
        Task<string> ScytaleCipher(string text, int key, bool mode);
        Task<string> AtbashCipher(string text, bool mode);
        Task<string> Rot13Cipher(string text, bool mode);
        Task<string> A1Z26Cipher(string text, bool mode);
    }
}
