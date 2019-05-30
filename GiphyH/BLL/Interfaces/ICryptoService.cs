namespace GiphyH.BLL.Interfaces
{
    public interface ICryptoService
    {
        string EncryptId(string id);

        int DecryptId(string cipheredId);

        string CreatePasswordHash(string password);
    }
}
